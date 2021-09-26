namespace Quoridor.Controller
{
    public interface IUiController
    {
        void ShowHomeScreen();

        void ShowGameScreen();

        void ShowResultScreen();
    }

    public interface IUiControllerProxy : IUiController
    {
        void Wrap(IUiController uiController);
    }

    public class UiController : IUiControllerProxy
    {
        private IUiController uiController;

        public void ShowHomeScreen()
        {
            uiController.ShowHomeScreen();
        }

        public void ShowGameScreen()
        {
            uiController.ShowGameScreen();
        }

        public void ShowResultScreen()
        {
            uiController.ShowResultScreen();
        }

        public void Wrap(IUiController uiController)
        {
            this.uiController = uiController;
        }
    }
}
