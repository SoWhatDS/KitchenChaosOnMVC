using System.Collections;
using System.Collections.Generic;
using KitchenChaosMVC.Engine.Game;
using KitchenChaosMVC.Loading;
using KitchenChaosMVC.MainMenu;
using KitchenChaosMVC.Settings;
using KitchenChaosMVC.Utils;
using UnityEngine;

namespace KitchenChaosMVC.Engine
{
    internal sealed class MainController : BaseController
    {
        private readonly ProfileGame _profileGame;
        private readonly SettingsContainer _settingsContainer;

        private GameController _gameController;
        private MainMenuController _mainMenuController;
        private LoadingController _loadingController;

        public MainController(ProfileGame profileGame, SettingsContainer settingsContainer)
        {
            _profileGame = profileGame;
            _settingsContainer = settingsContainer;

            _profileGame.CurrentGameState.SubscribeOnChanged(OnChangedGameState);
            OnChangedGameState(_profileGame.CurrentGameState.Value);
        }

        private void OnChangedGameState(GameState gameState)
        {
            DisposeAllControllers();
            Time.timeScale = 1f;

            switch (gameState)
            {
                case GameState.MainMenu:
                    _mainMenuController = new MainMenuController(_profileGame);
                    break;
                case GameState.Loading:
                    _loadingController = new LoadingController(_profileGame,_settingsContainer);
                    break;
                case GameState.StartGame:
                    _gameController = new GameController(_profileGame, _settingsContainer);
                    break;
                case GameState.PauseGame:
                    break;
                case GameState.QuitGame:
                    QuitGame();
                    break;
                default:
                    DisposeAllControllers();
                    break;
            }
        }

        private void QuitGame()
        {
#if (UNITY_EDITOR || DEVELOPMENT_BUILD)
            {
                Debug.Log(this.GetType() + " : " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
#endif

#if (UNITY_EDITOR)
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }

#elif (UNITY_STANDALONE)
            {
               Application.Quit();
            }
#elif (UNITY_WEBGL)
            {
               SceneManager.LoadScene("QuitScene");
            }
#endif
        }

        private void DisposeAllControllers()
        {
            _gameController?.Dispose();
            _mainMenuController?.Dispose();
            _loadingController?.Dispose();
        }
    }
}
