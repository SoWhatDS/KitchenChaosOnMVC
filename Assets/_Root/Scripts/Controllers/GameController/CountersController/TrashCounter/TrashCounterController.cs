using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    public class TrashCounterController : BaseController
    {
        private TrashCounterView[] _trashCountersViewArray;
        private TrashCounterModel _trashCounterModel;

        private List<TrashCounter> _trashCountersList;

        public TrashCounterController(TrashCounterView[] trashCounterViewsArray, TrashCounterModel trashCounterModel)
        {
            _trashCountersViewArray = trashCounterViewsArray;
            _trashCounterModel = trashCounterModel;
            _trashCountersList = new List<TrashCounter>();
            Initialize();
        }

        private void Initialize()
        {
            for (int i = 0; i < _trashCountersViewArray.Length; i++)
            {
                TrashCounter trashCounter = new TrashCounter(_trashCountersViewArray[i],_trashCounterModel);
                _trashCountersList.Add(trashCounter);
            }
        }

        protected override void OnDispose()
        {
            for (int i = 0; i < _trashCountersList.Count; i++)
            {
                _trashCountersList[i].Dispose();
                _trashCountersList.RemoveAt(i);
            }
        }
    }
}
