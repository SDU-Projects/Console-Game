namespace Maze.Models;

public class Player
{
    public Position CurrentPosition { get; private set; }

    public Player(Position startPosition)
    {
        CurrentPosition = startPosition;
    }

    public void MoveTo(Position newPosition)
    {
        CurrentPosition = newPosition;
    }
}
