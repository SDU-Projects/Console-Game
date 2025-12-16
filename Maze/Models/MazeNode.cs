using Maze.Enums;

namespace Maze.Models;

public class MazeNode
{
    public Position Position { get; }
    public Position? Up { get; set; }
    public Position? Down { get; set; }
    public Position? Left { get; set; }
    public Position? Right { get; set; }
    public MinigameType MinigameType { get; set; }

    public MazeNode(Position position)
    {
        Position = position;
        MinigameType = MinigameType.None;
    }
}
