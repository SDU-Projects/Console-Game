using Maze.Enums;
using Maze.Models;
using Maze.Services;

namespace Maze.Static;

public static class MazeFactory
{
    public static Maze.Models.Maze CreateDefaultMaze()
    {
        var visual = new char[][]
        {
            ['+', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '+', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', ' ', ' ', 'F', ' ', '|'],
            ['|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'],
            ['|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '6', ' ', ' ', ' ', ' ', '|'],
            ['|', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '+', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '+'],
            ['|', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|', ' ', '2', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'],
            ['|', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '4', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'],
            ['|', ' ', ' ', ' ', ' ', ' ', '+', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '+', ' ', ' ', ' ', ' ', ' ', '+', '-', '-', '-', '-', '-', '+', ' ', ' ', ' ', ' ', ' ', '|'],
            ['|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', '1', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|'],
            ['|', ' ', '3', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', '5', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|'],
            ['+', '-', '-', '-', '-', '-', '-', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '+', '-', '-', '-', '-', '-', '+', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|'],
            ['|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'],
            ['|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'],
            ['|', ' ', ' ', ' ', ' ', ' ', '+', '-', '-', '-', '-', '-', '+', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '+', ' ', ' ', ' ', ' ', ' ', '|'],
            ['|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'],
            ['|', ' ', ' ', 'S', ' ', ' ', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '+'],
        };

        var positions = new Dictionary<string, Position>
        {
            ["p1"] = new(13, 3),
            ["p2"] = new(13, 33),
            ["p3"] = new(11, 3),
            ["p4"] = new(11, 9),
            ["p5"] = new(11, 15),
            ["p6"] = new(11, 27),
            ["p7"] = new(11, 33),
            ["p8"] = new(7, 3),
            ["p9"] = new(7, 9),
            ["p10"] = new(7, 15),
            ["p11"] = new(7, 21),
            ["p12"] = new(8, 27),
            ["p13"] = new(5, 9),
            ["p14"] = new(4, 15),
            ["p15"] = new(5, 27),
            ["p16"] = new(5, 33),
            ["p17"] = new(1, 3),
            ["p18"] = new(1, 9),
            ["p19"] = new(1, 15),
            ["p20"] = new(1, 21),
            ["p21"] = new(1, 34),
            ["GunGame"] = new(1, 28)
        };

        var builder = new MazeBuilder()
            .WithVisualRepresentation(visual)
            .WithStartPosition(positions["p1"])
            .WithEntrancePosition(positions["p1"])
            .WithExitPosition(positions["p21"]);

        foreach (var pos in positions.Values)
        {
            builder.AddNode(pos);
        }

        builder
            .ConnectNodes(positions["p1"], positions["p3"], Direction.Up)
            .ConnectNodes(positions["p1"], positions["p2"], Direction.Right)
            .ConnectNodes(positions["p2"], positions["p7"], Direction.Up)
            .ConnectNodes(positions["p3"], positions["p4"], Direction.Right)
            .ConnectNodes(positions["p4"], positions["p9"], Direction.Up)
            .ConnectNodes(positions["p5"], positions["p10"], Direction.Up)
            .ConnectNodes(positions["p5"], positions["p6"], Direction.Right)
            .ConnectNodes(positions["p6"], positions["p12"], Direction.Up)
            .ConnectNodes(positions["p6"], positions["p7"], Direction.Right)
            .ConnectNodes(positions["p7"], positions["p16"], Direction.Up)
            .ConnectNodes(positions["p8"], positions["p17"], Direction.Up)
            .ConnectNodes(positions["p8"], positions["p9"], Direction.Right)
            .ConnectNodes(positions["p9"], positions["p10"], Direction.Right)
            .ConnectNodes(positions["p10"], positions["p5"], Direction.Down)
            .ConnectNodes(positions["p11"], positions["p20"], Direction.Up)
            .ConnectNodes(positions["p13"], positions["p18"], Direction.Up)
            .ConnectNodes(positions["p13"], positions["p14"], Direction.Right)
            .ConnectNodes(positions["p14"], positions["p19"], Direction.Up)
            .ConnectNodes(positions["p15"], positions["p16"], Direction.Right)
            .ConnectNodes(positions["p16"], positions["p7"], Direction.Down)
            .ConnectNodes(positions["p17"], positions["p18"], Direction.Right)
            .ConnectNodes(positions["p18"], positions["p13"], Direction.Down)
            .ConnectNodes(positions["p19"], positions["p20"], Direction.Right)
            .ConnectNodes(positions["p20"], positions["p11"], Direction.Down)
            .ConnectNodes(positions["p20"], positions["GunGame"], Direction.Right)
            .ConnectNodes(positions["GunGame"], positions["p21"], Direction.Right);

        builder
            .AddMinigame(positions["p12"], MinigameType.Story)
            .AddMinigame(positions["p15"], MinigameType.MLModelGame)
            .AddMinigame(positions["p8"], MinigameType.QuizGame)
            .AddMinigame(positions["p14"], MinigameType.RouletteGame)
            .AddMinigame(positions["p11"], MinigameType.BoxGame)
            .AddMinigame(positions["GunGame"], MinigameType.GunGame);

        return builder.Build();
    }
}
