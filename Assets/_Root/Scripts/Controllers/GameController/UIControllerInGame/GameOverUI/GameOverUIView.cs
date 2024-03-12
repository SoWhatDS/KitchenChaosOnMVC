using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.UIController
{
    public class GameOverUIView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _deliveredCountRecipesText;

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void UpdateDeliveredRecipesText(int countDeliveredRecipes)
        {
            _deliveredCountRecipesText.text = countDeliveredRecipes.ToString();
        }
    }
}
