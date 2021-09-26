namespace Quoridor.Controller
{
    using Model;

    public class Flow
    {
        private readonly IGameController gameController;
        private readonly IUiController uiController;

        public Flow(IGameController gameController, IUiController uiController)
        {
            this.gameController = gameController;
            this.uiController = uiController;
        }

        public void SwitchToHome()
        {
            uiController.ShowHomeScreen();
        }

        public void SwitchToGame(GameOptions gameOptions)
        {
            gameController.StartGame(gameOptions);
            uiController.ShowGameScreen();
            gameController.OnGameEnd += OnGameEnd;
        }

        private void OnGameEnd()
        {
            uiController.ShowResultScreen();
        }
    }
}
