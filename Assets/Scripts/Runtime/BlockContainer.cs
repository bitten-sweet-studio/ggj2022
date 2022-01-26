using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.Tools;

public class BlockContainer
{
    public int X { get; }

    public int Y { get; }

    public Grid<BlockContainer> Grid { get; }

    public BlockMB Block { get; private set; }

    private static readonly IDespawnService DespawnService = new UnityDestroyService();

    public BlockContainer(int x, int y, Grid<BlockContainer> grid)
    {
        X = x;
        Y = y;
        Grid = grid;
    }

    public void SetBlock(BlockMB block)
    {
        Destroy();
        Block = block;
        Grid.ForceNotifyChanged(X, Y);
    }

    public void Destroy()
    {
        if (!Block)
        {
            return;
        }

        DespawnService.Despawn(Block.gameObject);
        Grid.ForceNotifyChanged(X, Y);
    }
}