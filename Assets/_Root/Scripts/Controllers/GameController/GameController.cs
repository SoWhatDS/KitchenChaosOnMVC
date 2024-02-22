using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KitchenChaosMVC.Engine.Game.PlayerControllers;
using KitchenChaosMVC.Settings;
using KitchenChaosMVC.Engine.Game.CountersControllers;


namespace KitchenChaosMVC.Engine.Game
{
    internal sealed class GameController : BaseController
    {
        private ProfileGame _profileGame;
        private SettingsContainer _settingsContainer;
        private PlayerController _playerController;
        private CountersController _countersController;

        public GameController(ProfileGame profileGame,SettingsContainer settingsContainer)
        {
            _profileGame = profileGame;
            _settingsContainer = settingsContainer;

            CreateAllControllers();
        }

        private void CreateAllControllers()
        {
            _playerController = new PlayerController(_settingsContainer.PlayerModel);
            _countersController = new CountersController(_settingsContainer.CountersModel);
        }

        protected override void OnDispose()
        {
            _playerController?.Dispose();
            _countersController?.Dispose();
        }


    }
}
