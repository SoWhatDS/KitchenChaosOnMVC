using System.Collections;
using System.Collections.Generic;
using KitchenChaosMVC.Engine.Game;
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

        public MainController(ProfileGame profileGame, SettingsContainer settingsContainer)
        {
            _profileGame = profileGame;
            _settingsContainer = settingsContainer;

            _profileGame.CurrentGameState.SubscribeOnChanged(OnChangedGameState);
            OnChangedGameState(_profileGame.CurrentGameState.Value);
        }

        private void OnChangedGameState(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.MainMenu:
                    break;
                case GameState.StartGame:
                    _gameController = new GameController(_profileGame,_settingsContainer);
                    break;
                case GameState.PauseGame:
                    break;
                case GameState.QuitGame:
                    break;
                default:
                    break;
            }
        }

        private void DisposeAllControllers()
        {
            _gameController?.Dispose();
        }
    }
}
