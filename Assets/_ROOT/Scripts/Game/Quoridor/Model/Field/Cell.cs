namespace Quoridor.Model
{
    public class Cell
    {
        public int X { get; }

        public int Y { get; }

        public CellState State { get; private set; }

        public Cell(int x, int y, CellState state)
        {
            X = x;
            Y = y;
            State = state;
        }

        public void UpdateState(CellState state)
        {
            State |= state;
        }

        public void ClearState(CellState state)
        {
            State ^= state;
        }
    }
}
