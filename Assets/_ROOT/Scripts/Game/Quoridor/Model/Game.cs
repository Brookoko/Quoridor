namespace Quoridor.Model
{
    public class Game
    {
        public Field Field { get; }

        public Player Player { get; }

        public Bot Bot { get; }

        public bool HasFinished => Player.Cell.Y == 0 || Bot.Cell.Y == Field.Height - 1;

        public Game()
        {
            Field = new Field(9, 9);
            Player = new Player(Field[0, 0]);
            Bot = new Bot(Field[0, 0], new RandomMoveStrategy(Field));
        }
    }
}
