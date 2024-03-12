using System;
using System.Collections;
using System.Collections.Generic;
using KitchenChaosMVC.Engine.Game.AudioController;
using KitchenChaosMVC.Engine.Game.CountersControllers;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.PlayerControllers
{
    internal sealed class PlayerNewInputMovement : IMove
    {
        private bool _isWalking;
        private GameInput _gameInput;
        private PlayerView _playerView;
        private PlayerModel _playerModel;
        private AudioManagerModel _audioManagerModel;
        private Player _player;

        private float _moveSpeed;
        private float _rotateSpeed;
        private Vector3 _moveDirection;

        private bool _canMove;
        private float _playerHeight = 2f;
        private float _playerRadius = 0.7f;
        private float _moveDistance;

        private Vector3 _moveDirX;
        private Vector3 _moveDirZ;

        private Vector3 _lastDirection;
        private float _interactDistance = 2f;
        private LayerMask _counterLayerMask;

        private float _moveAudioTimer = 0.1f;

        private BaseCounter _selectedCounter;

        public bool IsWalking
        {
            get => _isWalking;

            private set
            {
                _isWalking = value;
            }
        }

        public PlayerNewInputMovement(Player player)
        {
            _player = player;
            _playerView = _player.GetPlayerView();
            _playerModel = _player.GetPlayerModel();
            _audioManagerModel = _playerModel.AudioManagerModel;
            _moveSpeed = _playerModel.MoveSpeed;
            _rotateSpeed = _playerModel.RotateSpeed;
            _counterLayerMask = _playerModel.CounterLayerMask;
            _gameInput = new GameInput();
            _gameInput.OnInteractionInput += GameInput_OnInteractionInput;
            _gameInput.OnInteractAlternateInput += GameInput_OnInteractAlternateInput;
        }

        private void GameInput_OnInteractAlternateInput(object sender, EventArgs e)
        {
            if (_selectedCounter == null)
            {
                return;
            }

            _selectedCounter.OnInteractAlternate?.Invoke(_player);
        }

        private void GameInput_OnInteractionInput(object sender, System.EventArgs e)
        {
            if (_selectedCounter == null)
            {
                return;
            }

            _selectedCounter.OnInteract?.Invoke(_player);
        }

        public void HandleInteract()
        {
            Vector2 inputVector = _gameInput.GetMovementVectorNormalized();
            _moveDirection = new Vector3(inputVector.x, 0, inputVector.y);

            if (_moveDirection != Vector3.zero)
            {
                _lastDirection = _moveDirection;
            }

            if (Physics.Raycast(_playerView.transform.position, _lastDirection, out RaycastHit raycastHit, _interactDistance, _counterLayerMask))
            {
                if (raycastHit.transform.TryGetComponent<IBaseCounter>(out IBaseCounter baseCounter))
                {
                    _selectedCounter = baseCounter.BaseCounter;
                    _selectedCounter.IsSelected?.Invoke(true);
                }
                else
                {
                    _selectedCounter.IsSelected?.Invoke(false);
                    _selectedCounter = null;
                }
            }
            else
            {
                if (_selectedCounter == null)
                {
                    return;
                }
                _selectedCounter.IsSelected?.Invoke(false);
                _selectedCounter = null;
            }
        }

        public void HandleMovement()
        {
            Vector2 inputVector = _gameInput.GetMovementVectorNormalized();
            _moveDirection = new Vector3(inputVector.x, 0, inputVector.y);

            _moveDistance = _moveSpeed * Time.deltaTime;
            _canMove =!Physics.CapsuleCast(_playerView.transform.position,
                _playerView.transform.position + Vector3.up * _playerHeight,_playerRadius,_moveDirection,_moveDistance);

            if (!_canMove)
            {
                _moveDirX = new Vector3(_moveDirection.x, 0, 0).normalized;
                _canMove = _moveDirection.x != 0 && !Physics.CapsuleCast(_playerView.transform.position,
                    _playerView.transform.position + Vector3.up * _playerHeight, _playerRadius, _moveDirection, _moveDistance);

                if (_canMove)
                {
                    _moveDirection = _moveDirX;
                }
                else
                {
                    _moveDirZ = new Vector3(0, 0, _moveDirection.y).normalized;
                    _canMove = _moveDirection.z != 0 && !Physics.CapsuleCast(_playerView.transform.position,
                        _playerView.transform.position + Vector3.up * _playerHeight, _playerRadius, _moveDirection, _moveDistance);

                    if (_canMove)
                    {
                        _moveDirection = _moveDirZ;
                    }
                }
            }

            if (_canMove)
            {
                _playerView.transform.position += _moveDirection * _moveDistance;
            }

            _isWalking = _moveDirection != Vector3.zero;

            if (_isWalking)
            {
                AudioPlayTimer();
            }
        }

        public void Rotate()
        {
            _playerView.transform.forward = Vector3.Slerp(_playerView.transform.forward, _moveDirection, Time.deltaTime * _rotateSpeed);
        }

        private void AudioPlayTimer()
        {
            _moveAudioTimer -= Time.deltaTime;

            if (_moveAudioTimer < 0)
            {
                _moveAudioTimer = 0.1f;
                _audioManagerModel.OnPlaySound?.Invoke(_audioManagerModel.FootStep, _playerView.transform.position);
            }
        }

        public void Dispose()
        {
            _gameInput.Dispose();
            _gameInput.OnInteractionInput -= GameInput_OnInteractionInput;
            _gameInput.OnInteractAlternateInput -= GameInput_OnInteractAlternateInput;
        }
    }
}
