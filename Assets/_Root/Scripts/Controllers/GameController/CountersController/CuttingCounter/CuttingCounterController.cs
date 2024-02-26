using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    public class CuttingCounterController : BaseController
    {
        private CuttingCounterView[] _cuttingCounterView;
        private CuttingCounterModel _cuttingCounterModel;

        private List<CuttingCounter> _cuttingCountersList;

        public CuttingCounterController(CuttingCounterView[] cuttingCounterViews,CuttingCounterModel cuttingCounterModel)
        {
            _cuttingCounterView = cuttingCounterViews;
            _cuttingCounterModel = cuttingCounterModel;
            _cuttingCountersList = new List<CuttingCounter>();
            Initialize();
        }

        private void Initialize()
        {
            for (int i = 0; i < _cuttingCounterView.Length; i++)
            {
                CuttingCounter cuttingCounter = new CuttingCounter(_cuttingCounterView[i], _cuttingCounterModel);
                _cuttingCountersList.Add(cuttingCounter);
            }
        }

        protected override void OnDispose()
        {
            for (int i = 0; i < _cuttingCountersList.Count; i++)
            {
                _cuttingCountersList[i].Dispose();
                _cuttingCountersList.RemoveAt(i);
            }
        }
    }
}
