using System.Collections;
using System.Collections.Generic;
using KitchenChaosMVC.Engine.Game.PlayerControllers;
using KitchenChaosMVC.Utils;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    internal sealed class ContainerCounter : BaseCounter
    {
        private ContainerCounterModel _containerCounterModel;
        private ContainerCounterView _containerCounterView;
        private CountersAnimations _countersAnimation;

        internal ContainerCounter(ContainerCounterView containerCounterView, ContainerCounterModel containerCounterModel)
        {
            _containerCounterView = containerCounterView;
            _containerCounterModel = containerCounterModel;

            CounterTopPoint = _containerCounterView.CounterTopPoint;
            SelectedCounter = _containerCounterView.SelectedVisualPrefab;

            _containerCounterView.Init(this);

            _containerCounterView.SelectedVisualPrefab.Hide();

            OnInteract += Interact;
            IsSelected += ShowSelectedVisualEffect;

            _countersAnimation = new CountersAnimations(_containerCounterView.Animator);
        }

        protected override void Interact(Player player)
        {
            if (!player.HasKitchenObjectInParent())
            {
                Transform kitchenObjectTransform = Object.Instantiate(_containerCounterView.KitchenObjectSO.Prefab);
                kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectInParent(player);
                _countersAnimation.PlayAnimationsTrigger(GameConstantsAnimation.OPEN_CLOSE_TRIGGER);
            }
        }

        public void Dispose()
        {
            OnInteract -= Interact;
            IsSelected -= ShowSelectedVisualEffect;
        }
    }
}
