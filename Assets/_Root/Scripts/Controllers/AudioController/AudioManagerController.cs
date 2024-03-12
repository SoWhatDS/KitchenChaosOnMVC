using System.Collections;
using System.Collections.Generic;
using KitchenChaosMVC.Utils;
using UnityEngine;

namespace KitchenChaosMVC.Engine.Game.AudioController
{
    public class AudioManagerController : BaseController
    {
        private AudioManagerModel _audioManagerModel;
        private AudioManagerView _audioManagerView;

        public AudioManagerController(AudioManagerModel audioManagerModel)
        {
            _audioManagerView = LoadView();
            _audioManagerModel = audioManagerModel;
            _audioManagerView.AudioSource.volume = _audioManagerModel.Volume;
            _audioManagerModel.OnPlaySound += PlaySound;
        }

        private void PlaySound(AudioClipSO audioClipSO,Vector3 position)
        {
            AudioClip audioClipRandom = audioClipSO.AudioClipList[Random.Range(0, audioClipSO.AudioClipList.Count)];
            PlaySound(audioClipRandom,position);
        }

        private void PlaySound(AudioClip audioClip,Vector3 position)
        {
             AudioSource.PlayClipAtPoint(audioClip,position);
        }

        private AudioManagerView LoadView()
        {
            GameObject prefab = ResourceLoader.LoadPrefab(GameConstantsView.AUDIO_VIEW);
            GameObject objectView = Object.Instantiate(prefab);
            AddGameObjects(objectView);
            return ResourceLoader.GetOrAddComponent<AudioManagerView>(objectView);
        }

        protected override void OnDispose()
        {
            _audioManagerModel.OnPlaySound -= PlaySound;
        }
    }
}
