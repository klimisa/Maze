using Maze.Domain.PathFinder;
using Maze.Domain.Points;
using Maze.Domain.Service;
using NUnit.Framework;

namespace Maze.Domain.Tests
{
    public class RouteDiscoveryTests
    {
        [Test]
        public void RouteDiscoveryFindActorRoute()
        {
            var startPoint = new StartPoint(0, 0);
            var goalPoint = new GoalPoint(3, 4);
            var mazeMap = new MazePoint[,]
            {
                { new StartPoint(0, 0), new EmptyPoint(0, 1), new EmptyPoint(0, 2), new EmptyPoint(0, 3), new WallPoint (0, 4) },
                { new EmptyPoint(1, 0), new EmptyPoint(1, 1), new WallPoint (1, 2), new WallPoint (1, 3), new EmptyPoint(1, 4)},
                { new EmptyPoint(2, 0), new EmptyPoint(2, 1), new WallPoint (2, 2), new EmptyPoint(2, 3), new EmptyPoint(2, 4)},
                { new EmptyPoint(3, 0), new WallPoint (3, 1), new EmptyPoint(3, 2), new EmptyPoint(3, 3), new GoalPoint (3, 4) },
                { new EmptyPoint(4, 0), new EmptyPoint(4, 1), new EmptyPoint(4, 2), new WallPoint (4, 3), new EmptyPoint(4, 4)}
            };
            
            var map = new MazeMap(startPoint, goalPoint, mazeMap);

            var routeDiscovery = new RouteDiscovery(new BreadthFirstSearch());
            var actorRoute = routeDiscovery.FindActorRoute(map);

            var output = @"(1:1 (S)), (2:1), (3:1), (4:1), (5:1), (5:2), (5:3), (4:3), (4:4), (4:5 (G))";

            Assert.AreEqual(output, actorRoute.ToString());
        }
    }
}