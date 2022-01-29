using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.Tools;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class BlockMB : CachedMB
{
    [SerializeField]
    private StringReference _id;

    [SerializeField]
    private LayerTypeSO _layerType;

    public string Id => _id.Value;

    public int LayerNumber => _layerType.LayerNumber;
    
    public float LayerDepth => _layerType.ZPosition;
}