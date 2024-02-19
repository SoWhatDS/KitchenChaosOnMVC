using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.PlayerControllers
{
    internal sealed class GameInput 
    {
        private PlayerInputActions _playerInputActions;

        public GameInput()
        {
            _playerInputActions = new PlayerInputActions();
            _playerInputActions.Enable();
        }

        public Vector2 GetMovementVectorNormalized()
        {
            Vector2 inputVector = _playerInputActions.Player.Move.ReadValue<Vector2>();

            Vector2 inputVectorNormalized = inputVector.normalized;

            return inputVectorNormalized;
        }
    }
}
