using System;
using Maze.Domain.Points;

namespace Maze.Domain.Service
{
    public class MazeMap
    {
        public MazePoint Start { get; private set; }
        public MazePoint[,] Map { get; private set; }
        public MazeMap(MazePoint start, MazePoint goal, MazePoint[,] map)
        {
            if (map.GetLength(0) < 2 || map.GetLength(1) < 2)
            {
                throw new ArgumentException("Map must be at least 2 x 2.");
            }

            if (start.Equals(goal))
            {
                throw new ArgumentException("Start and Goal must not be same the same point.");
            }

            Start = start;
            Map = map;
        }
    }
}