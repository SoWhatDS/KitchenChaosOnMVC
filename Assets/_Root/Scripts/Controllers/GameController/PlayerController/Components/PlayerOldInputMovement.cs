using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KitchenChaosMVC.Utils;

namespace KitchenChaosMVC.Engine.Game.PlayerControllers
{
    internal sealed class PlayerOldInputMovement 
    {
        private PlayerView _playerView;
        private float _moveSpeed;
        private float _rotateSpeed;
        private Vector3 _moveDirection;
        private bool _isWalking;

        public bool IsWalking
        {
            get => _isWalking;
            private set
            {
                _isWalking = value;
                //_playerView.Animator.SetBool(GameConstantsAnimation.IS_WALKING, value);
            }
        }


        public PlayerOldInputMovement(PlayerView playerView,float moveSpeed,float rotateSpeed)
        {
            _playerView = playerView;
            _moveSpeed = moveSpeed;
            _rotateSpeed = rotateSpeed;
        }   

        public void HandleMovement()
        {
            _moveDirection = PlayerOldInputSystemMove();

            _playerView.transform.position += _moveDirection * Time.deltaTime * _moveSpeed;
        }

        public void Rotate()
        {
            _playerView.transform.forward = Vector3.Slerp(_playerView.transform.forward, _moveDirection, Time.deltaTime * _rotateSpeed);
        }

        private Vector3 PlayerOldInputSystemMove()
        {
            Vector3 inputVector = new Vector2(0, 0);

            if (Input.GetKey(KeyCode.W))
            {
                inputVector.z += 1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                inputVector.z -= 1;
            }
            if (Input.GetKey(KeyCode.A))
            {
                inputVector.x -= 1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                inputVector.x += 1;
            }

            Vector3 moveDirection = inputVector.normalized;

            IsWalking = moveDirection != Vector3.zero;
            
            return moveDirection;
        }
    }
}
