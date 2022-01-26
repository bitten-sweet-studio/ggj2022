using System.Collections.Generic;
using UnityEngine;

public class LevelTemplateSO : ScriptableObject
{
    [SerializeField]
    private List<BlockSaveData> _blocks;

    public List<BlockSaveData> Blocks
    {
        get => _blocks;
        set => _blocks = value;
    }
}