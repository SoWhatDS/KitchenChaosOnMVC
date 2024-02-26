using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.PlayerControllers
{
    internal sealed class GameInput 
    {
        public event EventHandler OnInteractionInput;
        public event EventHandler OnInteractAlternateInput;

        private PlayerInputActions _playerInputActions;

        public GameInput()
        {
            _playerInputActions = new PlayerInputActions();
            _playerInputActions.Enable();
            _playerInputActions.Player.Interact.performed += Interact_performed;
            _playerInputActions.Player.InteractAlternate.performed += InteractAlternate_performed;
        }

        private void InteractAlternate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            OnInteractAlternateInput?.Invoke(this, EventArgs.Empty);
        }

        private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            OnInteractionInput?.Invoke(this, EventArgs.Empty);
        }

        public Vector2 GetMovementVectorNormalized()
        {
            Vector2 inputVector = _playerInputActions.Player.Move.ReadValue<Vector2>();

            Vector2 inputVectorNormalized = inputVector.normalized;

            return inputVectorNormalized;
        }

        public void Dispose()
        {
            _playerInputActions.Player.Interact.performed -= Interact_performed;
            _playerInputActions.Player.InteractAlternate.performed -= InteractAlternate_performed;
        }
    }
}
