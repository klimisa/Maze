namespace Maze.Domain
{
    public interface IMazeMapRepository
    {
        MazeMap GetMazeMap(string filePath);
    }
}