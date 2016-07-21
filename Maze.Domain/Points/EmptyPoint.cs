namespace Maze.Domain.Points
{
    public class EmptyPoint : MazePoint
    {
        public override MazePointStatus Status { get; } = MazePointStatus.Empty;

        public EmptyPoint(int x, int y) : base(x, y)
        {
        }
    }
}
