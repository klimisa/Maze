using Maze.Domain.PathFinder;

namespace Maze.Domain.Service
{
 

    public class RouteDiscovery
    {
        private readonly IPathFinderStrategy _pathFinder;

        public RouteDiscovery(IPathFinderStrategy pathFinder)
        {
            _pathFinder = pathFinder;
        }

        public ActorRoute FindActorRoute(MazeMap mazeMap)
        {
            return new ActorRoute(_pathFinder.FindPath(mazeMap.Start, mazeMap.Map));
        }
    }
}