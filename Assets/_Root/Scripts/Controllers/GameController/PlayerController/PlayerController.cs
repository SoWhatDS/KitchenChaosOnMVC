using System.Collections;
using System.Collections.Generic;
using JoostenProductions;
using KitchenChaosMVC.Utils;
using UnityEngine;


namespace KitchenChaosMVC.Engine.Game.PlayerControllers
{
    internal sealed class PlayerController : BaseController
    {
        private PlayerView _playerView;
        private PlayerModel _playerModel;
        private Player _player;

        public PlayerController(PlayerModel playerModel)
        {
            _playerView = LoadView();
            _playerModel = playerModel;

            _player = new Player(_playerView,_playerModel);

            UpdateManager.SubscribeToUpdate(Update);
        }

        private PlayerView LoadView()
        {
            GameObject prefab = ResourceLoader.LoadPrefab(GameConstantsView.PLAYER_VIEW);
            GameObject objectView = Object.Instantiate(prefab);
            AddGameObjects(objectView);
            return ResourceLoader.GetOrAddComponent<PlayerView>(objectView);
        }

        private void Update()
        {
            _player.HandleInteract();
            _player.HandleMovement();
            _player.Rotate();
            _player.PlayerAnimationsPlay();
        }

        protected override void OnDispose()
        {
            UpdateManager.UnsubscribeFromUpdate(Update);
        }
    }
}
