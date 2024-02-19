using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.PlayerControllers
{
    internal sealed class Player 
    {
        private PlayerView _playerView;
        private PlayerModel _playerModel;
        private IMove _playerMovement;
        private PlayerAnimation _playerAnimations;
        

        public Player(PlayerView playerView,PlayerModel playerModel)
        {
            _playerView = playerView;
            _playerModel = playerModel;
            _playerMovement = new PlayerNewInputMovement(_playerView,_playerModel.MoveSpeed,_playerModel.RotateSpeed);
            _playerAnimations = new PlayerAnimation(_playerView.Animator);
            
        }

        public void Move()
        {
            _playerMovement.Move();
        }

        public void Rotate()
        {
            _playerMovement.Rotate();
        }

        public void PlayerAnimationsPlay()
        {
            _playerAnimations.WalkAnimation(_playerMovement.IsWalking);
        }
    }
}
