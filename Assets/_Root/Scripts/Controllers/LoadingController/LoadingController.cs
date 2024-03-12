using System.Collections;
using System.Collections.Generic;
using JoostenProductions;
using KitchenChaosMVC.Settings;
using KitchenChaosMVC.Utils;
using UnityEngine;

namespace KitchenChaosMVC.Loading
{
    public sealed class LoadingController : BaseController
    {
        private LoadingView _loadingView;
        private ProfileGame _profileGame;

        private float _timerToLoading;

        internal LoadingController(ProfileGame profileGame,SettingsContainer settingsContainer)
        {
            _profileGame = profileGame;
            _timerToLoading = settingsContainer.LoadingModel.TimerToLoading;
            _loadingView = LoadView();
            UpdateManager.SubscribeToUpdate(Update);
        }

        private void Update()
        {
            _timerToLoading -= Time.deltaTime;

            if (_timerToLoading < 0f && _loadingView != null)
            {
                _profileGame.CurrentGameState.Value = GameState.StartGame;
            }
        }

        private LoadingView LoadView()
        {
            GameObject prefab = ResourceLoader.LoadPrefab(GameConstantsView.LOADING_VIEW);
            GameObject objectView = Object.Instantiate(prefab);
            AddGameObjects(objectView);
            return ResourceLoader.GetOrAddComponent<LoadingView>(objectView);
        }

        protected override void OnDispose()
        {
            UpdateManager.UnsubscribeFromUpdate(Update);
        }
    }
}
