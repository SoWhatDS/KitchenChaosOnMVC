using System.Collections;
using System.Collections.Generic;
using KitchenChaosMVC.Engine.Game;
using KitchenChaosMVC.Engine.Game.AudioController;
using KitchenChaosMVC.Engine.Game.CountersControllers;
using KitchenChaosMVC.Engine.Game.PlayerControllers;
using KitchenChaosMVC.Engine.Game.UIController;
using KitchenChaosMVC.Loading;
using UnityEngine;

namespace KitchenChaosMVC.Settings
{
    [CreateAssetMenu(fileName = nameof(SettingsContainer),menuName = "Settings/ " + nameof(SettingsContainer))]
    internal sealed class SettingsContainer : ScriptableObject
    {
        [field: SerializeField] public PlayerModel PlayerModel { get; private set; }
        [field: SerializeField] public CountersModel CountersModel { get; private set; }
        [field: SerializeField] public UIControllerModel UIControllerModel { get; private set; }
        [field: SerializeField] public AudioManagerModel AudioManagerModel { get; private set; }
        [field: SerializeField] public LoadingModel LoadingModel { get; private set; }
        [field: SerializeField] public GameModel GameModel { get; private set; }
    }
}
