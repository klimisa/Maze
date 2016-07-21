namespace Maze.Domain.Points
{
    public class WallPoint : MazePoint
    {
        public override MazePointStatus Status { get; } = MazePointStatus.WallBlock;

        public WallPoint(int x, int y) : base(x, y)
        {
        }
    }
}