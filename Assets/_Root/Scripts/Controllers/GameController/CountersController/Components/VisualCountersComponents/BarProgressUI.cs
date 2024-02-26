using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    public class BarProgressUI : MonoBehaviour
    {
        [field: SerializeField] public Image _barImage { get; private set; }

        public void ShowVisualBarProgressUI(float progressNormalized)
        {
            _barImage.fillAmount = progressNormalized;
            if (_barImage.fillAmount == 0f || _barImage.fillAmount >= 1f)
            {
                Hide();
            }
            else
            {
                Show();
            }
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
