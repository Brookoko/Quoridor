namespace Quoridor.Controller
{
    using Model;

    public interface IGameProvider
    {
        Game Game { get; }
    }

    public interface IGameStarter
    {
        Game StartNewGame();
    }

    public class GameProvider : IGameProvider, IGameStarter
    {
        public Game Game { get; private set; }

        public Game StartNewGame()
        {
            Game = new Game();
            return Game;
        }
    }
}
