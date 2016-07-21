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
            var square = new Square(startPoint.X, startPoint.Y);
            square.Path.AddRange(new List<MazePoint> {startPoint});

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

    public class Square
    {
        public int X { get; }
        public int Y { get; }
        public List<MazePoint> Path { get; set; }
        public SquareStatus Status { get; set; }

        public Square(int x, int y)
        {
            X = x;
            Y = y;

            Path = new List<MazePoint>();
        }

        public Square NewSquare(int x, int y, MazePoint[,] map)
        {
            var newSquare = new Square(x, y);
            newSquare.Status = CheckNewSquare(newSquare, map);

            if (newSquare.Status == SquareStatus.Valid || newSquare.Status == SquareStatus.Goal)
            {
                map[x, y].IsVisited = true;
                newSquare.Path.AddRange(new List<MazePoint>(this.Path) { map[x, y] });
            }

            return newSquare;
        }

        private SquareStatus CheckNewSquare(Square square, MazePoint[,] map)
        {
            var mapSizeAxisX = map.GetLength(0);
            var mapSizeAxisY = map.GetLength(1);

            var x = square.X;
            var y = square.Y;

            if (y < 0 || y >= mapSizeAxisY || x < 0 || x >= mapSizeAxisX)
                return SquareStatus.Invalid;

            if (map[x, y].Status == MazePointStatus.Goal)
                return SquareStatus.Goal;

            if (map[x, y].Status != MazePointStatus.Empty || map[x, y].IsVisited)
                return SquareStatus.Blocked;

            return SquareStatus.Valid;
        }
    }
}