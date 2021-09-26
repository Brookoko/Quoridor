namespace Quoridor.Controller
{
    using System.Threading.Tasks;
    using Model;
    using Model.Moves;

    public class CharacterMover
    {
        private readonly Character character;
        private TaskCompletionSource<Move> taskMove;

        public CharacterMover(Character character)
        {
            this.character = character;
        }

        public Task<Move> WaitForMove()
        {
            if (character.ShouldWaitForMove())
            {
                taskMove = new TaskCompletionSource<Move>();
                return taskMove.Task;
            }
            var move = character.FindMove();
            return Task.FromResult(move);
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
}
