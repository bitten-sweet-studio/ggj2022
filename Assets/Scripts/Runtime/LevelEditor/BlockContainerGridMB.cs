namespace niscolas.UnityUtils.Tools
{
    public class BlockContainerGridMB : GridMB<BlockContainer>
    {
        private void OnDestroy()
        {
            Grid.ValueChanged -= Grid_OnValueChanged;
        }

        protected override void AfterGridCreated()
        {
            Grid.ValueChanged += Grid_OnValueChanged;
        }

        protected override BlockContainer CreateCell(int x, int y, Grid<BlockContainer> grid)
        {
            return new BlockContainer(x, y, grid);
        }

        private void Grid_OnValueChanged(int x, int y)
        {
            if (Grid.TryGet(x, y, out BlockContainer container) && container.Block)
            {
                container.Block.transform.position = Grid.GetWorldPosition(x, y);
            }
        }
    }
}