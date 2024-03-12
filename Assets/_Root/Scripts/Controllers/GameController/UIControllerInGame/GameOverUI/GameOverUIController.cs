using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.UIController
{
    public sealed class GameOverUIController : BaseController
    {
        private GameOverUIView _gameOverUIView;
        private GameOverUIModel _gameOverUIModel;

        public GameOverUIController(GameOverUIView gameOverUIView,GameOverUIModel gameOverUIModel)
        {
            _gameOverUIView = gameOverUIView;
            _gameOverUIModel = gameOverUIModel;

            _gameOverUIView.Hide();
            
            _gameOverUIModel.OnGameOverUI += Show;
            _gameOverUIModel.OnDeliveredRecipesCount += UpdateDeliveredRecipesText;
            _gameOverUIModel.OnDeliveredRecipesCount?.Invoke(0);
        }

        private void Show()
        {
            _gameOverUIView.Show();
        }

        private void UpdateDeliveredRecipesText(int countDeliveredRecipes)
        {
            _gameOverUIView.UpdateDeliveredRecipesText(countDeliveredRecipes);
        }

        protected override void OnDispose()
        {
            _gameOverUIModel.OnGameOverUI -= Show;
            _gameOverUIModel.OnDeliveredRecipesCount -= UpdateDeliveredRecipesText;
        }
    }
}
