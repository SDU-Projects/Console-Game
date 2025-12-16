namespace ModelMiniGame.Models;

public class GameResult
{
    public int TotalRounds { get; set; }
    public int CorrectGuesses { get; set; }
    public List<GameRound> Rounds { get; set; } = new List<GameRound>();
    public double AccuracyPercentage => (double)CorrectGuesses / TotalRounds * 100;
}
