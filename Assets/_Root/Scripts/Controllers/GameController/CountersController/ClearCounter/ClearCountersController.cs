using System.Collections;
using System.Collections.Generic;
using JoostenProductions;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    internal sealed class ClearCountersController : BaseController
    {
        private ClearCounterView[] _clearCountersViewArray;
        private ClearCountersModel _clearCountersModel;

        private List<ClearCounter> _clearContersList;

        public ClearCountersController(ClearCounterView[] clearCounterViewArray,ClearCountersModel clearCountersModel)
        {
            _clearCountersViewArray = clearCounterViewArray;
            _clearCountersModel = clearCountersModel;
            _clearContersList = new List<ClearCounter>();
            Initialize();
        }

        private void Initialize()
        {
            for (int i = 0; i < _clearCountersViewArray.Length; i++)
            {
                ClearCounter clearCounter = new ClearCounter(_clearCountersViewArray[i],_clearCountersModel);
                _clearContersList.Add(clearCounter);
            }
        }

        protected override void OnDispose()
        {
            for (int i = 0; i < _clearContersList.Count; i++)
            {
                _clearContersList[i].Dispose();
                _clearContersList.RemoveAt(i);
            }
        }
    }
}
