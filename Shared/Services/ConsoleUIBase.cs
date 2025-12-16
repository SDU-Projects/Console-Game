namespace Shared.Services;

public class ConsoleUIBase
{
    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void ShowColoredMessage(string message, ConsoleColor color)
    {
        var previousColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ForegroundColor = previousColor;
    }

    public string? GetInput()
    {
        return Console.ReadLine();
    }
}
