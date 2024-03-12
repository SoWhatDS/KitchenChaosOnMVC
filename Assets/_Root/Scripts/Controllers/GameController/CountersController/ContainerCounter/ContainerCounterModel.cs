using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KitchenChaosMVC.Engine.Game.AudioController;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    [CreateAssetMenu(fileName = nameof(ContainerCounterModel), menuName = "Settings/ " + nameof(ContainerCounterModel))]
    public class ContainerCounterModel : ScriptableObject
    {
        [field: SerializeField] public AudioManagerModel AudioManagerModel { get; private set; }
    }
}
