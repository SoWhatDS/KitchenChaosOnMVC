using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    public class PlateCompleteVisual : MonoBehaviour
    {
        [Serializable]
        public struct KitchenObjectSO_GameObject
        {
            public KitchenObjectSO KitchenObjectSO;
            public GameObject VisualGameobject;
        }

        [SerializeField] private List<KitchenObjectSO_GameObject> _kitcheObjectsVisualList;
        [SerializeField] private PlateKitchenObject _plateKitchenObject;

        private void Start()
        {
            _plateKitchenObject.OnIngredientAdd += UpdateVisual;
            Hide();
            
        }

        private void UpdateVisual(KitchenObjectSO kitchenObjectSO)
        {
            for (int i = 0; i < _kitcheObjectsVisualList.Count; i++)
            {
                if (_kitcheObjectsVisualList[i].KitchenObjectSO == kitchenObjectSO)
                {
                    _kitcheObjectsVisualList[i].VisualGameobject.SetActive(true);
                }
            }
        }

        private void Hide()
        {
            for (int i = 0; i < _kitcheObjectsVisualList.Count; i++)
            {
                _kitcheObjectsVisualList[i].VisualGameobject.SetActive(false);
            }
        }
    }
}
