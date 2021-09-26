namespace Quoridor.Model.Strategies
{
    using Moves;

    public class RandomMoveStrategy : MoveStrategy
    {
        public override bool IsManual => false;

        public RandomMoveStrategy(Field field) : base(field)
        {
        }

        public override Move FindMoveFor(Character character)
        {
            return new CharacterMove(field, character, field[0, 0]);
        }
    }
}
