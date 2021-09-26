namespace Quoridor.Views
{
    using Controller;
    using Ui;
    using UnityEngine;

    public class GameRoot : MonoBehaviour
    {
        [SerializeField]
        private UiControllerView uiControllerView;

        [SerializeField]
        private GameLoader gameLoader;

        public void Awake()
        {
            var gameContainer = new GameContainer();
            gameLoader.Initialize(gameContainer.Flow, gameContainer.GameProvider, gameContainer.GameController);
            uiControllerView.Initialize(gameContainer.UiController, gameLoader);
            gameContainer.Flow.SwitchToHome();
        }
    }
}
