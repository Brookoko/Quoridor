namespace Quoridor.Controller
{
    using Model;

    public interface IGameProvider
    {
        Game Game { get; }
    }

    public interface IGameStarter
    {
        Game StartNewGame(GameOptions gameOptions);
    }

    public class GameProvider : IGameProvider, IGameStarter
    {
        public Game Game { get; private set; }

        public Game StartNewGame(GameOptions gameOptions)
        {
            Game = new Game(gameOptions);
            return Game;
        }
    }
}
