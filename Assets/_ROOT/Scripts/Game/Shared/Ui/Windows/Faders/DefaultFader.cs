namespace Quoridor.Views.Ui.Windows
{
    using System.Threading.Tasks;

    public class DefaultFader : UiFader
    {
        public override Task FadeIn()
        {
            gameObject.SetActive(true);
            return Task.CompletedTask;
        }

        public override Task FadeOut()
        {
            gameObject.SetActive(false);
            return Task.CompletedTask;
        }
    }
}
