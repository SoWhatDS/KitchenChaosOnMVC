using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    [CreateAssetMenu(fileName = nameof(KitchenObjectBurnedRecipeSO), menuName = "Settings/ " + nameof(KitchenObjectBurnedRecipeSO))]
    public class KitchenObjectBurnedRecipeSO : ScriptableObject
    {
        [field: SerializeField] public KitchenObjectSO Input { get; private set; }
        [field: SerializeField] public KitchenObjectSO Output { get; private set; }
        [field: SerializeField] public float BurnedTimeMax { get; private set; }
    }
}
