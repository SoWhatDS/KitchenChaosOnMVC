using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    public sealed class DeliveryManager 
    {
        private DeliveryCounterModel _deliveryCounterModel;

        private List<RecipeSO> _recipeSOList;
        private List<RecipeSO> _waitingDeliveryRecipes;

        private float _recipesInWaiting;
        private int _countDeliveredRecipes;

        public DeliveryManager(DeliveryCounterModel deliveryCounterModel)
        {
            _deliveryCounterModel = deliveryCounterModel;
            _countDeliveredRecipes = 0;

            _recipeSOList = deliveryCounterModel.DeliveryRecipe.DeliveryRecipeSOList;
            _waitingDeliveryRecipes = new List<RecipeSO>();

        }

        public void CreateNewWaitingRecipe()
        {
            if (_recipesInWaiting < _deliveryCounterModel.WaitingRecipeTimerMax)
            {
                _recipesInWaiting++;
                RecipeSO newRecipe = _recipeSOList[Random.Range(0, _recipeSOList.Count)];
                _waitingDeliveryRecipes.Add(newRecipe);
                _deliveryCounterModel.DeliveryManagerModel.OnRecipeSpawned?.Invoke(_waitingDeliveryRecipes);
            }
        }

        public void CheckCorrectDeliveryRecipe(PlateKitchenObject plateKitchenObject)
        {
            for (int i = 0; i < _waitingDeliveryRecipes.Count; i++)
            {
                RecipeSO waitingRecipeSO = _waitingDeliveryRecipes[i];

                if (waitingRecipeSO.KitchenObjectSOList.Count == plateKitchenObject.GetPlateKitchenObjectList().Count)
                {
                    bool plateContentsMatchesRecipe = true;

                    foreach (KitchenObjectSO recipeKitchenObjectSO in waitingRecipeSO.KitchenObjectSOList)
                    {
                        bool ingredientFound = false;

                        foreach (KitchenObjectSO plateKitchenObjectSO in plateKitchenObject.GetPlateKitchenObjectList())
                        {
                            if (plateKitchenObjectSO == recipeKitchenObjectSO)
                            {
                                ingredientFound = true;
                                break;
                            }
                        }

                        if (!ingredientFound)
                        {
                            plateContentsMatchesRecipe = false;
                        }
                    }

                    if (plateContentsMatchesRecipe)
                    {
                        _waitingDeliveryRecipes.RemoveAt(i);
                        _recipesInWaiting--;
                        _countDeliveredRecipes++;
                        _deliveryCounterModel.DeliveryManagerModel.OnRecipeComplete?.Invoke(_waitingDeliveryRecipes);
                        _deliveryCounterModel.AudioManagerModel.OnPlaySound?.Invoke(_deliveryCounterModel.AudioManagerModel.DeliverySuccess,plateKitchenObject.transform.position);
                        _deliveryCounterModel.GameOverUIModel.OnDeliveredRecipesCount?.Invoke(_countDeliveredRecipes);
                        plateKitchenObject.DestroySelf();
                        return;
                    }
                }

                _deliveryCounterModel.AudioManagerModel.OnPlaySound?.Invoke(_deliveryCounterModel.AudioManagerModel.DeliveryFail, plateKitchenObject.transform.position);
            }
        }
    }
}
