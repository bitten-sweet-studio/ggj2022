using niscolas.UnityUtils.Core;
using UnityEngine;

namespace niscolas.UnityUtils.Tools
{
    public class LineGridVisualMB : AutoTriggerMB
    {
        [SerializeField]
        private GridMB _grid;

        [SerializeField]
        private GameObject _cellPrefab;

        [SerializeField]
        private Transform _cellsParent;

        public override void Do()
        {
            SetGrid(_grid.BaseGrid);
        }

        private void OnEnable()
        {
            _cellsParent.gameObject.SetActive(true);
        }

        private void OnDisable()
        {
            _cellsParent.gameObject.SetActive(false);
        }

        public void SetGrid(Grid grid)
        {
            GridCreatorUtility.Create(
                _cellPrefab,
                new Vector3Int(grid.Width, grid.Height, 1),
                Vector3.one,
                _cellsParent);
        }
    }
}