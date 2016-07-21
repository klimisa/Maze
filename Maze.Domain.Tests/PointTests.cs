using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Maze.Domain.Tests
{
    public class PointTests
    {
        [Test]
        public void StartPointToString()
        {
            var point = MazePoint.CreateStartPoint(0, 0);
            var output = @"(1:1 (S))";

            Assert.AreEqual(output, point.ToString());
        }

        [Test]
        public void GoalPointToString()
        {
            var point = MazePoint.CreateGoalPoint(0, 0);
            var output = @"(1:1 (G))";

            Assert.AreEqual(output, point.ToString());
        }

        [Test]
        public void WalkablePointToString()
        {
            var point = MazePoint.CreateWalkablePoint(0, 0);
            var output = @"(1:1)";

            Assert.AreEqual(output, point.ToString());
        }
    }
}
