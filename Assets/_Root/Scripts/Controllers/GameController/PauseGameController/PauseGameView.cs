using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace KitchenChaosMVC.Engine.Game
{
    public class PauseGameView : MonoBehaviour
    {
        [SerializeField] private Button _mainMenuButton;
        [SerializeField] private Button _retryButton;

        private UnityAction _mainMenuAction;
        private UnityAction _retryAction;

        public void Init(UnityAction mainMenuAction,UnityAction retryAction)
        {
            _mainMenuAction = mainMenuAction;
            _retryAction = retryAction;
            Hide();
            _mainMenuButton.onClick.AddListener(_mainMenuAction);
            _retryButton.onClick.AddListener(_retryAction);
        }

        public void TogglePause()
        {
            gameObject.SetActive(!gameObject.activeSelf);

            if (gameObject.activeSelf)
            {
                Show();
            }
            else
            {
                Hide();
            }

        }

        private void Show()
        {
            gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
        }

        private void OnDestroy()
        {
            _mainMenuButton.onClick.RemoveListener(_mainMenuAction);
            _retryButton.onClick.RemoveListener(_retryAction);
        }
    }
}
