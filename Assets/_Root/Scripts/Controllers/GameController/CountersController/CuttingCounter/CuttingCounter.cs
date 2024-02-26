using System;
using System.Collections;
using System.Collections.Generic;
using KitchenChaosMVC.Engine.Game.PlayerControllers;
using UnityEngine;
using Object = UnityEngine.Object;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    public sealed class CuttingCounter : BaseCounter
    {
        public Action<float> OnProgressChanged;

        private CuttingCounterView _cuttingCounterView;
        private CuttingCounterModel _cuttingCounterModel;
        private KitchenObjectsRecipeSO[] _kitchenObjectsRecipeSOArray;

        private float _cuttingProgress;
        private bool _isOutputKitchenObjectInstantiate;

        public CuttingCounter(CuttingCounterView cuttingCounterView,CuttingCounterModel cuttingCounterModel)
        {
            _cuttingCounterView = cuttingCounterView;
            _cuttingCounterModel = cuttingCounterModel;
            _kitchenObjectsRecipeSOArray = cuttingCounterModel.KitchenObjectsRecipeSOArray;

            CounterTopPoint = _cuttingCounterView.CounterTopPoint;
            SelectedCounter = _cuttingCounterView.SelectedVisualPrefab;

            _cuttingCounterView.Init(this);

            _cuttingCounterView.SelectedVisualPrefab.Hide();
            _cuttingCounterView.BarProgressUI.Hide();

            OnInteract += Interact;
            IsSelected += ShowSelectedVisualEffect;
            OnInteractAlternate += InteractAlternate;
            OnProgressChanged += _cuttingCounterView.BarProgressUI.ShowVisualBarProgressUI;
        }

        protected override void Interact(Player player)
        {
            _isOutputKitchenObjectInstantiate = false;
            if (!HasKitchenObjectInParent())
            {
                if (player.HasKitchenObjectInParent() && HasKitchenObjectSOInRecipe(player.GetKitchenObjectFromParent().GetKitchenObjectSO()))
                {
                    player.GetKitchenObjectFromParent().SetKitchenObjectInParent(this);
                    _cuttingProgress = 0f;
                }
                else
                {
                    // not have kitchen object in player!!!
                }
            }
            else
            {
                if (!player.HasKitchenObjectInParent())
                {
                    GetKitchenObjectFromParent().SetKitchenObjectInParent(player);
                }
                else
                {
                    //not have kitchen object in counter!!!
                }
            }
        }

        protected override void InteractAlternate(Player player)
        {
            if (HasKitchenObjectInParent() && HasKitchenObjectSOInRecipe(GetKitchenObjectFromParent().GetKitchenObjectSO()))
            {
                _cuttingProgress++;

                KitchenObjectsRecipeSO kitchenObjectsRecipeSO = GetKitchenObjectRecipeSOFromInput(GetKitchenObjectFromParent().GetKitchenObjectSO());

                float cuttingProgressNormalized = (float)_cuttingProgress / kitchenObjectsRecipeSO.CuttingProgressMax;
                OnProgressChanged?.Invoke(cuttingProgressNormalized);

                if (_cuttingProgress >= kitchenObjectsRecipeSO.CuttingProgressMax)
                {
                    if (!_isOutputKitchenObjectInstantiate)
                    {
                        _isOutputKitchenObjectInstantiate = true;
                        KitchenObjectSO kitchenObjectOutput = GetOutputFromInput(GetKitchenObjectFromParent().GetKitchenObjectSO());
                        Debug.Log(kitchenObjectOutput);
                        GetKitchenObjectFromParent().DestroySelf();

                        //PoolObject!!!!
                        Transform kitchenObjectTransform = Object.Instantiate(kitchenObjectOutput.Prefab);
                        kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectInParent(this);
                    }
                    
                }
                
            }
        }

        private bool HasKitchenObjectSOInRecipe(KitchenObjectSO inputKitchenObjectSO)
        {
            KitchenObjectsRecipeSO kitchenObjectsRecipeSO = GetKitchenObjectRecipeSOFromInput(inputKitchenObjectSO);
            return kitchenObjectsRecipeSO != null;
        }

        private KitchenObjectSO GetOutputFromInput(KitchenObjectSO inputKitchenObjectSO)
        {
            KitchenObjectsRecipeSO kitchenObjectsRecipeSO = GetKitchenObjectRecipeSOFromInput(inputKitchenObjectSO);

            if (kitchenObjectsRecipeSO != null)
            {
                return kitchenObjectsRecipeSO.Output;
            }
            else
            {
                return null;
            }
        }

        private KitchenObjectsRecipeSO GetKitchenObjectRecipeSOFromInput(KitchenObjectSO inputKitchenObjectSO)
        {
            for (int i = 0; i < _kitchenObjectsRecipeSOArray.Length; i++)
            {
                if (_kitchenObjectsRecipeSOArray[i].Input == inputKitchenObjectSO)
                {
                    return _kitchenObjectsRecipeSOArray[i];
                }
            }
            return null;
        }

        public void Dispose()
        {
            OnInteract -= Interact;
            IsSelected -= ShowSelectedVisualEffect;
            OnInteractAlternate -= InteractAlternate;
            OnProgressChanged -= _cuttingCounterView.BarProgressUI.ShowVisualBarProgressUI;
        }
    }
}
