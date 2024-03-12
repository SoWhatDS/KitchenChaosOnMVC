using System.Collections;
using System.Collections.Generic;
using JoostenProductions;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    public class DeliveryCounterController : BaseController
    {
        private DeliveryCounterView[] _deliveryCounterView;
        private DeliveryCounterModel _deliveryCounterModel;

        private List<DeliveryCounter> _deliveryCountersList;

        public DeliveryCounterController(DeliveryCounterView[] deliveryCounterViews,DeliveryCounterModel deliveryCounterModel)
        {
            _deliveryCounterView = deliveryCounterViews;
            _deliveryCounterModel = deliveryCounterModel;

            _deliveryCountersList = new List<DeliveryCounter>();

            Initialize();

            UpdateManager.SubscribeToUpdate(Update);
        }

        private void Update()
        {
            for (int i = 0; i < _deliveryCountersList.Count; i++)
            {
                _deliveryCountersList[i].WaitingRecipeTimer();
            }
        }

        private void Initialize()
        {
            for (int i = 0; i < _deliveryCounterView.Length; i++)
            {
                DeliveryCounter deliveryCounter = new DeliveryCounter(_deliveryCounterView[i],_deliveryCounterModel);
                _deliveryCountersList.Add(deliveryCounter);
            }
        }

        protected override void OnDispose()
        {
            for (int i = 0; i < _deliveryCountersList.Count; i++)
            {
                _deliveryCountersList[i].Dispose();
                _deliveryCountersList.RemoveAt(i);
            }

            UpdateManager.UnsubscribeFromUpdate(Update);
        }
    }
}
