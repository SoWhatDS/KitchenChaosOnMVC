using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    internal sealed class ClearCounterView : MonoBehaviour
    {
        public Action<bool> IsSelectedCounter;

        [field: SerializeField] public SelectedCounter SelectedVisualPrefab { get; private set;}

        public void Interact()
        {
            Debug.Log("Interact counter");
        }
    }
}
