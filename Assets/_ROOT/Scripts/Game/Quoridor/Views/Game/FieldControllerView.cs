namespace Quoridor.Views
{
    using Model;
    using UnityEngine;

    public class FieldControllerView : MonoBehaviour
    {
        [SerializeField]
        private FieldView fieldView;

        public void SetupInitialView(Field field)
        {
            fieldView.Setup(field);
        }

        public void UpdateField(Field field)
        {
            fieldView.Render(field);
        }

        public void UpdatePosition(CharacterView characterView)
        {
            var position = fieldView.GetPositionFor(characterView.Character.Cell);
            characterView.transform.position = position;
        }
    }
}
