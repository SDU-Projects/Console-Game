// Question class to represent each quiz question
public class Question
{
    public string QuestionText { get; set; }
    public List<string> Options { get; set; }
    public char CorrectAnswer { get; set; }
    public string CorrectWord { get; set; }

    public Question(string questionText, List<string> options, char correctAnswer)
    {
        QuestionText = questionText;
        Options = options;
        CorrectAnswer = char.ToUpper(correctAnswer);
        CorrectWord = options[correctAnswer - 'A'];
    }

    public void Display()
    {
        Console.WriteLine("\n" + QuestionText);
        Console.WriteLine();
        for (int i = 0; i < Options.Count; i++)
        {
            Console.WriteLine($"  {(char)('A' + i)}) {Options[i]}");
        }
        Console.WriteLine();
    }

    public bool CheckAnswer(char userAnswer)
    {
        return char.ToUpper(userAnswer) == CorrectAnswer;
    }
}
