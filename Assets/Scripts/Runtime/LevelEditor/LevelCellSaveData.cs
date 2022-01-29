using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelCellSaveData
{
    [SerializeField]
    private List<LevelLayerSaveData> _layers = new List<LevelLayerSaveData>();

    [SerializeField]
    private int _x;

    [SerializeField]
    private int _y;

    public List<LevelLayerSaveData> Layers
    {
        get => _layers;
        set => _layers = value;
    }

    public int X
    {
        get => _x;
        set => _x = value;
    }

    public int Y
    {
        get => _y;
        set => _y = value;
    }
}