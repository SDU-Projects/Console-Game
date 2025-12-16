// Question class to represent each quiz question
// Player class to track player statistics
public class Player
{
    public int Score { get; private set; }
    public int CorrectAnswers { get; private set; }
    public int WrongAnswers { get; private set; }
    public List<string> AnswerHistory { get; private set; }

    public Player()
    {
        Score = 0;
        CorrectAnswers = 0;
        WrongAnswers = 0;
        AnswerHistory = new List<string>();
    }

    public void AddCorrectAnswer(int points)
    {
        Score += points;
        CorrectAnswers++;
        AnswerHistory.Add("✓");
    }

    public void AddWrongAnswer(int penalty)
    {
        Score -= penalty;
        WrongAnswers++;
        AnswerHistory.Add("✗");
    }

    public void Reset()
    {
        Score = 0;
        CorrectAnswers = 0;
        WrongAnswers = 0;
        AnswerHistory.Clear();
    }
}
