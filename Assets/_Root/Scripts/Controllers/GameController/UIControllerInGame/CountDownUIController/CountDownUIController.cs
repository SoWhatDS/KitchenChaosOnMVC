using System.Collections;
using System.Collections.Generic;
using JoostenProductions;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.UIController
{
    public class CountDownUIController : BaseController
    {
        private CountDownUIView _countDownUIView;
        private CountDownUIModel _countDownUIModel;


        public CountDownUIController(CountDownUIView countDownUIView,CountDownUIModel countDownUIModel)
        {
            _countDownUIView = countDownUIView;
            _countDownUIModel = countDownUIModel;
            _countDownUIModel.OnCountDownTimer += Show;
            _countDownUIModel.OnStartPlaying += Hide;

        }

        private void Show(float timer)
        {
            _countDownUIView.Show(timer);
        }

        private void Hide()
        {
            _countDownUIView.Hide();
        }

        protected override void OnDispose()
        {
            _countDownUIModel.OnCountDownTimer -= Show;
            _countDownUIModel.OnStartPlaying -= Hide;
        }
    }
}
