namespace Quoridor.Views
{
    using Controller;
    using Debug;
    using UnityEngine;

    public class UiControllerView : MonoBehaviour, IUiController
    {
        private GameLoader gameLoader;

        public void Initialize(IUiControllerProxy uiControllerProxy, GameLoader gameLoader)
        {
            this.gameLoader = gameLoader;
            uiControllerProxy.Wrap(this);
        }

        [EditorButton]
        public void ShowHomeScreen()
        {
            gameLoader.CreateNewGame();
        }

        public void ShowGameScreen()
        {
        }

        public void ShowResultScreen()
        {
        }
    }
}
