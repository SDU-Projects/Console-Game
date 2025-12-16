using Maze.Enums;
using Maze.Models;

namespace Maze.Services;
public class MazeBuilder
{
    private readonly Dictionary<Position, MazeNode> _nodes = new();
    private Position _startPosition;
    private Position _entrancePosition;
    private Position _exitPosition;
    private char[][] _visualRepresentation;

    public MazeBuilder()
    {
        _visualRepresentation = Array.Empty<char[]>();
    }

    public MazeBuilder WithVisualRepresentation(char[][] visual)
    {
        _visualRepresentation = visual;
        return this;
    }

    public MazeBuilder WithStartPosition(Position position)
    {
        _startPosition = position;
        return this;
    }

    public MazeBuilder WithEntrancePosition(Position position)
    {
        _entrancePosition = position;
        return this;
    }

    public MazeBuilder WithExitPosition(Position position)
    {
        _exitPosition = position;
        return this;
    }

    public MazeBuilder AddNode(Position position)
    {
        if (!_nodes.ContainsKey(position))
        {
            _nodes[position] = new MazeNode(position);
        }
        return this;
    }

    public MazeBuilder ConnectNodes(Position from, Position to, Direction direction)
    {
        if (!_nodes.ContainsKey(from))
            AddNode(from);
        
        if (!_nodes.ContainsKey(to))
            AddNode(to);

        var fromNode = _nodes[from];
        
        switch (direction)
        {
            case Direction.Up:
                fromNode.Up = to;
                _nodes[to].Down = from;
                break;
            case Direction.Down:
                fromNode.Down = to;
                _nodes[to].Up = from;
                break;
            case Direction.Left:
                fromNode.Left = to;
                _nodes[to].Right = from;
                break;
            case Direction.Right:
                fromNode.Right = to;
                _nodes[to].Left = from;
                break;
        }

        return this;
    }

    public MazeBuilder AddMinigame(Position position, MinigameType type)
    {
        if (!_nodes.ContainsKey(position))
            AddNode(position);

        _nodes[position].MinigameType = type;
        return this;
    }

    public Models.Maze Build()
    {
        if (_visualRepresentation.Length == 0)
            throw new InvalidOperationException("Visual representation must be set");

        return new Models.Maze(_nodes, _visualRepresentation, _startPosition, _entrancePosition, _exitPosition);
    }
}
