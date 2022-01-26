using NaughtyAttributes;
using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.Tools;
using UnityEngine;

public class LevelEditorLoadManagerMB : CachedMB
{
    [SerializeField]
    private LevelEditorMB _levelEditor;

    [SerializeField]
    private BlockContainerGridMB _grid;

    [SerializeField]
    private BlockDirectoryMB _blockDirectory;

    [SerializeField]
    private LevelTemplateSO _levelToLoad;

    [Button]
    public void Load()
    {
        _levelToLoad.Blocks.ForEach(SpawnBlock);
    }

    private void SpawnBlock(BlockSaveData blockSaveData)
    {
        BlockMB blockPrefab = _blockDirectory.FirstWithId(blockSaveData.ID);

        if (!_grid.Grid.TryGet(blockSaveData.X, blockSaveData.Y, out BlockContainer blockContainer))
        {
            return;
        }

        BlockMB blockInstance = LevelEditorMB.SpawnService.Spawn(blockPrefab, _levelEditor.BlocksParent);
        blockContainer.SetBlock(blockInstance);
    }
}