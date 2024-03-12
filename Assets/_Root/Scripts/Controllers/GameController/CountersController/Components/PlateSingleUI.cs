using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    public class PlateSingleUI : MonoBehaviour
    {
        [SerializeField] private Image _iconImage;

        public void ChangeSprite(KitchenObjectSO kitchenObjectSO)
        {
            _iconImage.sprite = kitchenObjectSO.Sprite;
        }
    }
}
