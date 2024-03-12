using System;
using System.Collections;
using System.Collections.Generic;
using KitchenChaosMVC.Engine.Game.PlayerControllers;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    public sealed class DeliveryCounter : BaseCounter
    {
        public Action OnCreateNewWaitingRecipe;
        public Action<PlateKitchenObject> OnCheckCorrectRecipeDelivered;

        private DeliveryCounterView _deliveryCounterView;
        private DeliveryCounterModel _deliveryCounterModel;
        private DeliveryManager _deliveryManager;

        private float _timerRecipe;

        public DeliveryCounter(DeliveryCounterView deliveryCounterView,DeliveryCounterModel deliveryCounterModel)
        {
            _deliveryCounterView = deliveryCounterView;
            _deliveryCounterModel = deliveryCounterModel;

            _deliveryCounterView.Init(this);

            _deliveryCounterView.SelectedCounter.Hide();

            CounterTopPoint = _deliveryCounterView.CounterTopPoint;
            SelectedCounter = _deliveryCounterView.SelectedCounter;

            _deliveryManager = new DeliveryManager(_deliveryCounterModel);


            OnInteract += Interact;
            IsSelected += ShowSelectedVisualEffect;
            OnCreateNewWaitingRecipe += _deliveryManager.CreateNewWaitingRecipe;
            OnCheckCorrectRecipeDelivered += _deliveryManager.CheckCorrectDeliveryRecipe;

        }

        public void WaitingRecipeTimer()
        {
            _timerRecipe -= Time.deltaTime;

            if (_timerRecipe <= 0f)
            {
                _timerRecipe = _deliveryCounterModel.WaitingRecipeTimerMax;
                OnCreateNewWaitingRecipe?.Invoke();
            }
        }

        protected override void Interact(Player player)
        {
            if (player.GetKitchenObjectFromParent().TryGetPlateKitchenObject(out PlateKitchenObject plateKitchenObject))
            {
                OnCheckCorrectRecipeDelivered?.Invoke(plateKitchenObject);

            }
        }

        public void Dispose()
        {
            OnInteract -= Interact;
            IsSelected -= ShowSelectedVisualEffect;
            OnCreateNewWaitingRecipe -= _deliveryManager.CreateNewWaitingRecipe;
            OnCheckCorrectRecipeDelivered -= _deliveryManager.CheckCorrectDeliveryRecipe;
        }
    }
}
