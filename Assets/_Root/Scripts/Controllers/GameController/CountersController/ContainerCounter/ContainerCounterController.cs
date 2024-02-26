using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    internal sealed class ContainerCounterController : BaseController
    {
        private ContainerCounterView[] _containerCounterView;
        private ContainerCounterModel _containerCounterModel;

        private List<ContainerCounter> _containerCountersList;

        internal ContainerCounterController(ContainerCounterView[] containerCountersView,ContainerCounterModel containerCounterModel)
        {
            _containerCounterView = containerCountersView;
            _containerCounterModel = containerCounterModel;
            _containerCountersList = new List<ContainerCounter>();
            Initialize();
        }

        private void Initialize()
        {
            for (int i = 0; i < _containerCounterView.Length; i++)
            {
                ContainerCounter containerCounter = new ContainerCounter(_containerCounterView[i],_containerCounterModel);
                _containerCountersList.Add(containerCounter);
            }
        }

        protected override void OnDispose()
        {
            for (int i = 0; i < _containerCountersList.Count; i++)
            {
                _containerCountersList[i].Dispose();
                _containerCountersList.RemoveAt(i);
            }
        }
    }
}
