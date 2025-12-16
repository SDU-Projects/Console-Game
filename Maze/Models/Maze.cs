using Maze.Enums;

namespace Maze.Models;

public class Maze
{
    private readonly Dictionary<Position, MazeNode> _nodes;
    private readonly Position _entrancePosition;
    private readonly Position _exitPosition;
    private readonly char[][] _visualRepresentation;

    public Position StartPosition { get; }

    public Maze(
        Dictionary<Position, MazeNode> nodes,
        char[][] visualRepresentation,
        Position startPosition,
        Position entrancePosition,
        Position exitPosition)
    {
        _nodes = nodes ?? throw new ArgumentNullException(nameof(nodes));
        _visualRepresentation = visualRepresentation ?? throw new ArgumentNullException(nameof(visualRepresentation));
        StartPosition = startPosition;
        _entrancePosition = entrancePosition;
        _exitPosition = exitPosition;
    }

    public Position? GetAdjacentPosition(Position current, Direction direction)
    {
        if (!_nodes.TryGetValue(current, out var node))
            return null;

        return direction switch
        {
            Direction.Up => node.Up,
            Direction.Down => node.Down,
            Direction.Left => node.Left,
            Direction.Right => node.Right,
            _ => null
        };
    }

    public bool HasInteractionAt(Position position)
    {
        return _nodes.TryGetValue(position, out var node) && node.MinigameType != MinigameType.None;
    }

    public MinigameType GetMinigameTypeAt(Position position)
    {
        return _nodes.TryGetValue(position, out var node) ? node.MinigameType : MinigameType.None;
    }

    public bool IsExitPosition(Position position) => position == _exitPosition;
    public bool IsEntrancePosition(Position position) => position == _entrancePosition;

    public char[][] GetVisualRepresentation() => _visualRepresentation;

    public int GetRequiredWordsCount()
    {
        return _nodes.Values.Count(n => n.MinigameType != MinigameType.None);
    }
}
