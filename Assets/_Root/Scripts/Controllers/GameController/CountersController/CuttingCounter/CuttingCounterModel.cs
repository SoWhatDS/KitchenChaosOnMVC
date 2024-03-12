using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KitchenChaosMVC.Engine.Game.AudioController;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    [CreateAssetMenu(fileName = nameof(CuttingCounterModel),menuName = "Settings/ " + nameof(CuttingCounterModel))]
    public class CuttingCounterModel : ScriptableObject
    {
        [field: SerializeField] public KitchenObjectsRecipeSO[] KitchenObjectsRecipeSOArray { get; private set; }
        [field: SerializeField] public AudioManagerModel AudioManagerModel { get; private set; }
    }
}
