using NaughtyAttributes;
using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.Core.Extensions;
using niscolas.UnityUtils.Tools;
using UnityEngine;

public class LevelEditorLoadManagerMB : CachedMB
{
    [SerializeField]
    private LevelEditorMB _levelEditor;

    [SerializeField]
    private LevelCellGridMB _grid;

    [SerializeField]
    private BlockDirectoryMB _blockDirectory;

    [SerializeField]
    private LevelTemplateSO _levelTemplate;

    [Button]
    public void Load()
    {
        Load(_levelTemplate);
    }

    public void Load(LevelTemplateSO levelTemplate)
    {
        levelTemplate.Cells.ForEach(LoadLevelCell);
    }

    private void LoadLevelCell(LevelCellSaveData levelCellSaveData)
    {
        levelCellSaveData.Layers
            .ForEach(x => LoadLevelLayer(levelCellSaveData, x));
    }

    private void LoadLevelLayer(
        LevelCellSaveData levelCellSaveData, LevelLayerSaveData levelLayerSaveData)
    {
        BlockMB blockPrefab = _blockDirectory.FirstWithId(levelLayerSaveData.ID);

        if (!_grid.Grid.TryGet(levelCellSaveData.X, levelCellSaveData.Y, out LevelCell levelCell))
        {
            return;
        }

        BlockMB blockInstance = LevelEditorMB.SpawnService.Spawn(blockPrefab, _levelEditor.BlocksParent);
        levelCell.SetBlock(blockInstance);
    }
}