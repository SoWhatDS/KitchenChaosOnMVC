using System;
using System.Collections;
using System.Collections.Generic;
using KitchenChaosMVC.Engine.Game.PlayerControllers;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    public class BaseCounter : IKitchenObjectParent
    {
        public Action<bool> IsSelected { get; set; }
        public Action<Player> OnInteract { get; set; }
        public Action<Player> OnInteractAlternate { get; set; }

        private KitchenObject _kitchenObject;
        private Transform _counterTopPoint;
        private SelectedCounter _selectedCounter;

        public SelectedCounter SelectedCounter
        {
            set
            {
                _selectedCounter = value;
            }
        }

        public Transform CounterTopPoint
        {
            set { _counterTopPoint = value; }
        }

        protected virtual void Interact(Player player)
        {
            Debug.LogError("BaseCounter.Interact()");
        }

        protected virtual void InteractAlternate(Player player)
        {
            Debug.LogError("BaseCounter.InteractAlternate");
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
            return _counterTopPoint;
        }

        protected void ShowSelectedVisualEffect(bool isSelected)
        {
            if (isSelected)
            {
                _selectedCounter.Show();
            }
            else
            {
                _selectedCounter.Hide();
            }
        }
    }
}
