namespace Shared.Models;

public struct MinigameResult
{
    public bool Success { get; }
    public string? WordCollected { get; }

    public MinigameResult(bool success, string? wordCollected = null)
    {
        Success = success;
        WordCollected = wordCollected;
    }

    public static MinigameResult Victory(string word) => new MinigameResult(true, word);
    public static MinigameResult Failure() => new MinigameResult(false);
}
