namespace Quoridor.Controller
{
    using System;
    using System.Threading.Tasks;
    using Model;
    using Model.Moves;

    public interface IGameController
    {
        event Action OnGameEnd;

        event Action<Field> OnMoveMade;

        void StartGame();
    }

    public class GameController : IGameController
    {
        public event Action OnGameEnd;
        public event Action<Field> OnMoveMade;

        public bool IsPlayerMove => count % 2 == 0;

        private readonly IGameStarter gameStarter;

        private int count;
        private PlayerMover playerMover;
        private CharacterMover botMover;

        public GameController(IGameStarter gameStarter)
        {
            this.gameStarter = gameStarter;
        }

        public void StartGame()
        {
            var game = gameStarter.StartNewGame();
            playerMover = new PlayerMover(game.Player);
            botMover = new BotMover(game.Bot);
            StartLoop(game);
        }

        private async void StartLoop(Game game)
        {
            while (!game.HasFinished)
            {
                await MakeMove();
                OnMoveMade?.Invoke(game.Field);
            }
            OnGameEnd?.Invoke();
        }

        private async Task MakeMove()
        {
            var mover = IsPlayerMove ? playerMover : botMover;
            var move = await mover.WaitForMove();
            move.Execute();
            count++;
        }

        public bool TryMakePlayerMove(Move move)
        {
            return playerMover.TrySetMove(move);
        }
    }
}
