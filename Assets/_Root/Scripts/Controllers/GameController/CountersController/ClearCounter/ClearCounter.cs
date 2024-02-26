using System.Collections;
using System.Collections.Generic;
using KitchenChaosMVC.Engine.Game.PlayerControllers;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    public sealed class ClearCounter : BaseCounter
    {
        private ClearCounterView _clearCounterView;
        private ClearCountersModel _clearCounterModel;

        internal ClearCounter(ClearCounterView clearCounterView,ClearCountersModel clearCounterModel)
        {
            _clearCounterView = clearCounterView;
            _clearCounterModel = clearCounterModel;

            _clearCounterView.Init(this);

            _clearCounterView.SelectedVisualPrefab.Hide();

            CounterTopPoint = _clearCounterView.CounterTopPoint;
            SelectedCounter = _clearCounterView.SelectedVisualPrefab;

            OnInteract += Interact;
            IsSelected += ShowSelectedVisualEffect;
        }
        
        protected override void Interact(Player player)
        {
            if (!HasKitchenObjectInParent())
            {
                if (player.HasKitchenObjectInParent())
                {
                    player.GetKitchenObjectFromParent().SetKitchenObjectInParent(this);
                }
                else
                {
                    //not have kitchenObject in player!!! 
                }
            }
            else
            {
                if (player.HasKitchenObjectInParent())
                {
                    //not set kitchenObject to player because player has kitchenObject!!!
                }
                else
                {
                    GetKitchenObjectFromParent().SetKitchenObjectInParent(player);
                }
            }
        }

        public void Dispose()
        {
            OnInteract -= Interact;
            IsSelected -= ShowSelectedVisualEffect;
        }
    }
}
