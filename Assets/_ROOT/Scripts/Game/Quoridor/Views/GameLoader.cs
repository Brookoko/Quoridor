namespace Quoridor.Views
{
    using Controller;
    using UnityEngine;

    public class GameLoader : MonoBehaviour
    {
        [SerializeField]
        private GameView gameViewPrefab;

        private Flow flow;
        private IGameProvider gameProvider;
        private IGameController gameController;

        public void Initialize(Flow flow, IGameProvider gameProvider, IGameController gameController)
        {
            this.flow = flow;
            this.gameProvider = gameProvider;
            this.gameController = gameController;
        }

        public void CreateNewGame()
        {
            flow.SwitchToGame();
            var gameView = Instantiate(gameViewPrefab, transform);
            gameView.Initialize(gameProvider, gameController);
        }
    }
}
