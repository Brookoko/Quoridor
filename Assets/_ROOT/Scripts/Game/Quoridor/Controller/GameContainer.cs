namespace Quoridor.Controller
{
    public class GameContainer
    {
        public IGameProvider GameProvider { get; }
        public IUiControllerProxy UiController { get; }
        public IGameController GameController { get; }
        public Flow Flow { get; }

        public GameContainer()
        {
            var gameProvider = new GameProvider();
            GameProvider = gameProvider;
            GameController = new GameController(gameProvider);
            UiController = new UiController();
            Flow = new Flow(GameController, UiController);
        }
    }
}
