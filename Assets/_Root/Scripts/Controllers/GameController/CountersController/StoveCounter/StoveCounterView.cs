using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    public class StoveCounterView : MonoBehaviour, IBaseCounter
    {
        [field: SerializeField] public Transform CounterTopPoint { get; private set; }
        [field: SerializeField] public SelectedCounter SelectedCounter { get; private set; }
        [field: SerializeField] public GameObject ParticlesPrefab { get; private set; }
        [field: SerializeField] public GameObject VisualEffectPrefab { get; private set; }
        [field: SerializeField] public BarProgressUI BarProgressUI { get; private set; }

        private BaseCounter _baseCounter;

        public BaseCounter BaseCounter => _baseCounter;


        public void Init(BaseCounter baseCounter)
        {
            _baseCounter = baseCounter;
        }
    }
}
