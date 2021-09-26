namespace Quoridor.Views
{
    using Controller;
    using Model;
    using UnityEngine;

    public class GameView : MonoBehaviour
    {
        [SerializeField]
        private FieldControllerView fieldControllerView;

        [SerializeField]
        private CharacterView playerPrefab;

        [SerializeField]
        private CharacterView botPrefab;

        private IGameProvider gameProvider;
        private CharacterView player;
        private CharacterView bot;

        public void Initialize(IGameProvider gameProvider, IGameController gameController)
        {
            CreateCharacters(gameProvider.Game);
            fieldControllerView.SetupInitialView(gameProvider.Game.Field);
            fieldControllerView.UpdatePosition(player);
            fieldControllerView.UpdatePosition(bot);
            gameController.OnMoveMade += OnMoveMade;
        }

        private void CreateCharacters(Game game)
        {
            player = Instantiate(playerPrefab, transform);
            player.Initialize(game.FirstPlayer);
            bot = Instantiate(botPrefab, transform);
            bot.Initialize(game.SecondPlayer);
        }

        private void OnMoveMade(Field field)
        {
            fieldControllerView.UpdateField(field);
            fieldControllerView.UpdatePosition(player);
            fieldControllerView.UpdatePosition(bot);
        }
    }
}
