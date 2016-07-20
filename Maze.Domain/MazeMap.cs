namespace Maze.Domain
{
    public class MazeMap
    {
        public MazePoint Start { get; private set; }
        public MazePoint Goal { get; private set; }
        public MazePoint[][] Map { get; private set; }

        public MazeMap(MazePoint start, MazePoint goal, MazePoint[][] map)
        {
            //TODO: Invariants checks
            // Map must be at least 2 x 2
            // Map must have one start & goal point

            Start = start;
            Goal = goal;
            Map = map;
        }
    }
}