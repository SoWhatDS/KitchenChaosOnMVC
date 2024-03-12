using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KitchenChaosMVC.Engine.Game.AudioController;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    [CreateAssetMenu(fileName = nameof(PlateCounterModel),menuName = "Settings/ " + nameof(PlateCounterModel))]
    public class PlateCounterModel : ScriptableObject
    {
        [field: SerializeField] public float PlateAmountMax { get; private set; }
        [field: SerializeField] public int PlateInstantiateTimer { get; private set; }
        [field: SerializeField] public KitchenObjectSO KitchenObjectPlate { get; private set; }
        [field: SerializeField] public AudioManagerModel AudioManagerModel { get; private set; }
    }
}
