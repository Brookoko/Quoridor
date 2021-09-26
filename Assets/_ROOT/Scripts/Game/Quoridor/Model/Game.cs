namespace Quoridor.Model
{
    using Strategies;

    public class Game
    {
        public Field Field { get; }

        public Character FirstPlayer { get; }

        public Character SecondPlayer { get; }

        public bool HasFinished => FirstPlayer.Cell.Y == 0 || SecondPlayer.Cell.Y == Field.Height - 1;

        public Game(GameOptions gameOptions)
        {
            Field = new Field(9, 9);
            FirstPlayer = new Player(Field[0, 4], new ManualStrategy(Field));
            SecondPlayer = CreateSecondPlayer(gameOptions);
            SecondPlayer = new Bot(Field[8, 4], new RandomMoveStrategy(Field));
        }

        private Character CreateSecondPlayer(GameOptions gameOptions)
        {
            var position = Field[4, 8];
            if (gameOptions.gameMode == GameMode.VersusPlayer)
            {
                return new Player(position, new ManualStrategy(Field));
            }
            return new Bot(position, GetStrategyFor(gameOptions.botDifficulty));
        }

        private MoveStrategy GetStrategyFor(BotDifficulty botDifficulty)
        {
            return new RandomMoveStrategy(Field);
        }
    }
}
