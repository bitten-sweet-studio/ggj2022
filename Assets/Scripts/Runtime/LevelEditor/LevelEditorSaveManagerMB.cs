using System.Linq;
using NaughtyAttributes;
using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.Core.Extensions;
using niscolas.UnityUtils.Tools;
using UnityEditor;
using UnityEngine;

public class LevelEditorSaveManagerMB : CachedMB
{
    [SerializeField]
    private BlockContainerGridMB _grid;

    [SerializeField]
    private LevelEditorMB _levelEditor;

    [Button]
    public void Save()
    {
        LevelTemplateSO levelTemplate = ScriptableObject.CreateInstance<LevelTemplateSO>();
        levelTemplate.Blocks = _grid.Grid
            .Where(x => !x.Block.IsUnityNull())
            .Map(ExtractBlockSaveData)
            .ToList();

        string fileSavePath = EditorUtility
            .SaveFilePanel(
                "Select the Level save path",
                "",
                "LevelTemplate-Name",
                "asset")
            .AsProjectRelativePath();

        levelTemplate.Create(fileSavePath);
    }

    private BlockSaveData ExtractBlockSaveData(BlockContainer blockContainer)
    {
        if (!blockContainer.Block)
        {
            return default;
        }

        return new BlockSaveData
        {
            ID = blockContainer.Block.Id,
            X = blockContainer.X,
            Y = blockContainer.Y
        };
    }
}