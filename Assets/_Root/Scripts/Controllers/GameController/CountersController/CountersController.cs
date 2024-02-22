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
        }

        protected override void OnDispose()
        {
           
        }
    }
}
