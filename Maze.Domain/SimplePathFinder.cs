using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Maze.Domain
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

    public class SimplePathFinder : IPathFinder
    {
        public List<MazePoint> FindPath(MazeMap mazeMap)
        {
            var distanceFromTop = mazeMap.Start.Y;
            var distanceFromLeft = mazeMap.Start.X;

            var location = new Location(distanceFromTop, distanceFromLeft, new List<MazePoint>(), LocationStatus.Start);

            var queue = new Queue<Location>();
            queue.Enqueue(location);

            Location newLocation;
            while (queue.Count > 0)
            {
                var currentLocation = queue.Dequeue();

                // Explore North
                newLocation = ExporeInDirection(currentLocation, Direction.North, mazeMap.Map);
                if (newLocation.Status == LocationStatus.Goal)
                    return newLocation.Path;
                if (newLocation.Status == LocationStatus.Valid)
                    queue.Enqueue(newLocation);

                // Explore East
                newLocation = ExporeInDirection(currentLocation, Direction.East, mazeMap.Map);
                if (newLocation.Status == LocationStatus.Goal)
                    return newLocation.Path;
                if (newLocation.Status == LocationStatus.Valid)
                    queue.Enqueue(newLocation);

                // Explore South
                newLocation = ExporeInDirection(currentLocation, Direction.South, mazeMap.Map);
                if (newLocation.Status == LocationStatus.Goal)
                    return newLocation.Path;
                if (newLocation.Status == LocationStatus.Valid)
                    queue.Enqueue(newLocation);

                // Explore West
                newLocation = ExporeInDirection(currentLocation, Direction.West, mazeMap.Map);
                if (newLocation.Status == LocationStatus.Goal)
                    return newLocation.Path;
                if (newLocation.Status == LocationStatus.Valid)
                    queue.Enqueue(newLocation);

            }

            return null;
        }

        private Location ExporeInDirection(Location currentLocation, Direction direction, MazePoint[][] mazeMap)
        {
            var newPath = currentLocation.Path.Where(x => true).ToList();

            var dft = currentLocation.DistanceFromTop;
            var dfl = currentLocation.DistanceFromLeft;

            switch (direction)
            {
                case Direction.North:
                    dft -= 1;
                    break;
                case Direction.East:
                    dfl += 1;
                    break;
                case Direction.South:
                    dft += 1;
                    break;
                case Direction.West:
                    dfl -= 1;
                    break;
            }

            newPath.Add(MazePoint.CreateVisitedPoint(dfl, dft));
            var newLocation = new Location(dft, dfl, newPath, LocationStatus.Unknown);
            newLocation.Status = SetLocationStatus(newLocation, mazeMap);


            if (newLocation.Status == LocationStatus.Valid)
               mazeMap[newLocation.DistanceFromTop][newLocation.DistanceFromLeft] = 
                    MazePoint.CreateVisitedPoint(newLocation.DistanceFromTop, newLocation.DistanceFromLeft);


           return newLocation;
        }

        private LocationStatus SetLocationStatus(Location location, MazePoint[][] mazeMap)
        {
            var mapSize = mazeMap.Length;

            var dft = location.DistanceFromTop;
            var dfl = location.DistanceFromLeft;

            if (location.DistanceFromLeft < 0 || location.DistanceFromLeft >= mapSize ||
                location.DistanceFromTop < 0  || location.DistanceFromTop >= mapSize)
                return LocationStatus.Invalid;
         

            if (mazeMap[dft][dfl].Status == MazePointStatus.Goal)
                return LocationStatus.Goal;
          
            if (mazeMap[dft][dfl].Status != MazePointStatus.Unwalkable)
                // location is either an obstacle or has been visited
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

        public Location(int distanceFromTop, int distanceFromLeft, List<MazePoint> path, LocationStatus status)
        {
            DistanceFromTop = distanceFromTop;
            DistanceFromLeft = distanceFromLeft;
            Path = path;
            Status = status;
        }
    }
}