namespace niscolas.UnityUtils.Tools
{
    public class LevelCellLayer
    {
        public int Number { get; set; }

        public BlockMB Block { get; private set; }

        public LevelCell Cell { get; set; }

        public void SetBlock(BlockMB block)
        {
            Destroy();
            Block = block;
            Cell.ForceNotifyGrid();
        }

        public void Destroy()
        {
            if (!Block)
            {
                return;
            }

            LevelCell.DespawnService.Despawn(Block.gameObject);
            Cell.ForceNotifyGrid();
        }
    }
}