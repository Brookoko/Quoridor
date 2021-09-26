namespace Quoridor.Model
{
    public class Cell
    {
        public int X { get; }

        public int Y { get; }

        public CellState State { get; }

        public Cell(int x, int y, CellState state)
        {
            X = x;
            Y = y;
            State = state;
        }
    }
}
