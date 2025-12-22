using Maze.Enums;
using Maze.Models;
using Shared.Services;

namespace Maze.Services;

public class ConsoleUI : ConsoleUIBase
{
    private const char PlayerSymbol = 'O';
    private const char EmptySpace = ' ';

    public void ShowMazeWelcomeMessage()
    {
        ShowColoredMessage("╔════════════════════════════════════════╗", ConsoleColor.Cyan);
        ShowColoredMessage("║   Welcome to the Maze of Equality!     ║", ConsoleColor.Cyan);
        ShowColoredMessage("╚════════════════════════════════════════╝", ConsoleColor.Cyan);
        ShowMessage("\nIn this game, you will explore mini-challenges that teach you about remarkable women and their achievements.");
        ShowMessage("\n Each completed mini-game will give you a word. Your goal is to write down every word you receive and use them to form a final sentence at the end");
        ShowMessage("\nGood luck, and enjoy learning while having fun!");
        ShowMessage("Press any key to start...");
        Console.ReadKey(true);
    }

    public void ShowVictoryMessage()
    {
        Console.Clear();
        ShowColoredMessage("\n╔════════════════════════════════════════╗", ConsoleColor.Green);
        ShowColoredMessage("║      CONGRATULATIONS!                  ║", ConsoleColor.Green);
        ShowColoredMessage("║  You've completed the Maze of Equality!║", ConsoleColor.Green);
        ShowColoredMessage("╚════════════════════════════════════════╝", ConsoleColor.Green);
        ShowMessage("\nWe hope you enjoyed playing. :)");
    }

    public void ShowWallCollision()
    {
        ShowColoredMessage("You ran full force into a wall. Ouch.", ConsoleColor.Red);
        Thread.Sleep(500); // Brief pause for effect
    }

    public void ShowWordCollected(string word, IReadOnlyCollection<string> allWords)
    {
        ShowColoredMessage($"\n✓ New word '{word}' has been added to your collection!", ConsoleColor.Green);
        ShowMessage($"Words collected: {string.Join(", ", allWords)}");
        ShowMessage("\nPress any key to continue...");
        Console.ReadKey(true);
    }

    public void DrawMaze(Maze.Models.Maze maze, Position playerPosition)
    {
        Console.Clear();
        
        var visual = maze.GetVisualRepresentation();
        var displayGrid = CloneGrid(visual);
        
        // Place player on the grid
        displayGrid[playerPosition.Row][playerPosition.Column] = PlayerSymbol;

        // Draw the maze
        foreach (var row in displayGrid)
        {
            Console.WriteLine(new string(row));
        }
        
        Console.WriteLine();
    }

    public Direction GetMovementDirection()
    {
        ShowMessage("Which way do you want to go? (up/down/left/right)");
        var input = GetInput()?.ToLower();

        return input switch
        {
            "up" or "w" => Direction.Up,
            "down" or "s" => Direction.Down,
            "left" or "a" => Direction.Left,
            "right" or "d" => Direction.Right,
            _ => Direction.Invalid
        };
    }

    public bool AskToPlayMinigame()
    {
        ShowColoredMessage("\n🎮 A minigame is available here!", ConsoleColor.Yellow);
        ShowMessage("Would you like to play? (Y/N)");
        
        var input = GetInput()?.ToLower();
        return input == "y" || input == "yes";
    }

    public string AskForSentence(IReadOnlyCollection<string> collectedWords)
    {
        ShowColoredMessage("\n🚪 You've reached the exit!", ConsoleColor.Cyan);
        ShowMessage("\nTo complete the maze, arrange all collected words in the correct order to make a sentence.");
        ShowMessage($"Available words: {string.Join(", ", collectedWords)}");
        ShowMessage("\nEnter your sentence:");
        
        return GetInput() ?? string.Empty;
    }

    private static char[][] CloneGrid(char[][] original)
    {
        var clone = new char[original.Length][];
        for (int i = 0; i < original.Length; i++)
        {
            clone[i] = new char[original[i].Length];
            Array.Copy(original[i], clone[i], original[i].Length);
        }
        return clone;
    }
}

