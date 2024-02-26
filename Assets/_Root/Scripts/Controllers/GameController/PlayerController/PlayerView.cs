using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.PlayerControllers
{

    public sealed class PlayerView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _holdPointForKitchenObject;

        public Animator Animator
        {
            get => _animator;
        }

        public Transform HoldPointForKitchenObject
        {
            get => _holdPointForKitchenObject;
        }
    }
}
