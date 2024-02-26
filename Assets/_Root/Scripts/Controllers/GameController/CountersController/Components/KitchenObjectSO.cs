using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    [CreateAssetMenu(fileName = nameof(KitchenObjectSO), menuName = "Settings/ " + nameof(KitchenObjectSO))]
    public class KitchenObjectSO : ScriptableObject
    {
        [field: SerializeField] public Transform Prefab;
        [field: SerializeField] public Sprite Sprite;
        [field: SerializeField] public string ObjectName;
    }
}
