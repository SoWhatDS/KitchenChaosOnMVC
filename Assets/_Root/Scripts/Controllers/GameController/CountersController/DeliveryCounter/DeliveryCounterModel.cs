using System.Collections;
using System.Collections.Generic;
using KitchenChaosMVC.Engine.Game.AudioController;
using KitchenChaosMVC.Engine.Game.UIController;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    [CreateAssetMenu(fileName = nameof(DeliveryCounterModel), menuName = "Settings/ " + nameof(DeliveryCounterModel))]
    public class DeliveryCounterModel : ScriptableObject
    {
        [field: SerializeField] public RecipeSOList DeliveryRecipe { get; private set; }
        [field: SerializeField] public float WaitingRecipeTimerMax { get; private set; }
        [field: SerializeField] public int MaxRecipeInWaiting { get; private set; }
        [field: SerializeField] public DeliveryManagerModel DeliveryManagerModel { get; private set; }
        [field: SerializeField] public AudioManagerModel AudioManagerModel { get; private set; }
        [field: SerializeField] public GameOverUIModel GameOverUIModel { get; set; }
        
    }
}
