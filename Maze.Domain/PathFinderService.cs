using System.Threading;

namespace Maze.Domain
{
    public class PathFinderService
    {
        private readonly IPathFinder _pathFinder;

        public PathFinderService() : this(new SimplePathFinder()) //Poor's man DI.
        {
            
        }

        public PathFinderService(IPathFinder pathFinder)
        {
            _pathFinder = pathFinder;
        }

        public string FindPath()
        {
            return _pathFinder.FindPath(null, null, new MazePoint[][] {} );
        }
    }
}