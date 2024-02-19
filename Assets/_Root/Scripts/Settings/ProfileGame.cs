using System.Collections;
using System.Collections.Generic;
using KitchenChaosMVC.Utils;
using UnityEngine;


namespace KitchenChaosMVC.Settings
{
    internal sealed class ProfileGame
    {
        public readonly SubscriptionProperty<GameState> CurrentGameState;

        public ProfileGame(GameState initialGameState)
        {
            CurrentGameState = new SubscriptionProperty<GameState>();
            CurrentGameState.Value = initialGameState;
        }
            
    }
}
