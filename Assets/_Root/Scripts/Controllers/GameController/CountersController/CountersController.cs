using System.Collections;
using System.Collections.Generic;
using KitchenChaosMVC.Utils;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    internal sealed class CountersController : BaseController
    {
        private CountersView _countersView;
        private CountersModel _countersModel;

        private ClearCountersController _clearCountersController;
        private ContainerCounterController _containerCountersController;
        private CuttingCounterController _cuttingCounterController;
        private TrashCounterController _trashCounterController;
        private StoveCounterController _stoveCounterController;
        private PlateCounterController _plateCounterController;
        private DeliveryCounterController _deliveryCounterController;

        internal CountersController(CountersModel countersModel)
        {
            _countersView = LoadView();
            _countersModel = countersModel;

            CreateAllCountersControllers();
        }

        private CountersView LoadView()
        {
            GameObject prefab = ResourceLoader.LoadPrefab(GameConstantsView.COUNTERS_VIEW);
            GameObject objectView = Object.Instantiate(prefab);
            AddGameObjects(objectView);
            return ResourceLoader.GetOrAddComponent<CountersView>(objectView);
        }

        private void CreateAllCountersControllers()
        {
            _clearCountersController = new ClearCountersController(_countersView.ClearCountersView,_countersModel.ClearCountersModel);
            _containerCountersController = new ContainerCounterController(_countersView.ContainerCounterView,_countersModel.ContainerCounterModel);
            _cuttingCounterController = new CuttingCounterController(_countersView.CuttingCounterView,_countersModel.CuttingCounterModel);
            _trashCounterController = new TrashCounterController(_countersView.TrashCounterView,_countersModel.TrashCounterModel);
            _stoveCounterController = new StoveCounterController(_countersView.StoveCounterViews,_countersModel.StoveCounterModel);
            _plateCounterController = new PlateCounterController(_countersView.PlateCounterView, _countersModel.PlateCounterModel);
            _deliveryCounterController = new DeliveryCounterController(_countersView.DeliveryCounterView,_countersModel.DeliveryCounterModel);
        }

        protected override void OnDispose()
        {
            _clearCountersController?.Dispose();
            _containerCountersController?.Dispose();
            _cuttingCounterController?.Dispose();
            _trashCounterController?.Dispose();
            _stoveCounterController?.Dispose();
            _plateCounterController?.Dispose();
            _deliveryCounterController?.Dispose();
            
        }
    }
}
