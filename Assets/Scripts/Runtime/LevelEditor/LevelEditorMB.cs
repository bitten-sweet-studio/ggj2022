using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.Tools;
using UnityEngine;

public class LevelEditorMB : CachedMB
{
    [SerializeField]
    private LevelCellGridMB _grid;

    [SerializeField]
    private Transform _blocksParent;

    public Transform BlocksParent => _blocksParent;

    public static readonly ISpawnService SpawnService = new UnityInstantiateService();

    public void Place(int layerNumber, BlockMB blockPrefab, Vector3 worldPosition)
    {
        if (!_grid.Grid.TryGetByWorldPosition(worldPosition, out LevelCell levelCell))
        {
            return;
        }

        levelCell.SetBlock(
            SpawnService.Spawn(blockPrefab, levelCell.GetWorldPosition(), Quaternion.identity, _blocksParent));
    }

    public void EraseTopMostLayer(Vector3 worldPosition)
    {
        if (!_grid.Grid.TryGetByWorldPosition(worldPosition, out LevelCell levelCell))
        {
            return;
        }

        if (levelCell.TryGetTopMostLayer(out LevelCellLayer topMostLayer))
        {
            topMostLayer.Destroy();
        }
    }

    public void Erase(int layerNumber, Vector3 worldPosition)
    {
        if (!_grid.Grid.TryGetByWorldPosition(worldPosition, out LevelCell blockContainer))
        {
            return;
        }

        blockContainer.DestroyLayer(layerNumber);
    }
}