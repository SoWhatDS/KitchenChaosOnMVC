using System.Collections;
using System.Collections.Generic;
using KitchenChaosMVC.Engine.Game.CountersControllers;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.UIController
{
    public sealed class DeliveryManagerController : BaseController
    {
        private DeliveryManagerUIView _deliveryManagerUIView;
        private DeliveryManagerModel _deliveryManagerModel;

        public DeliveryManagerController(DeliveryManagerUIView deliveryManagerUIView,DeliveryManagerModel deliveryManagerModel)
        {
            _deliveryManagerUIView = deliveryManagerUIView;
            _deliveryManagerModel = deliveryManagerModel;

            _deliveryManagerUIView.TemplateRecipes.gameObject.SetActive(false);

            _deliveryManagerModel.OnRecipeComplete += UpdateVisual;
            _deliveryManagerModel.OnRecipeSpawned += UpdateVisual;

        }

        private void UpdateVisual(List<RecipeSO> waitingRecipeSOList)
        {
            foreach (Transform child in _deliveryManagerUIView.Container)
            {
                if (child == _deliveryManagerUIView.TemplateRecipes)
                {
                    continue;
                }

                Object.Destroy(child.gameObject);
            }

            foreach (RecipeSO recipeSO in waitingRecipeSOList)
            {
                Transform recipeTransform = Object.Instantiate(_deliveryManagerUIView.TemplateRecipes, _deliveryManagerUIView.Container);
                recipeTransform.GetComponent<RecipeSingleUI>().SetRecipeText(recipeSO);
                recipeTransform.gameObject.SetActive(true);
            }
        }

        protected override void OnDispose()
        {
            _deliveryManagerModel.OnRecipeComplete -= UpdateVisual;
            _deliveryManagerModel.OnRecipeSpawned -= UpdateVisual;
        }
    }
}
