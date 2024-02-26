using System.Collections;
using System.Collections.Generic;
using KitchenChaosMVC.Engine.Game.PlayerControllers;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    internal sealed class ContainerCounterView : MonoBehaviour, IBaseCounter
    {
        [field: SerializeField] public KitchenObjectSO KitchenObjectSO { get; private set; }
        [field: SerializeField] public SelectedCounter SelectedVisualPrefab { get; private set;}
        [field: SerializeField] public Transform CounterTopPoint { get; private set; }
        [field: SerializeField] public Animator Animator { get; private set;}

        private BaseCounter _baseCounter;

        public BaseCounter BaseCounter => _baseCounter;

        public void Init(BaseCounter baseCounter)
        {
            _baseCounter = baseCounter;
        }
    }
}
