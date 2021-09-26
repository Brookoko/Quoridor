namespace Quoridor.Model
{
    using System;

    [Flags]
    public enum CellState
    {
        BlockLeft = 1,
        BlockRight = 2,
        BlockUp = 4,
        BlockDown = 8,
    }
}
