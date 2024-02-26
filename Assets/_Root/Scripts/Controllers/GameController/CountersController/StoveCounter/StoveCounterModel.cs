using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    [CreateAssetMenu(fileName = nameof(StoveCounterModel),menuName = "Settings/ " + nameof(StoveCounterModel))]
    public class StoveCounterModel : ScriptableObject
    {
        [field: SerializeField] public KitchenObjectFryingRecipeSO[] KitchenObjectFryingRecipeSOArray { get; private set; }
        [field: SerializeField] public KitchenObjectBurnedRecipeSO[] KitchenObjectBurnedRecipeSOArray { get; private set; }
    }
}
