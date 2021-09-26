namespace Quoridor.Controller
{
    using System.Threading.Tasks;
    using Model;
    using Model.Moves;

    public abstract class CharacterMover
    {
        private readonly Character character;

        public CharacterMover(Character character)
        {
            this.character = character;
        }

        public virtual async Task<Move> WaitForMove()
        {
            var move = await MakeMove();
            return move;
        }

        protected abstract Task<Move> MakeMove();
    }

    public class PlayerMover : CharacterMover
    {
        private TaskCompletionSource<Move> taskMove;

        public PlayerMover(Character character) : base(character)
        {
        }

        protected override Task<Move> MakeMove()
        {
            taskMove = new TaskCompletionSource<Move>();
            return taskMove.Task;
        }

        public bool TrySetMove(Move move)
        {
            return IsWaitingForMove() && move.IsValid();
        }

        private bool IsWaitingForMove()
        {
            return taskMove != null && !taskMove.Task.IsCompleted;
        }
    }

    public class BotMover : CharacterMover
    {
        private readonly Bot bot;

        public BotMover(Bot bot) : base(bot)
        {
        }

        protected override Task<Move> MakeMove()
        {
            var move = bot.Strategy.FindMoveFor(bot);
            return Task.FromResult(move);
        }
    }
}
