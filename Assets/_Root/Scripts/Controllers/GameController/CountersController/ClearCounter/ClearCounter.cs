using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    internal sealed class ClearCounter 
    {
        private ClearCounterView _clearCounterView;
        private ClearCountersModel _clearCounterModel;

        public ClearCounter(ClearCounterView clearCounterView,ClearCountersModel clearCounterModel)
        {
            _clearCounterView = clearCounterView;
            _clearCounterModel = clearCounterModel;
            _clearCounterView.IsSelectedCounter += ShowSelectedVisualEffect;
            _clearCounterView.SelectedVisualPrefab.Hide();
        }

        public void ShowSelectedVisualEffect(bool isSelected)
        {
            if (isSelected)
            {
                _clearCounterView.SelectedVisualPrefab.Show();
            }
            else
            {
                _clearCounterView.SelectedVisualPrefab.Hide();
            }
        }
    }
}
