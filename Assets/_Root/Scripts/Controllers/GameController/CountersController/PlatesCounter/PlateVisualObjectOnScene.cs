using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    public sealed class PlateVisualObjectOnScene 
    {
        private PlateCounterView _plateCounterView;
        private List<GameObject> _plateVisualPrefbsOnSceneList;
        private float _offsetY = 0.1f;

        public PlateVisualObjectOnScene(PlateCounterView plateCounterView)
        {
            _plateCounterView = plateCounterView;
            _plateVisualPrefbsOnSceneList = new List<GameObject>();
        }

        public void PlateSpawned()
        {
            GameObject plateVisualObject = Object.Instantiate(_plateCounterView.VisualPlatePrefab, _plateCounterView.CounterTopPoint);
            plateVisualObject.transform.localPosition = new Vector3(0, _offsetY * _plateVisualPrefbsOnSceneList.Count, 0);

            _plateVisualPrefbsOnSceneList.Add(plateVisualObject);
        }

        public void PlateRemoved()
        {
            GameObject plateVisualObject = _plateVisualPrefbsOnSceneList[_plateVisualPrefbsOnSceneList.Count - 1];
            _plateVisualPrefbsOnSceneList.Remove(plateVisualObject);
            Object.Destroy(plateVisualObject);
        }

        public void Dispose()
        {
            for (int i = 0; i < _plateVisualPrefbsOnSceneList.Count; i++)
            {
                Object.Destroy(_plateVisualPrefbsOnSceneList[i]);
                _plateVisualPrefbsOnSceneList.RemoveAt(i);
            }
        }
    }
}
