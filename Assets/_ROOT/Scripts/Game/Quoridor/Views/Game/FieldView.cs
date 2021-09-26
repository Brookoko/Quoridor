namespace Quoridor.Views
{
    using System.Collections.Generic;
    using System.Linq;
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

        private readonly List<CellView> cells = new();

        public void Setup(Field field)
        {
            for (var i = 0; i < field.Height; i++)
            {
                for (var j = 0; j < field.Width; j++)
                {
                    var cell = field[i, j];
                    var cellView = CreateViewFor(cell, field);
                    cells.Add(cellView);
                }
            }
        }

        private CellView CreateViewFor(Cell cell, Field field)
        {
            var cellView = Instantiate(cellPrefab, cellParent);
            cellView.transform.localScale = Vector3.one * cellSize;
            var mapPosition = new Vector3(cell.X - field.Width / 2, 0, cell.Y - field.Height / 2);
            cellView.transform.localPosition = mapPosition * (cellSize + padding);
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

        public Vector3 GetPositionFor(Cell cell)
        {
            var cellView = cells.First(c => c.Cell == cell);
            return cellView.transform.position;
        }
    }
}
