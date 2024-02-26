using System;
using System.Collections;
using System.Collections.Generic;
using KitchenChaosMVC.Engine.Game.PlayerControllers;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    internal sealed class ClearCounterView : MonoBehaviour,IBaseCounter
    { 
        [field: SerializeField] public SelectedCounter SelectedVisualPrefab { get; private set; }
        [field: SerializeField] public Transform CounterTopPoint { get; private set; }

        public BaseCounter BaseCounter => _baseCounter;

        private BaseCounter _baseCounter;

        public void Init(BaseCounter baseCounter)
        {
            _baseCounter = baseCounter;
        }
    }
}
