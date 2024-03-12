using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KitchenChaosMVC.Engine.Game.AudioController;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    [CreateAssetMenu(fileName = nameof(TrashCounterModel),menuName = "Settings/ " + nameof(TrashCounterModel))]
    public class TrashCounterModel : ScriptableObject
    {
        [field: SerializeField] public AudioManagerModel AudioManagerModel { get; private set; }
    }
}
