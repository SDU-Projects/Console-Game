namespace Maze.Models;

public readonly struct Position
{
    public int Row { get; }
    public int Column { get; }

    public Position(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public override bool Equals(object? obj)
    {
        return obj is Position position &&
               Row == position.Row &&
               Column == position.Column;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Row, Column);
    }

    public static bool operator ==(Position left, Position right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Position left, Position right)
    {
        return !(left == right);
    }

    public override string ToString() => $"({Row}, {Column})";
}
