using System.Collections;
using System.Collections.Generic;
using KitchenChaosMVC.Utils;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.UIController
{
    public sealed class UIControllerInGame : BaseController
    {
        private UIControllerView _uiControllerView;
        private UIControllerModel _uiControllerModel;

        private DeliveryManagerController _deliveryManagerController;
        private CountDownUIController _countDownUIController;
        private GameOverUIController _gameOverUIController;

        public UIControllerInGame(UIControllerModel uIControllerModel)
        {

            _uiControllerView = LoadView();
            _uiControllerModel = uIControllerModel;

            CreateUIControllers();
        }
        
        private UIControllerView LoadView()
        {
            GameObject prefab = ResourceLoader.LoadPrefab(GameConstantsView.UI_VIEW);
            GameObject objectView = Object.Instantiate(prefab);
            AddGameObjects(objectView);
            return ResourceLoader.GetOrAddComponent<UIControllerView>(objectView);
        }

        private void CreateUIControllers()
        {
            _deliveryManagerController = new DeliveryManagerController(_uiControllerView.DeliveryManagerUI,_uiControllerModel.DeliveryManagerModel);
            AddControllers(_deliveryManagerController);

            _countDownUIController = new CountDownUIController(_uiControllerView.CountDownUIView,_uiControllerModel.CountDownUIModel);
            AddControllers(_countDownUIController);

            _gameOverUIController = new GameOverUIController(_uiControllerView.GameOverUIView,_uiControllerModel.GameOverUIModel);
            AddControllers(_gameOverUIController);
        }

        protected override void OnDispose()
        {
            
        }
    }
}
