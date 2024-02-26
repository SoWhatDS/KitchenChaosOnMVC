using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    [CreateAssetMenu(fileName = nameof(KitchenObjectsRecipeSO),menuName = "Settings/ " + nameof(KitchenObjectsRecipeSO))]
    public class KitchenObjectsRecipeSO : ScriptableObject
    {
        [field: SerializeField] public KitchenObjectSO Input { get; private set; }
        [field: SerializeField] public KitchenObjectSO Output { get; private set; }
        [field: SerializeField] public int CuttingProgressMax { get; private set; }
    }
}
