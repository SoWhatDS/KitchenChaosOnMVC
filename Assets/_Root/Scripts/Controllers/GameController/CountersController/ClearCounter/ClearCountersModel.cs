using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KitchenChaosMVC.Engine.Game.AudioController;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    [CreateAssetMenu(fileName = nameof(ClearCountersModel),menuName = "Settings/ " + nameof(ClearCountersModel))]
    public class ClearCountersModel : ScriptableObject
    {
        [field: SerializeField] public List<KitchenObjectSO> KitchenObjectSO { get; private set;}
        [field: SerializeField] public AudioManagerModel AudioManagerModel { get; private set; }

    }
}
