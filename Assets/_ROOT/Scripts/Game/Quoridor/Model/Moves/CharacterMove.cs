namespace Quoridor.Model.Moves
{
    public class CharacterMove : Move
    {
        private readonly Character character;
        private readonly Cell from;
        private readonly Cell to;

        public CharacterMove(Field field, Character character, Cell to) : base(field)
        {
            this.character = character;
            from = character.Cell;
            this.to = to;
        }

        public override bool IsValid()
        {
            return true;
        }

        public override void Execute()
        {
            character.MoveTo(to);
        }

        public override void Undo()
        {
            character.MoveTo(from);
        }
    }
}
