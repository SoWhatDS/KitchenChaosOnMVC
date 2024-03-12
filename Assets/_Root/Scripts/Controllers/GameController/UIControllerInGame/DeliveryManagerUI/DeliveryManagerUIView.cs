using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.UIController
{
    public class DeliveryManagerUIView : MonoBehaviour
    {
        [field: SerializeField] public Transform Container { get; private set; }
        [field: SerializeField] public Transform TemplateRecipes { get; private set; }
    }
}
