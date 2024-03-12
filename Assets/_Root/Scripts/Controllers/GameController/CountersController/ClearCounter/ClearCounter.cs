using System.Collections;
using System.Collections.Generic;
using KitchenChaosMVC.Engine.Game.PlayerControllers;
using UnityEngine;
using KitchenChaosMVC.Engine.Game.AudioController;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    public sealed class ClearCounter : BaseCounter
    {
        private ClearCounterView _clearCounterView;
        private ClearCountersModel _clearCounterModel;
        private AudioManagerModel _audioManagerModel;


        internal ClearCounter(ClearCounterView clearCounterView,ClearCountersModel clearCounterModel)
        {
            _clearCounterView = clearCounterView;
            _clearCounterModel = clearCounterModel;
            _audioManagerModel = _clearCounterModel.AudioManagerModel;

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
                    _audioManagerModel.OnPlaySound?.Invoke(_audioManagerModel.ObjectDrop,_clearCounterView.transform.position);
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
                    if (player.GetKitchenObjectFromParent().TryGetPlateKitchenObject(out PlateKitchenObject plateKitchenObject))
                    {
                        if (plateKitchenObject.TryAddIngredients(GetKitchenObjectFromParent().GetKitchenObjectSO()))
                        {
                            GetKitchenObjectFromParent().DestroySelf();
                            _audioManagerModel.OnPlaySound?.Invoke(_audioManagerModel.ObjectPickUp, plateKitchenObject.transform.position);
                        }
                    }
                    else
                    {
                        if (GetKitchenObjectFromParent().TryGetPlateKitchenObject(out plateKitchenObject))
                        {
                            if (plateKitchenObject.TryAddIngredients(player.GetKitchenObjectFromParent().GetKitchenObjectSO()))
                            {
                                _audioManagerModel.OnPlaySound?.Invoke(_audioManagerModel.ObjectPickUp,plateKitchenObject.transform.position);
                                player.GetKitchenObjectFromParent().DestroySelf();
                            }
                        }
                    }
                }
                else
                {
                    GetKitchenObjectFromParent().SetKitchenObjectInParent(player);
                    _audioManagerModel.OnPlaySound?.Invoke(_audioManagerModel.ObjectPickUp, _clearCounterView.transform.position);
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
