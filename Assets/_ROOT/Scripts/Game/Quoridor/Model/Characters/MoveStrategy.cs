namespace Quoridor.Model
{
    using Moves;

    public abstract class MoveStrategy
    {
        protected readonly Field field;

        public MoveStrategy(Field field)
        {
            this.field = field;
        }

        public abstract Move FindMoveFor(Character character);
    }

    public class RandomMoveStrategy : MoveStrategy
    {
        public RandomMoveStrategy(Field field) : base(field)
        {
        }

        public override Move FindMoveFor(Character character)
        {
            return new CharacterMove(field, character, field.Cells[0, 0]);
        }
    }
}
