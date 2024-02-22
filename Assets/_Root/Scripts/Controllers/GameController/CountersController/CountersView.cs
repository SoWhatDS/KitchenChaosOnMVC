using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    internal sealed class CountersView : MonoBehaviour
    {
        [field: SerializeField] public ClearCounterView[] ClearCountersView { get; private set; }
    }
}
