namespace ModelMiniGame.DTOs;

public class ModelOutputDTO
{
    public string Statement { get; set; }
    public uint Assessment { get; set; }
    public float PredictedLabel { get; set; }
    public float[] Score { get; set; }
}
