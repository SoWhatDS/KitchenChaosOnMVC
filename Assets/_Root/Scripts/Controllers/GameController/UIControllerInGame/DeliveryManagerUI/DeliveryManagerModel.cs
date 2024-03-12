using System;
using System.Collections;
using System.Collections.Generic;
using KitchenChaosMVC.Engine.Game.CountersControllers;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.UIController
{
    [CreateAssetMenu(fileName = nameof(DeliveryManagerModel),menuName = "SettingsUI/ " + nameof(DeliveryManagerModel))]
    public class DeliveryManagerModel : ScriptableObject
    {
        public Action<List<RecipeSO>> OnRecipeComplete;
        public Action<List<RecipeSO>> OnRecipeSpawned;
    }
}
