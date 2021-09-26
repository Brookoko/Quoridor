namespace Quoridor.Model.Moves
{
    public class WallMove : Move
    {
        private readonly Character character;
        private readonly Wall wall;

        public WallMove(Field field, Character character, Wall wall) : base(field)
        {
            this.character = character;
            this.wall = wall;
        }

        public override bool IsValid()
        {
            return character.HasWalls();
        }

        public override void Execute()
        {
            character.UseWall();
            field.AddWall(wall);
        }

        public override void Undo()
        {
            character.RestoreWall();
            field.RemoveWall(wall);
        }
    }
}
