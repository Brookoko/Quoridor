namespace Quoridor.Model.Moves
{
    public class DefaultMove : Move
    {
        public DefaultMove(Field field) : base(field)
        {
        }

        public override bool IsValid()
        {
            return false;
        }

        public override void Execute()
        {
        }

        public override void Undo()
        {
        }
    }
}
