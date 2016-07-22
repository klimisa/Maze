using System.IO.MemoryMappedFiles;
using System.Threading;
using Maze.Domain;
using Maze.Domain.PathFinder;
using Maze.Domain.Service;
using Maze.Repository;

namespace Maze.Application
{
    public class PathFinderService
    {
        private readonly IMazeMapRepository _mazeMapRepository;

        public PathFinderService() : this(new MazeMapRepository()) //Poor's man DI.
        {
            
        }

        public PathFinderService(IMazeMapRepository mazeMapRepository)
        {
            _mazeMapRepository = mazeMapRepository;
        }

        public ActorRoute FindPathFromFile(string filePath)
        {
            var map = _mazeMapRepository.GetMazeMap(filePath);
            var routeDiscovery = new RouteDiscovery(new BreadthFirstSearch());
            var actorRoute = routeDiscovery.FindActorRoute(map);
            return actorRoute;
        }
    }
}