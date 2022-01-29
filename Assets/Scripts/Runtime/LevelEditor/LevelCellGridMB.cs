namespace niscolas.UnityUtils.Tools
{
    public class LevelCellGridMB : GridMB<LevelCell>
    {
        protected override LevelCell CreateCell(int x, int y, Grid<LevelCell> grid)
        {
            return new LevelCell(x, y, grid);
        }
    }
}