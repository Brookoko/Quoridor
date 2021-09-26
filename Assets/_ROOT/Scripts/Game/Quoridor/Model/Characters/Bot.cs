namespace Quoridor.Model
{
    public class Bot : Character
    {
        public MoveStrategy Strategy { get; }

        public Bot(Cell cell, MoveStrategy strategy) : base(cell)
        {
            Strategy = strategy;
        }
    }
}
