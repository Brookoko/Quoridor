namespace Quoridor.Model
{
    using Strategies;

    public class Bot : Character
    {
        public Bot(Cell cell, MoveStrategy strategy) : base(cell, strategy)
        {
        }
    }
}
