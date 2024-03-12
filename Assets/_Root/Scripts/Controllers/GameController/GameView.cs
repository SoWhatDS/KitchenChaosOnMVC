using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KitchenChaosMVC.Engine.Game
{
    public sealed class GameView : MonoBehaviour
    {
        [SerializeField] private Image _clockImage;

        public void UpdateClockImage(float timer,float maxTimer)
        {
            _clockImage.fillAmount = 1 - timer / maxTimer;
        }
    }
}
