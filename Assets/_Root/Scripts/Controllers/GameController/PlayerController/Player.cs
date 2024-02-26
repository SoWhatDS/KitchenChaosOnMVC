using System.Collections;
using System.Collections.Generic;
using KitchenChaosMVC.Engine.Game.CountersControllers;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.PlayerControllers
{
    public sealed class Player : IKitchenObjectParent
    {
        private PlayerView _playerView;
        private PlayerModel _playerModel;
        private IMove _playerMovement;
        private PlayerAnimation _playerAnimations;

        private KitchenObject _kitchenObject;
        

        public Player(PlayerView playerView,PlayerModel playerModel)
        {
            _playerView = playerView;
            _playerModel = playerModel;
            _playerMovement = new PlayerNewInputMovement(this);
            _playerAnimations = new PlayerAnimation(_playerView.Animator);
            
        }

        public void HandleInteract()
        {
            _playerMovement.HandleInteract();
        }

        public void HandleMovement()
        {
            _playerMovement.HandleMovement();
        }

        public void Rotate()
        {
            _playerMovement.Rotate();
        }

        public void PlayerAnimationsPlay()
        {
            _playerAnimations.WalkAnimation(_playerMovement.IsWalking);
        }

        public bool HasKitchenObjectInParent()
        {
            return _kitchenObject != null;
        }

        public void SetKitchenObjectToParent(KitchenObject kitchenObject)
        {
            _kitchenObject = kitchenObject;
        }

        public KitchenObject GetKitchenObjectFromParent()
        {
            return _kitchenObject;
        }

        public void ClearKitchenObjectInParent()
        {
            _kitchenObject = null;
        }

        public Transform GetKitchenObjectFollowTransform()
        {
            return _playerView.HoldPointForKitchenObject;
        }

        public PlayerView GetPlayerView()
        {
            return _playerView;
        }

        public PlayerModel GetPlayerModel()
        {
            return _playerModel;
        }

        public void Dispose()
        {
            _playerMovement.Dispose();
        }


    }
}
