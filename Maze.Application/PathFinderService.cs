using System.IO.MemoryMappedFiles;
using System.Threading;
using Maze.Domain;
using Maze.Repository;

namespace Maze.Application
{
    public class PathFinderService
    {
        private readonly IRouteDiscovery _routeDiscovery;
        private readonly IMazeMapRepository _mazeMapRepository;

        public PathFinderService() : this(new SimpleRouteDiscovery(), new MazeMapRepository()) //Poor's man DI.
        {
            
        }

        public PathFinderService(IRouteDiscovery routeDiscovery, IMazeMapRepository mazeMapRepository)
        {
            _routeDiscovery = routeDiscovery;
            _mazeMapRepository = mazeMapRepository;
        }

        public ActorRoute FindPathFromFile(string filePath)
        {
            var map = _mazeMapRepository.GetMazeMap(filePath);
            var actorRoute = _routeDiscovery.FindActorRoute(map);
            return actorRoute;
        }
    }
}