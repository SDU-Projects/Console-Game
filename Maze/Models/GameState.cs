namespace Maze.Models;

/// <summary>
/// Manages the game state including collected words and win conditions
/// </summary>
public class GameState
{
    private readonly HashSet<string> _collectedWords;
    private readonly int _requiredWordsCount;
    private readonly string _correctSentence;

    public IReadOnlyCollection<string> CollectedWords => _collectedWords;
    public bool IsGameOver { get; private set; }
    public bool IsVictory { get; private set; }

    public GameState(int requiredWordsCount, string correctSentence = "1 2 3 4 5")
    {
        _requiredWordsCount = requiredWordsCount;
        _correctSentence = correctSentence.ToLower();
        _collectedWords = new HashSet<string>();
        IsGameOver = false;
        IsVictory = false;
    }

    public void CollectWord(string word)
    {
        if (string.IsNullOrWhiteSpace(word))
            return;

        _collectedWords.Add(word.ToLower());
    }

    public bool HasCollectedAllWords()
    {
        return _collectedWords.Count >= _requiredWordsCount;
    }

    public bool ValidateSentence(string playerSentence)
    {
        if (string.IsNullOrWhiteSpace(playerSentence))
            return false;

        return playerSentence.Trim().ToLower() == _correctSentence;
    }

    public void CompleteGame()
    {
        IsGameOver = true;
        IsVictory = true;
    }

    public void EndGame()
    {
        IsGameOver = true;
        IsVictory = false;
    }
}
