using System.Collections;
using System.Collections.Generic;
using KitchenChaosMVC.Engine.Game.AudioController;
using KitchenChaosMVC.Engine.Game.PlayerControllers;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    public class TrashCounter : BaseCounter
    {
        private TrashCounterView _trashCounterView;
        private TrashCounterModel _trashCounterModel;
        private AudioManagerModel _audioManagerModel;

        public TrashCounter(TrashCounterView trashCounterView,TrashCounterModel trashCounterModel)
        {
            _trashCounterView = trashCounterView;
            _trashCounterModel = trashCounterModel;
            _audioManagerModel = _trashCounterModel.AudioManagerModel;

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
                _audioManagerModel.OnPlaySound?.Invoke(_audioManagerModel.Trash,_trashCounterView.transform.position);
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
