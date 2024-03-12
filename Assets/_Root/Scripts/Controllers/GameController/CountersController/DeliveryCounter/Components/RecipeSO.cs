using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    [CreateAssetMenu(fileName = nameof(RecipeSO),menuName ="Settings/ " + nameof(RecipeSO))]
    public class RecipeSO : ScriptableObject
    {
        [field: SerializeField] public string RecipeName { get; private set; }
        [field: SerializeField] public List<KitchenObjectSO> KitchenObjectSOList { get; private set; }
    }
}
