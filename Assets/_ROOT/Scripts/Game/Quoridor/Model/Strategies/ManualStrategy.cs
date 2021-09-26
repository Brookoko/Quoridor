namespace Quoridor.Model.Strategies
{
    using Moves;

    public class ManualStrategy : MoveStrategy
    {
        public override bool IsManual => true;

        public ManualStrategy(Field field) : base(field)
        {
        }

        public override Move FindMoveFor(Character character)
        {
            return new DefaultMove(field);
        }
    }
}
