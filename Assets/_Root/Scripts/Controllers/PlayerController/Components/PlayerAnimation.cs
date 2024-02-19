using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KitchenChaosMVC.Utils;

namespace KitchenChaosMVC.Engine.Game.PlayerControllers
{
    internal sealed class PlayerAnimation
    {
        private Animator _animator;

        public PlayerAnimation(Animator animator)
        {
            _animator = animator;
        }

        public void WalkAnimation(bool isWalking)
        {
            _animator.SetBool(GameConstantsAnimation.IS_WALKING, isWalking);
        }
    }
}
