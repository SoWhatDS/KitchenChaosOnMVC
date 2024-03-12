using System.Collections;
using System.Collections.Generic;
using KitchenChaosMVC.Settings;
using KitchenChaosMVC.Utils;
using UnityEngine;

namespace KitchenChaosMVC.MainMenu
{
    public sealed class MainMenuController : BaseController
    {
        private MainMenuView _mainMenuView;
        private ProfileGame _profileGame;

        internal MainMenuController(ProfileGame profile)
        {
            _profileGame = profile;
            _mainMenuView = LoadView();
            _mainMenuView.Init(StartGame, QuitGame);
        }

        private MainMenuView LoadView()
        {
            GameObject prefab = ResourceLoader.LoadPrefab(GameConstantsView.MAINMENU_VIEW);
            GameObject objectView = Object.Instantiate(prefab);
            AddGameObjects(objectView);
            return ResourceLoader.GetOrAddComponent<MainMenuView>(objectView);
        }

        private void QuitGame()
        {
            _profileGame.CurrentGameState.Value = GameState.QuitGame;
        }

        private void StartGame()
        {
            _profileGame.CurrentGameState.Value = GameState.Loading;
        }

        protected override void OnDispose()
        {
            
        }
    }
}
