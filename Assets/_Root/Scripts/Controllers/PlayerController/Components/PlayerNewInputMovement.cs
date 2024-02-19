using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.PlayerControllers
{
    internal sealed class PlayerNewInputMovement : IMove
    {
        private bool _isWalking;
        private GameInput _gameInput;
        private PlayerView _playerView;
        private float _moveSpeed;
        private float _rotateSpeed;
        private Vector3 _moveDirection;


        public bool IsWalking
        {
            get => _isWalking;
            private set
            {
                _isWalking = value;
            }
        }

        public PlayerNewInputMovement(PlayerView playerView, float moveSpeed, float rotateSpeed)
        {
            _playerView = playerView;
            _moveSpeed = moveSpeed;
            _rotateSpeed = rotateSpeed;
            _gameInput = new GameInput();
        }

        public void Move()
        {
            Vector2 inputVector = _gameInput.GetMovementVectorNormalized();
            _moveDirection = new Vector3(inputVector.x, 0, inputVector.y);
            _isWalking = _moveDirection != Vector3.zero;
            _playerView.transform.position += _moveDirection * Time.deltaTime * _moveSpeed; 
        }

        public void Rotate()
        {
            _playerView.transform.forward = Vector3.Slerp(_playerView.transform.forward, _moveDirection, Time.deltaTime * _rotateSpeed);
        }
    }
}
