namespace Quoridor.Model
{
    using Strategies;

    public class Player : Character
    {
        public Player(Cell cell, MoveStrategy strategy) : base(cell, strategy)
        {
        }
    }
}
