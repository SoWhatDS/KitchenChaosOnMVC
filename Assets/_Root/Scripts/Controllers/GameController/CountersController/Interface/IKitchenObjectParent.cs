using System.Collections;
using System.Collections.Generic;
using KitchenChaosMVC.Engine.Game.CountersControllers;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game
{
    public interface IKitchenObjectParent 
    {
        public bool HasKitchenObjectInParent();


        public void SetKitchenObjectToParent(KitchenObject kitchenObject);


        public KitchenObject GetKitchenObjectFromParent();


        public void ClearKitchenObjectInParent();

        public Transform GetKitchenObjectFollowTransform();

    }
}
