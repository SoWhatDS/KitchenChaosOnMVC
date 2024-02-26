using System.Collections;
using System.Collections.Generic;
using KitchenChaosMVC.Engine.Game.PlayerControllers;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    public class TrashCounter : BaseCounter
    {
        private TrashCounterView _trashCounterView;

        public TrashCounter(TrashCounterView trashCounterView)
        {
            _trashCounterView = trashCounterView;
            CounterTopPoint = _trashCounterView.CounterTopTransform;
            SelectedCounter = _trashCounterView.SelectedVisualPrefab;

            _trashCounterView.Init(this);

            OnInteract += Interact;
            IsSelected += ShowSelectedVisualEffect;
        }

        protected override void Interact(Player player)
        {
            if (player.HasKitchenObjectInParent())
            {
                player.GetKitchenObjectFromParent().DestroySelf();
            }
        }

        public void Dispose()
        {
            OnInteract -= Interact;
            IsSelected -= ShowSelectedVisualEffect;
        }
        
    }
}
