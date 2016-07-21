using System.Runtime.CompilerServices;

namespace Maze.Domain.Points
{
    public enum MazePointStatus
    {
        Start,
        Goal,
        WallBlock,
        Empty
    }

    public abstract class MazePoint
    {
        public int X { get; }
        public int Y { get;  }

        public bool IsVisited { get; set; }

        public abstract MazePointStatus Status { get; }

        protected MazePoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X + 1}:{Y + 1})";
        }
    }
}
