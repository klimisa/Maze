using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Maze.Domain.Tests
{
    public class PathTests
    {
        [Test]
        public void ActorRouteToString()
        {
            var foundPath = new List<MazePoint>
            {
                MazePoint.CreateStartPoint(0,0),
                MazePoint.CreateWalkablePoint(0,1),
                MazePoint.CreateWalkablePoint(0,2),
                MazePoint.CreateGoalPoint(0,3),
            };

            var actorRoute = new ActorRoute(foundPath);

            var output = @"((1:1 (S)), (1:2), (1:3), (1:4 (G)))";

            Assert.AreEqual(output, actorRoute.ToString());
        }
    }
}