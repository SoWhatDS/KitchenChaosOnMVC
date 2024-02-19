using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.PlayerControllers
{

    internal sealed class PlayerView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public Animator Animator
        {
            get => _animator;
        }
    }
}
