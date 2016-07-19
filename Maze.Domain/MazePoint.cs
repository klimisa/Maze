using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Domain
{
    public enum MazePointStatus
    {
        Unwalkable = 0,
        Walkable = 1,
        Start= 2,
        End = 3
    }

    public class MazePoint
    {
        public int X { get; set; }
        public int Y { get; set; }
        public MazePointStatus Status { get; private set; }
        public MazePoint(int x, int y, MazePointStatus status)
        {
            X = x;
            Y = y;
            Status = status;
        }
    }
}
