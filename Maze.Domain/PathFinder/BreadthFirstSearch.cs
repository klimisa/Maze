using System.Collections.Generic;
using Maze.Domain.Points;

namespace Maze.Domain.PathFinder
{
    public enum Direction
    {
        North,
        East,
        South,
        West
    }
    public enum LocationStatus
    {
        Invalid,
        Goal,
        Blocked,
        Valid,
        Start,
        Unknown
    }
    public class BreadthFirstSearch : IPathFinderStrategy
    {
        public List<MazePoint> FindPath(MazePoint startPoint, MazePoint[,] map)
        {
            var distanceFromTop = startPoint.X ;
            var distanceFromLeft = startPoint.Y;

            var location = new Location(distanceFromTop, distanceFromLeft, LocationStatus.Start);
            location.Path.AddRange(new List<MazePoint> { startPoint });

            var queue = new Queue<Location>();
            queue.Enqueue(location);

            Location newLocation;
            while (queue.Count > 0)
            {
                var currentLocation = queue.Dequeue();

                // Explore North
                newLocation = ExporeInDirection(currentLocation, Direction.North, map);
                if (newLocation.Status == LocationStatus.Goal)
                    return newLocation.Path;
                if (newLocation.Status == LocationStatus.Valid)
                    queue.Enqueue(newLocation);

                // Explore East
                newLocation = ExporeInDirection(currentLocation, Direction.East, map);
                if (newLocation.Status == LocationStatus.Goal)
                    return newLocation.Path;
                if (newLocation.Status == LocationStatus.Valid)
                    queue.Enqueue(newLocation);

                // Explore South
                newLocation = ExporeInDirection(currentLocation, Direction.South, map);
                if (newLocation.Status == LocationStatus.Goal)
                    return newLocation.Path;
                if (newLocation.Status == LocationStatus.Valid)
                    queue.Enqueue(newLocation);

                // Explore West
                newLocation = ExporeInDirection(currentLocation, Direction.West, map);
                if (newLocation.Status == LocationStatus.Goal)
                    return newLocation.Path;
                if (newLocation.Status == LocationStatus.Valid)
                    queue.Enqueue(newLocation);

            }

            return location.Path;
        }

        private Location ExporeInDirection(Location currentLocation, Direction direction, MazePoint[,] mazeMap)
        {
            var x = currentLocation.DistanceFromTop;
            var y = currentLocation.DistanceFromLeft;

            switch (direction)
            {
                case Direction.North:
                    x -= 1;
                    break;
                case Direction.East:
                    y += 1;
                    break;
                case Direction.South:
                    x += 1;
                    break;
                case Direction.West:
                    y -= 1;
                    break;
            }

            var newLocation = new Location(x, y, LocationStatus.Unknown);
            newLocation.Status = CheckLocationStatus(newLocation, mazeMap);

            if (newLocation.Status == LocationStatus.Valid || newLocation.Status == LocationStatus.Goal)
            {
                mazeMap[x, y].IsVisited = true;
                newLocation.Path.AddRange(new List<MazePoint>(currentLocation.Path) {mazeMap[x, y]});
            }


            return newLocation;
        }

        private LocationStatus CheckLocationStatus(Location location, MazePoint[,] map)
        {
            var mapSizeAxisX = map.GetLength(0);
            var mapSizeAxisY = map.GetLength(1);

            var x = location.DistanceFromTop;
            var y = location.DistanceFromLeft;

            if (y < 0 || y >= mapSizeAxisY || x < 0 || x >= mapSizeAxisX)
                return LocationStatus.Invalid;

            if (map[x,y].Status == MazePointStatus.Goal)
                return LocationStatus.Goal;

            if (map[x,y].Status != MazePointStatus.Empty || map[x,y].IsVisited)
                return LocationStatus.Blocked;

            return LocationStatus.Valid;
        }
    }
    public class Location
        {
            public int DistanceFromTop { get; private set; }
            public int DistanceFromLeft { get; private set; }
            public List<MazePoint> Path { get; set; }
            public LocationStatus Status { get; set; }

            public Location(int distanceFromTop, int distanceFromLeft, LocationStatus status)
            {
                DistanceFromTop = distanceFromTop;
                DistanceFromLeft = distanceFromLeft;
                Path = new List<MazePoint>();
                Status = status;
            }
        }
}