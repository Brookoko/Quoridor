namespace Quoridor.Views.Ui.Windows
{
    using System.Threading.Tasks;
    using UnityEngine;

    public abstract class Window : MonoBehaviour
    {
        [SerializeField]
        private UiFader fader;

        private void Awake()
        {
            fader = fader ? fader : gameObject.AddComponent<DefaultFader>();
        }

        public async Task Show()
        {
            await fader.FadeIn();
            OnWindowOpened();
        }

        protected virtual void OnWindowOpened()
        {
        }

        public async Task Hide()
        {
            await fader.FadeOut();
        }

        public async Task Close()
        {
            await fader.FadeOut();
            Destroy(gameObject);
        }
    }
}
