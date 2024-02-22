using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    [CreateAssetMenu(fileName = nameof(CountersModel),menuName = "Settings/ " + nameof(CountersModel))]
    public class CountersModel : ScriptableObject
    {
        [field: SerializeField] public ClearCountersModel ClearCountersModel;
    }
}
