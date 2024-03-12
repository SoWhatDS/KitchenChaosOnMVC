using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.UIController
{
    public class UIControllerView : MonoBehaviour
    {
        [field: SerializeField] public DeliveryManagerUIView DeliveryManagerUI { get; private set; }
        [field: SerializeField] public CountDownUIView CountDownUIView { get; private set; }
        [field: SerializeField] public GameOverUIView GameOverUIView { get; private set; }
    }
}
