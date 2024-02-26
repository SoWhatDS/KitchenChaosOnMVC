using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    [CreateAssetMenu(fileName = nameof(CuttingCounterModel),menuName = "Settings/ " + nameof(CuttingCounterModel))]
    public class CuttingCounterModel : ScriptableObject
    {
        [field: SerializeField] public KitchenObjectsRecipeSO[] KitchenObjectsRecipeSOArray { get; private set; }
    }
}
