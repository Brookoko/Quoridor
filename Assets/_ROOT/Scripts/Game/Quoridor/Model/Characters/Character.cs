namespace Quoridor.Model
{
    public abstract class Character
    {
        public Cell Cell { get; private set; }

        public Character(Cell cell)
        {
            Cell = cell;
        }

        public void MoveTo(Cell cell)
        {
            Cell = cell;
        }
    }
}
