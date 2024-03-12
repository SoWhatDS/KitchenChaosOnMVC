using System.Collections;
using System.Collections.Generic;
using KitchenChaosMVC.Engine.Game.CountersControllers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace KitchenChaosMVC.Engine.Game.UIController
{
    public class RecipeSingleUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _recipeNameText;
        [SerializeField] private Transform _iconContainer;
        [SerializeField] private Transform _iconTemplate;

        private void Awake()
        {
            _iconTemplate.gameObject.SetActive(false);
        }

        public void SetRecipeText(RecipeSO recipeSO)
        {
            _recipeNameText.text = recipeSO.RecipeName;

            foreach (Transform child in _iconContainer)
            {
                if (child == _iconTemplate)
                {
                    continue;
                }

                Destroy(child.gameObject);
            }

            foreach (KitchenObjectSO kitchenObjectSO in recipeSO.KitchenObjectSOList)
            {
                Transform iconTransform = Instantiate(_iconTemplate, _iconContainer);
                iconTransform.gameObject.SetActive(true);
                iconTransform.GetComponent<Image>().sprite = kitchenObjectSO.Sprite;
            }
        }
    }
}
