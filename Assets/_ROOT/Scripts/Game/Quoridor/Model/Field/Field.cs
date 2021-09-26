namespace Quoridor.Model
{
    using System.Collections.Generic;

    public class Field
    {
        public int Width { get; }

        public int Height { get; }

        public List<Wall> Walls { get; }

        private readonly Cell[,] cells;

        public Field(int width, int height)
        {
            Width = width;
            Height = height;
            cells = new Cell[width, height];
            Walls = new List<Wall>();
            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    var state = GetState(i, j);
                    cells[i, j] = new Cell(j, i, state);
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

        public void AddWall(Wall wall)
        {
            Walls.Add(wall);
            UpdateCellBlocking(wall);
        }

        private void UpdateCellBlocking(Wall wall)
        {
            Walls.Add(wall);
            switch (wall.WallType)
            {
                case WallType.Horizontal:
                    wall.LeftUpper.UpdateState(CellState.BlockDown);
                    wall.RightUpper.UpdateState(CellState.BlockDown);
                    wall.LeftLower.UpdateState(CellState.BlockUp);
                    wall.RightLower.UpdateState(CellState.BlockUp);
                    break;
                case WallType.Vertical:
                    wall.LeftUpper.UpdateState(CellState.BlockRight);
                    wall.LeftLower.UpdateState(CellState.BlockRight);
                    wall.RightUpper.UpdateState(CellState.BlockLeft);
                    wall.RightLower.UpdateState(CellState.BlockLeft);
                    break;
            }
        }

        public void RemoveWall(Wall wall)
        {
            Walls.Remove(wall);
            switch (wall.WallType)
            {
                case WallType.Horizontal:
                    wall.LeftUpper.ClearState(CellState.BlockDown);
                    wall.RightUpper.ClearState(CellState.BlockDown);
                    wall.LeftLower.ClearState(CellState.BlockUp);
                    wall.RightLower.ClearState(CellState.BlockUp);
                    break;
                case WallType.Vertical:
                    wall.LeftUpper.ClearState(CellState.BlockRight);
                    wall.LeftLower.ClearState(CellState.BlockRight);
                    wall.RightUpper.ClearState(CellState.BlockLeft);
                    wall.RightLower.ClearState(CellState.BlockLeft);
                    break;
            }
        }

        public Cell this[int i, int j] => cells[i, j];
    }
}
