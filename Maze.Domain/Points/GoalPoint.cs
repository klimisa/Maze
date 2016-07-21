namespace Maze.Domain.Points
{
    public class GoalPoint : MazePoint
    {
        public override MazePointStatus Status { get; } = MazePointStatus.Goal;

        public GoalPoint(int x, int y) : base(x, y)
        {
        }
        public override string ToString()
        {
            return $"({X + 1}:{Y + 1} (G))";
        }
    }
}