using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maze.Domain.Points;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Maze.Domain.Tests
{
    public class PointTests
    {
        [Test]
        public void StartPointPrint()
        {
            var point = new StartPoint(0, 0);
            var output = @"(1:1 (S))";

            Assert.AreEqual(output, point.ToString());
        }

        [Test]
        public void GoalPointToPrint()
        {
            var point = new GoalPoint(0, 0);
            var output = @"(1:1 (G))";

            Assert.AreEqual(output, point.ToString());
        }

        [Test]
        public void PointEmptyOrWallBlockPrint()
        {
            var emptyPoint = new EmptyPoint(0, 0);

            var output = @"(1:1)";

            Assert.AreEqual(output, emptyPoint.ToString());
        }
    }
}
