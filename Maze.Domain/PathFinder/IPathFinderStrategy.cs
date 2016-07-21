using System.Collections.Generic;
using Maze.Domain.Points;

namespace Maze.Domain.PathFinder
{
    public interface IPathFinderStrategy
    {
        List<MazePoint> FindPath(MazePoint startPoint, MazePoint[,] map);
    }
}