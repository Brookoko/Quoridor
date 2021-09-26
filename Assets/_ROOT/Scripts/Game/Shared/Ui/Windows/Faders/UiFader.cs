namespace Quoridor.Views.Ui.Windows
{
    using System.Threading.Tasks;
    using UnityEngine;

    public abstract class UiFader : MonoBehaviour
    {
        public abstract Task FadeIn();

        public abstract Task FadeOut();
    }
}
