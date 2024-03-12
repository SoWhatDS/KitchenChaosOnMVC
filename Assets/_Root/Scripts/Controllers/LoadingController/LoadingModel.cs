using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Loading
{
    [CreateAssetMenu(fileName = nameof(LoadingModel),menuName = "Settings/ " + nameof(LoadingModel))]
    public class LoadingModel : ScriptableObject
    {
        [field: SerializeField] public float TimerToLoading { get; private set; }
    }
}
