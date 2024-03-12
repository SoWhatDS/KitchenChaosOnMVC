using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    [CreateAssetMenu(fileName = nameof(CountersModel),menuName = "Settings/ " + nameof(CountersModel))]
    public class CountersModel : ScriptableObject
    {
        [field: SerializeField] public ClearCountersModel ClearCountersModel { get; private set; }
        [field: SerializeField] public ContainerCounterModel ContainerCounterModel { get; private set; }
        [field: SerializeField] public CuttingCounterModel CuttingCounterModel { get; private set; }
        [field: SerializeField] public StoveCounterModel StoveCounterModel { get; private set; }
        [field: SerializeField] public PlateCounterModel PlateCounterModel { get; private set; }
        [field: SerializeField] public DeliveryCounterModel DeliveryCounterModel { get; private set; }
        [field: SerializeField] public TrashCounterModel TrashCounterModel { get; private set; }
    }
}
