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

    public enum SquareStatus
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
            // Each "Square" will store its coordinates
            // and the shortest path required to arrive there
            var square = new Square(startPoint.X, startPoint.Y);
            square.Path.AddRange(new List<MazePoint> {startPoint});

            // Initialize the queue with the start Square already inside
            var queue = new Queue<Square>();
            queue.Enqueue(square);

            Square newSquare;
            while (queue.Count > 0)
            {
                var currentSquare = queue.Dequeue();

                // Explore North
                newSquare = ExporeInDirection(currentSquare, Direction.North, map);
                if (newSquare.Status == SquareStatus.Goal)
                    return newSquare.Path;
                if (newSquare.Status == SquareStatus.Valid)
                    queue.Enqueue(newSquare);

                // Explore East
                newSquare = ExporeInDirection(currentSquare, Direction.East, map);
                if (newSquare.Status == SquareStatus.Goal)
                    return newSquare.Path;
                if (newSquare.Status == SquareStatus.Valid)
                    queue.Enqueue(newSquare);

                // Explore South
                newSquare = ExporeInDirection(currentSquare, Direction.South, map);
                if (newSquare.Status == SquareStatus.Goal)
                    return newSquare.Path;
                if (newSquare.Status == SquareStatus.Valid)
                    queue.Enqueue(newSquare);

                // Explore West
                newSquare = ExporeInDirection(currentSquare, Direction.West, map);
                if (newSquare.Status == SquareStatus.Goal)
                    return newSquare.Path;
                if (newSquare.Status == SquareStatus.Valid)
                    queue.Enqueue(newSquare);

            }

            return square.Path;
        }

        // Explores the Map from the given Square in the given
        // direction
        private Square ExporeInDirection(Square currentSquare, Direction direction, MazePoint[,] mazeMap)
        {
            var x = currentSquare.X;
            var y = currentSquare.Y;

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

            return currentSquare.NewSquare(x, y, mazeMap); ;
        }
    }
}