using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.UIController
{
    [CreateAssetMenu(fileName = nameof(CountDownUIModel),menuName = "Settings/ " + nameof(CountDownUIModel))]
    public class CountDownUIModel : ScriptableObject
    {
        public Action<float> OnCountDownTimer;
        public Action OnStartPlaying;

    }
}
