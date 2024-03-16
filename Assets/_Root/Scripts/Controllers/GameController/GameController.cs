using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KitchenChaosMVC.Engine.Game.PlayerControllers;
using KitchenChaosMVC.Settings;
using KitchenChaosMVC.Engine.Game.CountersControllers;
using KitchenChaosMVC.Engine.Game.UIController;
using KitchenChaosMVC.Engine.Game.AudioController;
using KitchenChaosMVC.Utils;
using JoostenProductions;

namespace KitchenChaosMVC.Engine.Game
{
    internal sealed class GameController : BaseController
    {
        private ProfileGame _profileGame;
        private SettingsContainer _settingsContainer;
        private GameView _gameView;
        private GameModel _gameModel;
        private GameInput _gameInput;

        private PlayerController _playerController;
        private CountersController _countersController;
        private UIControllerInGame _uiControllerInGame;
        private AudioManagerController _audioManagerController;
        private PauseGameController _gamePauseController;

        private bool _isGameStart;
        private float _timerGameOver;

        public GameController(ProfileGame profileGame,SettingsContainer settingsContainer)
        {
            _profileGame = profileGame;
            _settingsContainer = settingsContainer;
            _gameView = LoadView();
            _gameModel = _settingsContainer.GameModel;
            _isGameStart = false;

            CreateAllControllers();

            UpdateManager.SubscribeToUpdate(Update);
        }

        private void Update()
        {
            CountDownTimer();
            PlayingTimer();
        }

        private GameView LoadView()
        {
            GameObject prefab = ResourceLoader.LoadPrefab(GameConstantsView.GAME_VIEW);
            GameObject objectView = Object.Instantiate(prefab);
            AddGameObjects(objectView);
            return ResourceLoader.GetOrAddComponent<GameView>(objectView);
        }

        private void CreateAllControllers()
        {
            _gameInput = new GameInput();

            _countersController = new CountersController(_settingsContainer.CountersModel);
            AddControllers(_countersController);

            _uiControllerInGame = new UIControllerInGame(_settingsContainer.UIControllerModel);
            AddControllers(_uiControllerInGame);

            _audioManagerController = new AudioManagerController(_settingsContainer.AudioManagerModel);
            AddControllers(_audioManagerController);

            _gamePauseController = new PauseGameController(_profileGame,_gameInput);
            AddControllers(_gamePauseController);
        }

        private void CountDownTimer()
        {
            if (_isGameStart)
            {
                return;
            }

            _gameModel.CountDownTimer -= Time.deltaTime;
            _settingsContainer.UIControllerModel.CountDownUIModel.OnCountDownTimer?.Invoke(_gameModel.CountDownTimer);

            if (_gameModel.CountDownTimer < 0f)
            {
                _settingsContainer.UIControllerModel.CountDownUIModel.OnStartPlaying?.Invoke();
                _playerController = new PlayerController(_settingsContainer.PlayerModel,_gameInput);
                _isGameStart = true;
            }
        }

        private void PlayingTimer()
        {
            if (_isGameStart)
            {
                _timerGameOver += Time.deltaTime;
                _gameView.UpdateClockImage(_timerGameOver, _gameModel.TimerMaxPlaying);
            }

            if (_timerGameOver > _gameModel.TimerMaxPlaying)
            {
                _settingsContainer.UIControllerModel.GameOverUIModel.OnGameOverUI?.Invoke();
                Time.timeScale = 0f;
            }
            
        }

        protected override void OnDispose()
        {
            _isGameStart = false;
            UpdateManager.UnsubscribeFromUpdate(Update);
            _playerController?.Dispose();
            _countersController?.Dispose();
            _uiControllerInGame?.Dispose();
            _audioManagerController?.Dispose();
            _gamePauseController?.Dispose();
            
        }


    }
}
