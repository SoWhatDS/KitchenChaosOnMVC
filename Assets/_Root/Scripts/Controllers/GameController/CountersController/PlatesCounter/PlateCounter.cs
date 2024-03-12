using System;
using System.Collections;
using System.Collections.Generic;
using KitchenChaosMVC.Engine.Game.PlayerControllers;
using UnityEngine;
using Object = UnityEngine.Object;
using KitchenChaosMVC.Engine.Game.AudioController;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    public sealed class PlateCounter : BaseCounter
    {
        public Action OnPlateSpawned;
        public Action OnPlateRemoved;

        private PlateCounterView _plateCounterView;
        private PlateCounterModel _plateCounterModel;
        private PlateVisualObjectOnScene _plateVisualObjectOnScene;
        private AudioManagerModel _audioManagerModel;


        private float _spawnPlateTimer;
        private float _countPlateOnScene;
        
        public PlateCounter(PlateCounterView plateCounterView,PlateCounterModel plateCounterModel)
        {
            _plateCounterView = plateCounterView;
            _plateCounterModel = plateCounterModel;
            _audioManagerModel = _plateCounterModel.AudioManagerModel;
            _plateCounterView.Init(this);

            CounterTopPoint = _plateCounterView.CounterTopPoint;
            SelectedCounter = _plateCounterView.SelectedCounter;

            _plateCounterView.SelectedCounter.Hide();

            _plateVisualObjectOnScene = new PlateVisualObjectOnScene(_plateCounterView);

            OnInteract += Interact;
            IsSelected += ShowSelectedVisualEffect;
            OnPlateSpawned += _plateVisualObjectOnScene.PlateSpawned;
            OnPlateRemoved += _plateVisualObjectOnScene.PlateRemoved;

        }

        public void TimerSpawnPlate()
        {
            _spawnPlateTimer += Time.deltaTime;

            if (_spawnPlateTimer > _plateCounterModel.PlateInstantiateTimer)
            {
                if (_countPlateOnScene < _plateCounterModel.PlateAmountMax)
                {
                    _spawnPlateTimer = 0f;
                    _countPlateOnScene++;

                    OnPlateSpawned?.Invoke();
                }

            }
        }

        protected override void Interact(Player player)
        {
            if (!player.HasKitchenObjectInParent())
            {
                if (_countPlateOnScene > 0)
                {
                    _countPlateOnScene--;

                    Transform kitchenObjectTransform = Object.Instantiate(_plateCounterModel.KitchenObjectPlate.Prefab);
                    kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectInParent(player);

                    _audioManagerModel.OnPlaySound?.Invoke(_audioManagerModel.ObjectPickUp, _plateCounterView.transform.position);
                    OnPlateRemoved?.Invoke();
                }
            }
        }

        public void Dispose()
        {
            OnInteract -= Interact;
            IsSelected -= ShowSelectedVisualEffect;
            OnPlateSpawned -= _plateVisualObjectOnScene.PlateSpawned;
            OnPlateRemoved -= _plateVisualObjectOnScene.PlateRemoved;
            _plateVisualObjectOnScene?.Dispose();
        }
    }
}
