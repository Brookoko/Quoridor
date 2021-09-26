namespace Quoridor.Model.Strategies
{
    using Moves;

    public abstract class MoveStrategy
    {
        public abstract bool IsManual { get; }

        protected readonly Field field;

        public MoveStrategy(Field field)
        {
            this.field = field;
        }

        public abstract Move FindMoveFor(Character character);
    }


}
