using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    [CreateAssetMenu(fileName = nameof(RecipeSOList),menuName = "Settings/ " + nameof(RecipeSOList))]
    public class RecipeSOList : ScriptableObject
    {
        [field: SerializeField] public List<RecipeSO> DeliveryRecipeSOList { get; private set; }
    }
}
