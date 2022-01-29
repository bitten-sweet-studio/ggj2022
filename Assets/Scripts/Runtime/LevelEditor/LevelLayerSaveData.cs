using System;
using UnityEngine;

[Serializable]
public class LevelLayerSaveData
{
    [SerializeField]
    private string _id;

    public string ID
    {
        get => _id;
        set => _id = value;
    }
}