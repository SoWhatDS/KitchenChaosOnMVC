using System.Collections;
using System.Collections.Generic;
using JoostenProductions;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    public class PlateCounterController : BaseController
    {
        private PlateCounterView[] _plateCounterView;
        private PlateCounterModel _plateCounterModel;

        private List<PlateCounter> _platesCounterList;

        public PlateCounterController(PlateCounterView[] plateCounterView,PlateCounterModel plateCounterModel)
        {
            _plateCounterView = plateCounterView;
            _plateCounterModel = plateCounterModel;

            _platesCounterList = new List<PlateCounter>();
            Initialize();

            UpdateManager.SubscribeToUpdate(Update);
        }

        private void Update()
        {
            for (int i = 0; i < _plateCounterView.Length; i++)
            {
                _platesCounterList[i].TimerSpawnPlate();
            }
        }

        private void Initialize()
        {
            for (int i = 0; i < _plateCounterView.Length; i++)
            {
                PlateCounter plateCounter = new PlateCounter(_plateCounterView[i], _plateCounterModel);
                _platesCounterList.Add(plateCounter);
            }
        }

        protected override void OnDispose()
        {
            UpdateManager.UnsubscribeFromUpdate(Update);

            for (int i = 0; i < _platesCounterList.Count; i++)
            {
                _platesCounterList[i].Dispose();
                _platesCounterList.RemoveAt(i);
            }
        }
    }
}
