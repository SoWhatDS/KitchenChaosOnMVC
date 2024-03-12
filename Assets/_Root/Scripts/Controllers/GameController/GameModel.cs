using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game
{
    [CreateAssetMenu(fileName = nameof(GameModel),menuName = "Settings/ " + nameof(GameModel))]
    public class GameModel : ScriptableObject
    {
        [field: SerializeField] public float CountDownTimer { get; set; }
        [field: SerializeField] public float TimerMaxPlaying { get; private set; }
    }
}
