namespace Maze.Domain.Service
{
    public interface IMazeMapRepository
    {
        MazeMap GetMazeMap(string filePath);
    }
}