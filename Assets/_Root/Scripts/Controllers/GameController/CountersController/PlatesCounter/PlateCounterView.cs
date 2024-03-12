using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    public class PlateCounterView : MonoBehaviour, IBaseCounter
    {
        [field: SerializeField] public Transform CounterTopPoint { get; private set; }
        [field: SerializeField] public SelectedCounter SelectedCounter { get; private set; }
        [field: SerializeField] public GameObject VisualPlatePrefab { get; private set; }

        public BaseCounter BaseCounter => _baseCounter;

        private BaseCounter _baseCounter;

        public void Init(BaseCounter baseCounter)
        {
            _baseCounter = baseCounter;
        }
    }
}
