using System.Threading;
using Maze.Domain;
using Maze.Repository;

namespace Maze.Application
{
    public class PathFinderService
    {
        private readonly IPathFinder _pathFinder;
        private readonly IMazeMapRepository _mazeMapRepository;

        public PathFinderService() : this(new SimplePathFinder(), new MazeMapRepository()) //Poor's man DI.
        {
            
        }

        public PathFinderService(IPathFinder pathFinder, IMazeMapRepository mazeMapRepository)
        {
            _pathFinder = pathFinder;
            _mazeMapRepository = mazeMapRepository;
        }

        public string FindPathFromFile(string filePath)
        {
            var map = _mazeMapRepository.GetMazeMap(filePath);
            return _pathFinder.FindPath(map);
        }
    }
}