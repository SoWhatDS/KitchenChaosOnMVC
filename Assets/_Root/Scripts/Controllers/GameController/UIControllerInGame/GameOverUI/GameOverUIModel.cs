using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.UIController
{
    [CreateAssetMenu(fileName = nameof(GameOverUIModel),menuName = "Settings/ " + nameof(GameOverUIModel))]
    public class GameOverUIModel : ScriptableObject
    {
        public Action OnGameOverUI;
        public Action<int> OnDeliveredRecipesCount;
    }
}
