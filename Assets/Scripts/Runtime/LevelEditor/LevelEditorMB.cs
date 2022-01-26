using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.Tools;
using UnityEngine;

public class LevelEditorMB : CachedMB
{
    [SerializeField]
    private BlockContainerGridMB _grid;

    [SerializeField]
    private Transform _blocksParent;

    public Transform BlocksParent => _blocksParent;

    public static readonly ISpawnService SpawnService = new UnityInstantiateService();

    public void Place(BlockMB blockPrefab, Vector3 worldPosition)
    {
        if (!_grid.Grid.TryGetByWorldPosition(worldPosition, out BlockContainer blockContainer))
        {
            return;
        }

        blockContainer.SetBlock(SpawnService.Spawn(blockPrefab, _blocksParent));
    }

    public void Erase(Vector3 worldPosition)
    {
        if (!_grid.Grid.TryGetByWorldPosition(worldPosition, out BlockContainer blockContainer))
        {
            return;
        }

        blockContainer.Destroy();
    }
}