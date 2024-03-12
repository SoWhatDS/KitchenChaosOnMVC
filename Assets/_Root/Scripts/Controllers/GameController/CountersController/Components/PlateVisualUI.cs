using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    public class PlateVisualUI : MonoBehaviour
    {
        [SerializeField] private PlateKitchenObject _plateKitchenObject;
        [SerializeField] private Transform _iconTemplate;
        

        private List<KitchenObjectSO> _kitchenObjectSOOnPlateList;

        private void Start()
        {
            _plateKitchenObject.OnUpdateVisualPlate += UpdateVisual;
            _kitchenObjectSOOnPlateList = _plateKitchenObject.GetPlateKitchenObjectList();
            _iconTemplate.gameObject.SetActive(false);
        }

        private void UpdateVisual()
        {
            foreach (Transform child in transform)
            {
                if (child == _iconTemplate) continue;
                Destroy(child.gameObject);
            }

            for (int i = 0; i < _kitchenObjectSOOnPlateList.Count; i++)
            {
                Transform iconTransform = Instantiate(_iconTemplate, transform);
                iconTransform.gameObject.SetActive(true);
                iconTransform.GetComponent<PlateSingleUI>().ChangeSprite(_kitchenObjectSOOnPlateList[i]);
            }
        }
    }
}
