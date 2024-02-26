using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.PlayerControllers
{
    interface IMove 
    {
        void HandleMovement();

        void Rotate();

        void HandleInteract();

        void Dispose();

        bool IsWalking { get; }
    }
}
