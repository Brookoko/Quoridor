namespace Quoridor.Model
{
    public class Wall
    {
        public Cell LeftUpper { get; }
        public Cell RightUpper { get; }
        public Cell LeftLower { get; }
        public Cell RightLower { get; }
        public WallType WallType { get; }

        public Wall(Cell leftUpper, Cell rightUpper, Cell leftLower, Cell rightLower, WallType wallType)
        {
            LeftUpper = leftUpper;
            RightUpper = rightUpper;
            LeftLower = leftLower;
            RightLower = rightLower;
            WallType = wallType;
        }
    }

    public enum WallType
    {
        Horizontal,
        Vertical
    }
}
