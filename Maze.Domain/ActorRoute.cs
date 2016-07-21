using System.Collections.Generic;

namespace Maze.Domain
{
    public class ActorRoute
    {
        private readonly IEnumerable<MazePoint> _route;

        public ActorRoute(IEnumerable<MazePoint> route)
        {
            _route = route;
        }

        public override string ToString()
        {
            return $"({string.Join(", ", _route)})";
        }
    }
}