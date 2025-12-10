namespace ModelMiniGame.Models;

public class GameRound
{
    public int RoundNumber { get; set; }
    public string Statement { get; set; }
    public int UserGuess { get; set; }
    public int ModelPrediction { get; set; }
    public bool IsCorrect { get; set; }
    public int Difference { get; set; }
}
