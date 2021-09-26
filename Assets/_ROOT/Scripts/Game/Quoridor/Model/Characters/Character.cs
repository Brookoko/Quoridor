namespace Quoridor.Model
{
    using Moves;
    using Strategies;

    public abstract class Character
    {
        public Cell Cell { get; private set; }

        public int AmountOfWalls { get; private set; }

        private readonly MoveStrategy strategy;

        public Character(Cell cell, MoveStrategy strategy)
        {
            Cell = cell;
            this.strategy = strategy;
        }

        public void MoveTo(Cell cell)
        {
            Cell = cell;
        }

        public bool ShouldWaitForMove()
        {
            return strategy.IsManual;
        }

        public Move FindMove()
        {
            return strategy.FindMoveFor(this);
        }

        public bool HasWalls()
        {
            return AmountOfWalls > 0;
        }

        public void UseWall()
        {
            AmountOfWalls--;
        }

        public void RestoreWall()
        {
            AmountOfWalls++;
        }
    }
}
