namespace Quoridor.Model
{
    public class Field
    {
        public Cell[,] Cells { get; }

        public int Width { get; }

        public int Height { get; }

        public Field(int width, int height)
        {
            Width = width;
            Height = height;
            Cells = new Cell[width, height];
            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    var state = GetState(i, j);
                    Cells[i, j] = new Cell(i, j, state);
                }
            }
        }

        private CellState GetState(int i, int j)
        {
            var state = (CellState)0;
            if (i == 0)
            {
                state |= CellState.BlockLeft;
            }
            if (i == Width - 1)
            {
                state |= CellState.BlockRight;
            }
            if (j == 0)
            {
                state |= CellState.BlockUp;
            }
            if (j == Height - 1)
            {
                state |= CellState.BlockDown;
            }
            return state;
        }

        public Cell this[int i, int j] => Cells[i, j];
    }
}
