using System;
using System.Collections.Generic;
using System.Linq;
using Maze.Domain.Points;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Maze.Domain.Tests
{
    public class ActorRouteTests
    {
        [Test]
        public void ActorRouteToString()
        {
            var foundPath = new List<MazePoint>
            {
                new StartPoint(0,0),
                new EmptyPoint(1,0),
                new EmptyPoint(2,0),
                new EmptyPoint(3,0),                      
                new EmptyPoint(4,0),
                new EmptyPoint(4,1),
                new EmptyPoint(4,2),
                new EmptyPoint(3,2),
                new EmptyPoint(3,3),
                new GoalPoint (3,4)
            };

            var actorRoute = new ActorRoute(foundPath);

            var output = @"(1:1 (S)), (2:1), (3:1), (4:1), (5:1), (5:2), (5:3), (4:3), (4:4), (4:5 (G))";

            Assert.AreEqual(output, actorRoute.ToString());
        }
    }
}