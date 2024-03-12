using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.AudioController
{
    [CreateAssetMenu(fileName = nameof(AudioClipSO),menuName = "SettingAudio/ " + nameof(AudioClipSO))]
    public class AudioClipSO : ScriptableObject
    {
        [field: SerializeField] public List<AudioClip> AudioClipList { get; private set; }
    }
}
