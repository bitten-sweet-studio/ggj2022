using System.Collections.Generic;
using System.Linq;
using niscolas.UnityUtils.Core;
using UnityEngine;

public class BlockDirectoryMB : CachedMB
{
    [SerializeField]
    private List<BlockMB> _content = new List<BlockMB>();

    public BlockMB FirstWithId(string id)
    {
        return _content.FirstOrDefault(x => x.Id == id);
    }
}