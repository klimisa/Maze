using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Maze.Domain.PathFinder;
using Maze.Domain.Points;

namespace Maze.Domain
{
 

    public class RouteDiscovery
    {
        private readonly IPathFinderStrategy _pathFinder;

        public RouteDiscovery(IPathFinderStrategy pathFinder)
        {
            _pathFinder = pathFinder;
        }

        //TODO: Add TEST
        public ActorRoute FindActorRoute(MazeMap mazeMap)
        {
            return new ActorRoute(_pathFinder.FindPath(mazeMap.Start, mazeMap.Map));
        }
    }
}