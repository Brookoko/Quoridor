namespace Quoridor.Model
{
    public abstract class Character
    {
        public Cell Cell { get; private set; }

        public int AmountOfWalls { get; private set; }

        public Character(Cell cell)
        {
            Cell = cell;
        }

        public void MoveTo(Cell cell)
        {
            Cell = cell;
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
