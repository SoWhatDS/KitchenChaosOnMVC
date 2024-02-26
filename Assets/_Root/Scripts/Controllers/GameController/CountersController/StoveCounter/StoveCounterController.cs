using System.Collections;
using System.Collections.Generic;
using JoostenProductions;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    public sealed class StoveCounterController : BaseController
    {
        private StoveCounterView[] _stoveCounterViewArray;
        private StoveCounterModel _stoveCounterModel;

        private List<StoveCounter> _stoveCounterList;

        public StoveCounterController(StoveCounterView[] stoveCounterViewsArray,StoveCounterModel stoveCounterModel)
        {
            _stoveCounterViewArray = stoveCounterViewsArray;
            _stoveCounterModel = stoveCounterModel;

            _stoveCounterList = new List<StoveCounter>();
            Initialize();
            UpdateManager.SubscribeToUpdate(Update);
        }

        private void Update()
        {
            for (int i = 0; i < _stoveCounterViewArray.Length; i++)
            {
                _stoveCounterList[i].FriyngWithTimerInUpdate();
            }
        }

        private void Initialize()
        {
            for (int i = 0; i < _stoveCounterViewArray.Length; i++)
            {
                StoveCounter stoveCounter = new StoveCounter(_stoveCounterViewArray[i],_stoveCounterModel);
                _stoveCounterList.Add(stoveCounter);
            }
        }

        protected override void OnDispose()
        {
            UpdateManager.UnsubscribeFromUpdate(Update);

            for (int i = 0; i < _stoveCounterList.Count; i++)
            {
                _stoveCounterList[i].Dispose();
                _stoveCounterList.RemoveAt(i);
            }
        }
    }
}
