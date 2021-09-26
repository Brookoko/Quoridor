namespace Quoridor.Controller
{
    using System;
    using System.Threading.Tasks;
    using Model;

    public interface IGameController
    {
        event Action OnGameEnd;

        event Action<Field> OnMoveMade;

        void StartGame(GameOptions gameOptions);
    }

    public class GameController : IGameController
    {
        public event Action OnGameEnd;
        public event Action<Field> OnMoveMade;

        private readonly IGameStarter gameStarter;

        private CharacterMover[] movers;
        private int count;

        public GameController(IGameStarter gameStarter)
        {
            this.gameStarter = gameStarter;
        }

        public void StartGame(GameOptions gameOptions)
        {
            var game = gameStarter.StartNewGame(gameOptions);
            movers = new CharacterMover[2];
            movers[0] = new CharacterMover(game.FirstPlayer);
            movers[1] = new CharacterMover(game.SecondPlayer);
            StartLoop(game);
        }

        private async void StartLoop(Game game)
        {
            while (!game.HasFinished)
            {
                await WaitForMove();
                OnMoveMade?.Invoke(game.Field);
            }
            OnGameEnd?.Invoke();
        }

        private async Task WaitForMove()
        {
            var mover = movers[count % movers.Length];
            var move = await mover.WaitForMove();
            move.Execute();
            count++;
        }
    }
}
