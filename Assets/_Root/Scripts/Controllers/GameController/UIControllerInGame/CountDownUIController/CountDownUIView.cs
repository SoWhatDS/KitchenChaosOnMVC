using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.UIController
{
    public class CountDownUIView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timerText;

        public void Show(float timer)
        {
            _timerText.text = Mathf.Ceil(timer).ToString();
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
