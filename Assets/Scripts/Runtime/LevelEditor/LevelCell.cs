using System.Collections.Generic;
using System.Linq;
using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.Tools;
using UnityEngine;

public class LevelCell
{
    public int X { get; }

    public int Y { get; }

    public Grid<LevelCell> Grid { get; }

    public List<LevelCellLayer> Layers { get; private set; } = new List<LevelCellLayer>();

    public static readonly IDespawnService DespawnService = new UnityDestroyService();

    public LevelCell(int x, int y, Grid<LevelCell> grid)
    {
        X = x;
        Y = y;
        Grid = grid;
    }

    public Vector3 GetWorldPosition()
    {
        return Grid.GetWorldPosition(X, Y);
    }

    public void SetBlock(BlockMB block)
    {
        SetBlock(block.LayerNumber, block);
    }

    public void SetBlock(int layerNumber, BlockMB block)
    {
        LevelCellLayer layer = GetLayerWithNumber(layerNumber);

        if (layer != null)
        {
            layer.SetBlock(block);
        }
        else
        {
            Layers.Add(CreateLayerAndSetBlock(layerNumber, block));
        }

        Vector3 position = GetWorldPosition();
        position.z = block.LayerDepth;
        block.transform.position = position;
    }

    public void ForceNotifyGrid()
    {
        Grid.ForceNotifyChanged(X, Y);
    }

    public void DestroyLayer(int layerNumber)
    {
        if (TryGetLayerWithNumber(layerNumber, out LevelCellLayer layer))
        {
            layer.Destroy();
        }
    }

    public IEnumerable<LevelCellLayer> GetLayersWithBlocks()
    {
        return Layers.Where(x => x.Block);
    }

    public IEnumerable<BlockMB> GetBlocks()
    {
        return GetLayersWithBlocks().Select(x => x.Block);
    }

    public LevelCellLayer GetTopMostLayer()
    {
        return Layers.OrderByDescending(x => x.Number).FirstOrDefault();
    }

    public bool TryGetTopMostLayer(out LevelCellLayer topMostLayer)
    {
        topMostLayer = GetTopMostLayer();
        return topMostLayer != null;
    }

    private LevelCellLayer CreateLayerAndSetBlock(int layerNumber, BlockMB block)
    {
        LevelCellLayer layer = new LevelCellLayer
        {
            Cell = this,
            Number = layerNumber
        };
        layer.SetBlock(block);
        return layer;
    }

    private bool TryGetLayerWithNumber(int layerNumber, out LevelCellLayer layer)
    {
        layer = GetLayerWithNumber(layerNumber);
        return layer != null;
    }

    private LevelCellLayer GetLayerWithNumber(int number)
    {
        return Layers.FirstOrDefault(x => x.Number == number);
    }
}