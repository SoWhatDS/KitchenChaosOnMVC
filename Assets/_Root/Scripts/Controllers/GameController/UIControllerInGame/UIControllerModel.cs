using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.UIController
{
    [CreateAssetMenu(fileName = nameof(UIControllerModel),menuName = "SettingsUI/ " + nameof(UIControllerModel))]
    public class UIControllerModel : ScriptableObject
    {
        [field: SerializeField] public DeliveryManagerModel DeliveryManagerModel { get; private set; }
        [field: SerializeField] public CountDownUIModel CountDownUIModel { get; private set;}
        [field: SerializeField] public GameOverUIModel GameOverUIModel { get; private set; }
    }
}
