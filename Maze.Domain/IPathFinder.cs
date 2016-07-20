using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Maze.Domain
{
    public interface IPathFinder
    {
        List<MazePoint> FindPath(MazeMap map);
    }
}