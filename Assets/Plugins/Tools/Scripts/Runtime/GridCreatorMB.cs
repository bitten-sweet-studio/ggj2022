using NaughtyAttributes;
using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.Core.Extensions;
using UnityEngine;

namespace niscolas.UnityUtils.Tools
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Grid Creator")]
    public class GridCreatorMB : CachedMB
    {
        [OnValueChanged(nameof(UpdateEditorMesh))]
        [SerializeField]
        private GameObject _tile;

        [OnValueChanged(nameof(UpdateEditorMesh))]
        [SerializeField]
        private Vector3Int _quantity;

        [OnValueChanged(nameof(UpdateEditorTilesPositions))]
        [SerializeField]
        private Vector3 _offset;

        [Header(HeaderTitles.Debug)]
        [ReadOnly, SerializeField]
        private GameObject[] _existingTiles;

        [ContextMenu(nameof(UpdateEditorMesh))]
        [Button]
        private void UpdateEditorMesh()
        {
            Clear();

            _existingTiles = GridCreatorUtility.Create(
                _tile,
                _quantity,
                _offset,
                transform);
        }

        [Button]
        private void UpdateEditorTilesPositions()
        {
            GridCreatorUtility.UpdateTilesPositions(_existingTiles, _quantity, _offset);
        }

        [Button]
        private void Clear()
        {
            transform.DestroyChildren();
        }
    }
}