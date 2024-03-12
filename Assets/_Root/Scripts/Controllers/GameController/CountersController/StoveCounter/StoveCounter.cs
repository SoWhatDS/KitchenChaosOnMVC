using System;
using System.Collections;
using System.Collections.Generic;
using KitchenChaosMVC.Engine.Game.PlayerControllers;
using UnityEngine;
using Object = UnityEngine.Object;
using KitchenChaosMVC.Engine.Game.AudioController;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    public class StoveCounter : BaseCounter
    {
        private Action<State> OnStateChanged;
        private Action<float> OnProgressChanged;

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
        private AudioManagerModel _audioManagerModel;

        private KitchenObjectFryingRecipeSO[] _kitchenObjectFryingRecipeSOArray;
        private KitchenObjectBurnedRecipeSO[] _kitchenObjectBurnedRecipeSOArray;

        private KitchenObjectFryingRecipeSO _kitchenObjectFryingRecipeSO;
        private KitchenObjectBurnedRecipeSO _kitchenObjectBurnedRecipeSO;

        private float _fryingTimer;
        private float _burnedTimer;
        private bool _isFrying;

        private float _progressChangedTime;


        public StoveCounter(StoveCounterView stoveCounterView,StoveCounterModel stoveCounterModel)
        {
            _stoveCounterView = stoveCounterView;
            _stoveCounterModel = stoveCounterModel;
            _audioManagerModel = _stoveCounterModel.AudioManagerModel;

            _kitchenObjectFryingRecipeSOArray = _stoveCounterModel.KitchenObjectFryingRecipeSOArray;
            _kitchenObjectBurnedRecipeSOArray = _stoveCounterModel.KitchenObjectBurnedRecipeSOArray;

            _stoveCounterView.Init(this);
            _stoveCounterView.SelectedCounter.Hide();
            _stoveCounterView.BarProgressUI.Hide();
            
            SelectedCounter = _stoveCounterView.SelectedCounter;
            CounterTopPoint = _stoveCounterView.CounterTopPoint;

            _state = State.Idle;

            OnInteract += Interact;
            IsSelected += ShowSelectedVisualEffect;
            OnStateChanged += ShowVisualEffectAndParticles;
            OnProgressChanged += _stoveCounterView.BarProgressUI.ShowVisualBarProgressUI;
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
                        UpdateVisualBarProgress(_fryingTimer,_kitchenObjectFryingRecipeSO.FryingTimeMax);

                        if (_fryingTimer >= _kitchenObjectFryingRecipeSO.FryingTimeMax)
                        {
                            GetKitchenObjectFromParent().DestroySelf();

                            _fryingTimer = 0f;

                            //PoolObject
                            Transform kitchenObjectTransform = Object.Instantiate(_kitchenObjectFryingRecipeSO.Output.Prefab);
                            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectInParent(this);
                            _audioManagerModel.OnPlaySound?.Invoke(_audioManagerModel.StoveSizze,_stoveCounterView.transform.position);
                            ChangeState(State.Fried);
                        }
                        break;
                    case State.Fried:
                        _burnedTimer += Time.deltaTime;
                        _kitchenObjectBurnedRecipeSO = GetKitchenObjectBurnedRecipeSOFromInput(GetKitchenObjectFromParent().GetKitchenObjectSO());

                        UpdateVisualBarProgress(_burnedTimer,_kitchenObjectBurnedRecipeSO.BurnedTimeMax);

                        if (_burnedTimer >= _kitchenObjectBurnedRecipeSO.BurnedTimeMax)
                        {
                            GetKitchenObjectFromParent().DestroySelf();

                            _burnedTimer = 0f;

                            //PoolObject
                            Transform kitchenObjectTransform = Object.Instantiate(_kitchenObjectBurnedRecipeSO.Output.Prefab);
                            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectInParent(this);
                            ChangeState(State.Burned);
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
                    _audioManagerModel.OnPlaySound?.Invoke(_audioManagerModel.StoveSizze, _stoveCounterView.transform.position);
                    ChangeState(State.Frying);
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
                    _audioManagerModel.OnPlaySound?.Invoke(_audioManagerModel.ObjectPickUp, _stoveCounterView.transform.position);
                    ResetTimer();
                    ChangeState(State.Idle);
                   
                }
                else
                {
                    if (player.GetKitchenObjectFromParent().TryGetPlateKitchenObject(out PlateKitchenObject plateKitchenObject))
                    {
                        if (plateKitchenObject.TryAddIngredients(GetKitchenObjectFromParent().GetKitchenObjectSO()))
                        {
                            _audioManagerModel.OnPlaySound?.Invoke(_audioManagerModel.ObjectPickUp, _stoveCounterView.transform.position);
                            GetKitchenObjectFromParent().DestroySelf();
                        }
                    }

                    _isFrying = false;

                    ResetTimer();
                    ChangeState(State.Idle);
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

        private void UpdateVisualBarProgress(float timer,float timeMax)
        {
            _progressChangedTime = timer / timeMax;
            OnProgressChanged?.Invoke(_progressChangedTime);
        }

        private void ResetTimer()
        {
            _fryingTimer = 0f;
            _burnedTimer = 0f;
            _stoveCounterView.BarProgressUI.Hide();
        }

        private void ChangeState(State state)
        {
            _state = state;
            OnStateChanged?.Invoke(_state);
        }

        public void Dispose()
        {
            OnInteract -= Interact;
            IsSelected -= ShowSelectedVisualEffect;
            OnStateChanged -= ShowVisualEffectAndParticles;
            OnProgressChanged -= _stoveCounterView.BarProgressUI.ShowVisualBarProgressUI;
        }
    }
}
