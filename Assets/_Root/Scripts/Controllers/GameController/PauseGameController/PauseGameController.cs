using System.Collections;
using System.Collections.Generic;
using KitchenChaosMVC.Engine.Game.PlayerControllers;
using KitchenChaosMVC.Settings;
using KitchenChaosMVC.Utils;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game
{
    public class PauseGameController : BaseController
    {
        private PauseGameView _pauseGameView;
        private ProfileGame _profileGame;
        private GameInput _gameInput;

        internal PauseGameController(ProfileGame profileGame,GameInput gameInput)
        {
            _profileGame = profileGame;
            _pauseGameView = LoadView();
            _pauseGameView.Init(MainMenu,Retry);

            _gameInput = gameInput;

            _gameInput.OnPauseInteract += GameInput_OnPauseInteract;
        }

        private PauseGameView LoadView()
        {
            GameObject prefab = ResourceLoader.LoadPrefab(GameConstantsView.PAUSE_VIEW);
            GameObject objectView = Object.Instantiate(prefab);
            AddGameObjects(objectView);
            return ResourceLoader.GetOrAddComponent<PauseGameView>(objectView);

        }

        private void GameInput_OnPauseInteract(object sender, System.EventArgs e)
        {
            _pauseGameView.TogglePause();
        }

        private void Retry()
        {
            _profileGame.CurrentGameState.Value = GameState.StartGame;
        }

        private void MainMenu()
        {
            _profileGame.CurrentGameState.Value = GameState.MainMenu;
        }

        protected override void OnDispose()
        {

            _gameInput.OnPauseInteract -= GameInput_OnPauseInteract;
        }
    }

    
}
