using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.AudioController
{
    public class AudioManagerView : MonoBehaviour
    {
        [field: SerializeField] public AudioSource AudioSource { get; private set; }
    }
}
