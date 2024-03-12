using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace KitchenChaosMVC.MainMenu
{
    public sealed class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _quitButton;

        private UnityAction _startGameAction;
        private UnityAction _quitGameAction;

        public void Init(UnityAction startGameAction,UnityAction quitGameAction)
        {
            _startGameAction = startGameAction;
            _quitGameAction = quitGameAction;

            _playButton.onClick.AddListener(_startGameAction);
            _quitButton.onClick.AddListener(_quitGameAction);
        }

        private void OnDestroy()
        {
            _playButton.onClick.RemoveListener(_startGameAction);
            _quitButton.onClick.RemoveListener(_quitGameAction);
        }
    }
}
