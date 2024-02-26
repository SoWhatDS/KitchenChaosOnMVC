using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    [CreateAssetMenu(fileName = nameof(KitchenObjectFryingRecipeSO),menuName = "Settings/ " + nameof(KitchenObjectFryingRecipeSO))]
    public class KitchenObjectFryingRecipeSO : ScriptableObject
    {
        [field: SerializeField] public KitchenObjectSO Input { get; private set; }
        [field: SerializeField] public KitchenObjectSO Output { get; private set; }
        [field: SerializeField] public float FryingTimeMax { get; private set; }
    }
}
