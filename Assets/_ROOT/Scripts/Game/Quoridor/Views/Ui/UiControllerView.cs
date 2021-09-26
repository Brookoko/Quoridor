namespace Quoridor.Views.Ui
{
    using Windows;
    using Controller;
    using UnityEngine;

    public class UiControllerView : MonoBehaviour, IUiController
    {
        [SerializeField]
        private UiBuilder uiBuilder;

        private GameLoader gameLoader;

        public void Initialize(IUiControllerProxy uiControllerProxy, GameLoader gameLoader)
        {
            this.gameLoader = gameLoader;
            uiControllerProxy.Wrap(this);
        }

        public void ShowHomeScreen()
        {
            var homeWindow = uiBuilder.CreateWindow<HomeWindow>();
            homeWindow.Initialize(gameLoader);
        }

        public void ShowGameScreen()
        {
            var gameWindow = uiBuilder.CreateWindow<GameWindow>();
        }

        public void ShowResultScreen()
        {
            var resultWindow = uiBuilder.CreateWindow<ResultWindow>();
        }
    }
}
