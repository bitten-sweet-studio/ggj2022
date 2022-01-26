using System;
using UnityEngine;

[Serializable]
public class BlockSaveData
{
    [SerializeField]
    private string _id;

    [SerializeField]
    private int _x;
    
    [SerializeField]
    private int _y;

    public string ID
    {
        get => _id;
        set => _id = value;
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