using System.Security.Cryptography.X509Certificates;

namespace Maze.Domain
{
    public interface IPathFinder
    {
        string FindPath(MazePoint start, MazePoint end, MazePoint [][] maze);
    }
}