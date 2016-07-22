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

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            MazePoint p = obj as MazePoint;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (X == p.X) && (Y == p.Y);
        }


        public override int GetHashCode()
        {
            return X ^ Y;
        }
    }
}
