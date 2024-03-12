using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    internal sealed class CountersView : MonoBehaviour
    {
        [field: SerializeField] public ClearCounterView[] ClearCountersView { get; private set; }
        [field: SerializeField] public ContainerCounterView[] ContainerCounterView { get; private set; }
        [field: SerializeField] public CuttingCounterView[] CuttingCounterView { get; private set; }
        [field: SerializeField] public TrashCounterView[] TrashCounterView { get; private set; }
        [field: SerializeField] public StoveCounterView[] StoveCounterViews { get; private set; }
        [field: SerializeField] public PlateCounterView[] PlateCounterView { get; private set; }
        [field: SerializeField] public DeliveryCounterView[] DeliveryCounterView { get; private set; }
    }
}
