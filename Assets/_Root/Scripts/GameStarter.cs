
using KitchenChaosMVC.Settings;
using KitchenChaosMVC.Utils;
using UnityEngine;

namespace KitchenChaosMVC.Engine
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private SettingsContainer _settingsContainer;
        //change for Main Menu
        private const GameState InitialGameState = GameState.StartGame;

        private MainController _mainController;

        private void Start()
        {
            ProfileGame profileGame = new ProfileGame(InitialGameState);
            _mainController = new MainController(profileGame,_settingsContainer);
        }

        private void OnDestroy()
        {
            _mainController.Dispose();
        }
    }
}
