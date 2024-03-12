using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    public sealed class PlateKitchenObject : KitchenObject
    {
        public Action<KitchenObjectSO> OnIngredientAdd;
        public Action OnUpdateVisualPlate;

        [SerializeField] private List<KitchenObjectSO> _validKitchenObjecList;

        private List<KitchenObjectSO> _kitchenObjectSOList;

        private void Awake()
        {
            _kitchenObjectSOList = new List<KitchenObjectSO>();
        }

        public bool TryAddIngredients(KitchenObjectSO kitchenObjectSO)
        {
            if (_validKitchenObjecList.Contains(kitchenObjectSO))
            {
                if (_kitchenObjectSOList.Contains(kitchenObjectSO))
                {
                    return false;
                 
                }
                else
                {
                    _kitchenObjectSOList.Add(kitchenObjectSO);
                    OnIngredientAdd?.Invoke(kitchenObjectSO);
                    OnUpdateVisualPlate?.Invoke();
                    return true;
                }
            }
            else
            {
                return false;
            }
            
        }

        public List<KitchenObjectSO> GetPlateKitchenObjectList()
        {
            return _kitchenObjectSOList;
        }
    }
}
