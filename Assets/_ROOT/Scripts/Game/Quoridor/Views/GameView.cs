namespace Quoridor.Views
{
    using Controller;
    using UnityEngine;

    public class GameView : MonoBehaviour
    {
        [SerializeField]
        private FieldControllerView fieldControllerView;

        public void Initialize(IGameProvider gameProvider, IGameController gameController)
        {
            fieldControllerView.Initialize(gameController);
            fieldControllerView.SetupInitialView(gameProvider.Game.Field);
        }
    }
}
