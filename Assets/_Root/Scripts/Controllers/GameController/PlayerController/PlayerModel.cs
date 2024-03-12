using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KitchenChaosMVC.Engine.Game.AudioController;

namespace KitchenChaosMVC.Engine.Game.PlayerControllers
{
    [CreateAssetMenu(fileName = nameof(PlayerModel),menuName ="Settings/ " + nameof(PlayerModel))]
    public class PlayerModel : ScriptableObject
    {
        [field: SerializeField] public float MoveSpeed { get; private set; }
        [field: SerializeField] public float RotateSpeed { get; private set; }
        [field: SerializeField] public LayerMask CounterLayerMask { get; private set; }
        [field: SerializeField] public AudioManagerModel AudioManagerModel { get; private set; }
    }
}
