using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    public class KitchenObject : MonoBehaviour
    {
        [SerializeField] private KitchenObjectSO _kitchenObjectSO;

        private IKitchenObjectParent _kitchenObjectParent;

        public KitchenObjectSO GetKitchenObjectSO()
        {
            return _kitchenObjectSO;
        }

        internal void SetKitchenObjectInParent(IKitchenObjectParent kitchenObjectParent)
        {
            if (_kitchenObjectParent != null)
            {
                _kitchenObjectParent.ClearKitchenObjectInParent();
            }

            _kitchenObjectParent = kitchenObjectParent;

            if (_kitchenObjectParent.HasKitchenObjectInParent())
            {
                Debug.LogError("Counter already has a kitchenObject!");
            }

            _kitchenObjectParent.SetKitchenObjectToParent(this);

            transform.parent = kitchenObjectParent.GetKitchenObjectFollowTransform();
            transform.localPosition = Vector3.zero;
        }

        internal IKitchenObjectParent GetClearCounter()
        {
            return _kitchenObjectParent;
        }

        public bool TryGetPlateKitchenObject(out PlateKitchenObject plateKitchenObject)
        {
            if (this is PlateKitchenObject)
            {
                plateKitchenObject = this as PlateKitchenObject;
                return true;
            }
            else
            {
                plateKitchenObject = null;
                return false;
            }
        }

        public void DestroySelf()
        {
            _kitchenObjectParent.ClearKitchenObjectInParent();
            Destroy(gameObject);
        }
    }
}
