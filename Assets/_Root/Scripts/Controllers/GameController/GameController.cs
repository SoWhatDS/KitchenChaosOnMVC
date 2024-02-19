using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KitchenChaosMVC.Engine.Game.PlayerControllers;
using KitchenChaosMVC.Settings;

namespace KitchenChaosMVC.Engine.Game
{
    internal sealed class GameController : BaseController
    {
        private ProfileGame _profileGame;
        private SettingsContainer _settingsContainer;
        private PlayerController _playerController;

        public GameController(ProfileGame profileGame,SettingsContainer settingsContainer)
        {
            _profileGame = profileGame;
            _settingsContainer = settingsContainer;

            CreateAllControllers();
        }

        private void CreateAllControllers()
        {
            _playerController = new PlayerController(_settingsContainer.PlayerModel);
        }

        protected override void OnDispose()
        {
            _playerController?.Dispose();
        }


    }
}
