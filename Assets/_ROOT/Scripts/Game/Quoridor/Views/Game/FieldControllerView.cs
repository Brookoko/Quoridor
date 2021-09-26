namespace Quoridor.Views
{
    using Controller;
    using Model;
    using UnityEngine;

    public class FieldControllerView : MonoBehaviour
    {
        [SerializeField]
        private FieldView fieldView;

        public void Initialize(IGameController gameController)
        {
            gameController.OnMoveMade += UpdateField;
        }

        public void SetupInitialView(Field field)
        {
            fieldView.Setup(field);
        }

        private void UpdateField(Field field)
        {
            fieldView.Render(field);
        }
    }
}
