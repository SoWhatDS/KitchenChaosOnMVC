using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.CountersControllers
{
    public class CountersAnimations
    {
        private Animator _animator;

        public CountersAnimations(Animator animator)
        {
            _animator = animator;
        }

        public void PlayAnimationsTrigger(string trigger)
        {
            _animator.SetTrigger(trigger);
        }
    }
}
