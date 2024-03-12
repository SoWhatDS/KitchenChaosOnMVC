using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.AudioController
{
    [CreateAssetMenu(fileName =nameof(AudioManagerModel),menuName ="SettingAudio/ " + nameof(AudioManagerModel))]
    public class AudioManagerModel : ScriptableObject
    {
        public Action<AudioClipSO, Vector3> OnPlaySound;
        
        [field: SerializeField] public AudioClipSO Chop { get; private set; }
        [field: SerializeField] public AudioClipSO DeliveryFail { get; private set; }
        [field: SerializeField] public AudioClipSO DeliverySuccess { get; private set; }
        [field: SerializeField] public AudioClipSO FootStep { get; private set; }
        [field: SerializeField] public AudioClipSO ObjectDrop { get; private set; }
        [field: SerializeField] public AudioClipSO ObjectPickUp { get; private set; }
        [field: SerializeField] public AudioClipSO StoveSizze { get; private set; }
        [field: SerializeField] public AudioClipSO Trash { get; private set; }
        [field: SerializeField] public AudioClipSO Warning { get; private set; }

        [field: SerializeField] public float Volume { get; private set; }

    }
}
