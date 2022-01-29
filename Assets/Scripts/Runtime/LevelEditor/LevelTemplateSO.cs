using System.Collections.Generic;
using UnityEngine;

public class LevelTemplateSO : ScriptableObject
{
    [SerializeField]
    private List<LevelCellSaveData> _cells;

    public List<LevelCellSaveData> Cells
    {
        get => _cells;
        set => _cells = value;
    }
}