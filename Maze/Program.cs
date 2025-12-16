using Maze.Models;
using Maze.Services;
using Maze.Static;

namespace MazeGame;
public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            var maze = MazeFactory.CreateDefaultMaze();
            var player = new Maze.Models.Player(maze.StartPosition);
            var minigameFactory = new MinigameFactory();

            var game = new Game(maze, player, minigameFactory);
            game.Start();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.ResetColor();
        }
        
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
