using niscolas.UnityUtils.Core;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class BlockMB : CachedMB
{
    [SerializeField]
    private StringReference _id;

    public string Id => _id.Value;
}