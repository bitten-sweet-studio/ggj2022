using niscolas.UnityUtils.Core;
using UnityEngine;

namespace niscolas.UnityUtils.Tools
{
    public class LineGridVisualMB : CachedMB
    {
        [SerializeField]
        private GridMB _grid;

        [SerializeField]
        private GameObject _cellPrefab;

        [SerializeField]
        private Transform _cellsParent;

        protected override void Awake()
        {
            base.Awake();

            _grid.InternalGridCreated += SetGrid;
        }

        private void OnDestroy()
        {
            _grid.InternalGridCreated -= SetGrid;
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