using System;
using System.Collections;
using System.Collections.Generic;
using KitchenChaosMVC.Engine.Game.PlayerControllers;
using UnityEngine;
using Object = UnityEngine.Object;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    public class StoveCounter : BaseCounter
    {
        private Action<State> OnStateChanged;

        private enum State
        {
            Idle,
            Frying,
            Fried,
            Burned
        }

        private State _state;

        private StoveCounterView _stoveCounterView;
        private StoveCounterModel _stoveCounterModel;

        private KitchenObjectFryingRecipeSO[] _kitchenObjectFryingRecipeSOArray;
        private KitchenObjectBurnedRecipeSO[] _kitchenObjectBurnedRecipeSOArray;

        private KitchenObjectFryingRecipeSO _kitchenObjectFryingRecipeSO;
        private KitchenObjectBurnedRecipeSO _kitchenObjectBurnedRecipeSO;

        private float _fryingTimer;
        private float _burnedTimer;
        private bool _isFrying;


        public StoveCounter(StoveCounterView stoveCounterView,StoveCounterModel stoveCounterModel)
        {
            _stoveCounterView = stoveCounterView;
            _stoveCounterModel = stoveCounterModel;

            _kitchenObjectFryingRecipeSOArray = _stoveCounterModel.KitchenObjectFryingRecipeSOArray;
            _kitchenObjectBurnedRecipeSOArray = _stoveCounterModel.KitchenObjectBurnedRecipeSOArray;

            _stoveCounterView.Init(this);
            _stoveCounterView.SelectedCounter.Hide();
            

            SelectedCounter = _stoveCounterView.SelectedCounter;
            CounterTopPoint = _stoveCounterView.CounterTopPoint;

            _state = State.Idle;

            OnInteract += Interact;
            IsSelected += ShowSelectedVisualEffect;
            OnStateChanged += ShowVisualEffectAndParticles;
            
        }

        public void FriyngWithTimerInUpdate()
        {
            
            if (HasKitchenObjectInParent() && _isFrying)
            {
                switch (_state)
                {
                    case State.Idle:                    
                        break;
                    case State.Frying:

                        _fryingTimer += Time.deltaTime;                     
                        _kitchenObjectFryingRecipeSO = GetKitchenObjectFryingRecipeSOFromInput(GetKitchenObjectFromParent().GetKitchenObjectSO());

                        if (_fryingTimer >= _kitchenObjectFryingRecipeSO.FryingTimeMax)
                        {
                            GetKitchenObjectFromParent().DestroySelf();

                            _fryingTimer = 0f;

                            //PoolObject
                            Transform kitchenObjectTransform = Object.Instantiate(_kitchenObjectFryingRecipeSO.Output.Prefab);
                            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectInParent(this);
                            _state = State.Fried;
                            OnStateChanged?.Invoke(_state);
                        }
                        break;
                    case State.Fried:

                        _burnedTimer += Time.deltaTime;

                        _kitchenObjectBurnedRecipeSO = GetKitchenObjectBurnedRecipeSOFromInput(GetKitchenObjectFromParent().GetKitchenObjectSO());

                        if (_burnedTimer >= _kitchenObjectBurnedRecipeSO.BurnedTimeMax)
                        {
                            GetKitchenObjectFromParent().DestroySelf();

                            _burnedTimer = 0f;

                            //PoolObject
                            Transform kitchenObjectTransform = Object.Instantiate(_kitchenObjectBurnedRecipeSO.Output.Prefab);
                            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectInParent(this);
                            _state = State.Burned;
                            OnStateChanged?.Invoke(_state);
                        }
                        break;
                    case State.Burned:
                        _isFrying = false;
                        OnStateChanged?.Invoke(_state);
                        break;
                }
            }
        }

        protected override void Interact(Player player)
        {
            if (!HasKitchenObjectInParent())
            {
                if (player.HasKitchenObjectInParent() && HasKitchenObjectFryingSOInRecipe(player.GetKitchenObjectFromParent().GetKitchenObjectSO()))
                {
                    player.GetKitchenObjectFromParent().SetKitchenObjectInParent(this);
                    _isFrying = true;
                    _state = State.Frying;
                    OnStateChanged?.Invoke(_state);
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
                    _isFrying = false;
                    _state = State.Idle;
                    OnStateChanged?.Invoke(_state);
                }
                else
                {
                    //not have kitchen object in counter!!!
                }
            }
        }

        private bool HasKitchenObjectFryingSOInRecipe(KitchenObjectSO inputKitchenObjectSO)
        {
            KitchenObjectFryingRecipeSO kitchenObjectFryingRecipeSO = GetKitchenObjectFryingRecipeSOFromInput(inputKitchenObjectSO);
            return kitchenObjectFryingRecipeSO != null;
        }

        private KitchenObjectSO GetOutputFromInput(KitchenObjectSO inputKitchenObjectSO)
        {
            KitchenObjectFryingRecipeSO kitchenObjectFryingRecipeSO = GetKitchenObjectFryingRecipeSOFromInput(inputKitchenObjectSO);

            if (kitchenObjectFryingRecipeSO != null)
            {
                return kitchenObjectFryingRecipeSO.Output;
            }
            else
            {
                return null;
            }
        }

        private KitchenObjectFryingRecipeSO GetKitchenObjectFryingRecipeSOFromInput(KitchenObjectSO inputKitchenObjectSO)
        {
            for (int i = 0; i < _kitchenObjectFryingRecipeSOArray.Length; i++)
            {
                if (_kitchenObjectFryingRecipeSOArray[i].Input == inputKitchenObjectSO)
                {
                    return _kitchenObjectFryingRecipeSOArray[i];
                }
            }
            return null;
        }

        private KitchenObjectBurnedRecipeSO GetKitchenObjectBurnedRecipeSOFromInput(KitchenObjectSO inputKitchenObjectSO)
        {
            for (int i = 0; i < _kitchenObjectBurnedRecipeSOArray.Length; i++)
            {
                if (_kitchenObjectBurnedRecipeSOArray[i].Input == inputKitchenObjectSO)
                {
                    return _kitchenObjectBurnedRecipeSOArray[i];
                }
            }
            return null;
        }

        private void ShowVisualEffectAndParticles(State state)
        {
            Debug.Log(_state);
            if (state == State.Fried || state == State.Frying)
            {
                _stoveCounterView.VisualEffectPrefab.SetActive(_isFrying);
                _stoveCounterView.ParticlesPrefab.SetActive(_isFrying);
            }
            else
            {
                _stoveCounterView.VisualEffectPrefab.SetActive(_isFrying);
                _stoveCounterView.ParticlesPrefab.SetActive(_isFrying);
            }
        }

        public void Dispose()
        {
            OnInteract -= Interact;
            IsSelected -= ShowSelectedVisualEffect;
            OnStateChanged -= ShowVisualEffectAndParticles;
        }
    }
}
