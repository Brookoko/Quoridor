namespace Quoridor.Views
{
    using Model;
    using UnityEngine;

    public class CellView : MonoBehaviour
    {
        public Cell Cell { get; private set; }

        public void Initialize(Cell cell)
        {
            Cell = cell;
        }

        public void UpdateView()
        {
        }
    }
}
