using System.Collections.Generic;
using Maze.Domain.Points;

namespace Maze.Domain.PathFinder
{
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

        // This function will check a Square's status
        // (a Square is "valid" if it is on the Map, is not a "Block",
        // and has not yet been visited by our algorithm)
        // Returns "Valid", "Invalid", "Blocked", or "Goal"
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