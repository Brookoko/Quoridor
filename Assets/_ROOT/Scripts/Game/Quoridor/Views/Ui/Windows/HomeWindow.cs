namespace Quoridor.Views.Ui.Windows
{
    using UnityEngine;
    using UnityEngine.UI;

    public class HomeWindow : Window
    {
        [SerializeField]
        private Button playButton;

        private GameLoader gameLoader;

        public void Initialize(GameLoader gameLoader)
        {
            this.gameLoader = gameLoader;
            playButton.onClick.AddListener(OnPlayButtonClick);
        }

        private void OnPlayButtonClick()
        {
            gameLoader.CreateNewGame();
            Close();
        }
    }
}
