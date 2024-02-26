using System;
using System.Collections;
using System.Collections.Generic;
using KitchenChaosMVC.Engine.Game.PlayerControllers;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    public interface IBaseCounter 
    {
        public BaseCounter BaseCounter { get; }
        public void Init(BaseCounter baseCounter);
    }
}
