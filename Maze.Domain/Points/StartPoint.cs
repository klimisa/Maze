namespace Maze.Domain.Points
{
    public class StartPoint : MazePoint
    {
        public override MazePointStatus Status { get; } = MazePointStatus.Start;

        public StartPoint(int x, int y) : base(x, y)
        {
        }

        public override string ToString()
        {
            return $"({X + 1}:{Y + 1} (S))";
        }
    }
}