namespace Quoridor.Views
{
    using J2N.Collections.Generic;
    using Model;
    using UnityEngine;

    public class FieldView : MonoBehaviour
    {
        [SerializeField]
        private CellView cellPrefab;

        [SerializeField]
        private Transform cellParent;

        [Header("Settings")]
        [SerializeField]
        private float cellSize;

        [SerializeField]
        private float padding;

        private readonly List<CellView> cells = new List<CellView>();

        public void Setup(Field field)
        {
            foreach (var cell in field.Cells)
            {
                var cellView = CreateViewFor(cell);
                cells.Add(cellView);
            }
        }

        private CellView CreateViewFor(Cell cell)
        {
            var cellView = Instantiate(cellPrefab, cellParent);
            cellView.transform.localScale = Vector3.one * cellSize;
            cellView.transform.localPosition = new Vector3(cell.X, 0, cell.Y) * (cellSize + padding);
            cellView.Initialize(cell);
            return cellView;
        }

        public void Render(Field field)
        {
            foreach (var cellView in cells)
            {
                cellView.UpdateView();
            }
        }
    }
}
