using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Domain
{
    public enum MazePointStatus
    {
        Obstacle = 0,
        Walkable = 1,
        Start = 2,
        Goal = 3
    }

    public class MazePoint
    {
        public int X { get; set; }
        public int Y { get; set; }
        public MazePointStatus Status { get; private set; }
        private MazePoint(int x, int y, MazePointStatus status)
        {
            X = x;
            Y = y;
            Status = status;
        }

        public static MazePoint CreateStartPoint(int x, int y)
        {
            return new MazePoint(x, y, MazePointStatus.Start);
        }

        public static MazePoint CreateGoalPoint(int x, int y)
        {
            return new MazePoint(x, y, MazePointStatus.Goal);
        }

        public static MazePoint CreateWalkablePoint(int x, int y)
        {
            return new MazePoint(x, y, MazePointStatus.Walkable);
        }

        public static MazePoint CreateObstaclePoint(int x, int y)
        {
            return new MazePoint(x, y, MazePointStatus.Obstacle);
        }
    }
}
