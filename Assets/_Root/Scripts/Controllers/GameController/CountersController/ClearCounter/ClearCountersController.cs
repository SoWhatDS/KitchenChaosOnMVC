using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    internal sealed class ClearCountersController : BaseController
    {
        private ClearCounterView[] _clearCountersViewArray;
        private ClearCountersModel _clearCountersModel;

        public ClearCountersController(ClearCounterView[] clearCounterViewArray,ClearCountersModel clearCountersModel)
        {
            _clearCountersViewArray = clearCounterViewArray;
            _clearCountersModel = clearCountersModel;
            Initialize();
        }

        private void Initialize()
        {
            for (int i = 0; i < _clearCountersViewArray.Length; i++)
            {
                ClearCounter clearCounter = new ClearCounter(_clearCountersViewArray[i],_clearCountersModel);
            }
        }

        protected override void OnDispose()
        {
           
        }
    }
}
