namespace Quoridor.Views
{
    using Model;
    using UnityEngine;

    public class CharacterView : MonoBehaviour
    {
        public Character Character { get; private set; }

        public void Initialize(Character character)
        {
            Character = character;
        }
    }
}
