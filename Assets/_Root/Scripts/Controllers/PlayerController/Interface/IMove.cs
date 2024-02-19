using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.PlayerControllers
{
    interface IMove 
    {
        void Move();

        void Rotate();

        bool IsWalking { get; }
    }
}
