using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    public class TrashCounterView : MonoBehaviour,IBaseCounter
    {
        [field: SerializeField] public Transform CounterTopTransform;
        [field: SerializeField] public SelectedCounter SelectedVisualPrefab;

        private BaseCounter _baseCounter;

        public BaseCounter BaseCounter => _baseCounter;

        public void Init(BaseCounter baseCounter)
        {
            _baseCounter = baseCounter;
        }
    }
}
