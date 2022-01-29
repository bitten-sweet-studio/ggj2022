using System.Collections.Generic;
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
    private LevelCellGridMB _grid;

    [SerializeField]
    private LevelEditorMB _levelEditor;

    [Button]
    public void Save()
    {
        LevelTemplateSO levelTemplate = ScriptableObject.CreateInstance<LevelTemplateSO>();
        levelTemplate.Cells = _grid.Grid
            .Where(x => x.Layers.Count > 0)
            .Map(ExtractCellSaveData)
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

    private LevelCellSaveData ExtractCellSaveData(LevelCell levelCell)
    {
        return new LevelCellSaveData
        {
            Layers = ExtractLayerSaveData(levelCell.Layers).ToList(),
            X = levelCell.X,
            Y = levelCell.Y
        };
    }

    private IEnumerable<LevelLayerSaveData> ExtractLayerSaveData(IEnumerable<LevelCellLayer> layers)
    {
        return layers
            .Map(x => new LevelLayerSaveData
            {
                ID = x.Block.Id,
            });
    }
}