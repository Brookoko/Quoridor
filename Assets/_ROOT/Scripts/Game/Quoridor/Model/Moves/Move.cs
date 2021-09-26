namespace Quoridor.Model.Moves
{
    public abstract class Move
    {
        protected readonly Field field;

        public Move(Field field)
        {
            this.field = field;
        }

        public abstract bool IsValid();

        public abstract void Execute();

        public abstract void Undo();
    }
}
