



var game = new RouleteGame();
await game.Play();


public class RouleteGame
{
    public List<string> Subjects = new List<string>() { "math", "science", "philosphy" };
    public SpinningWheel SpinningWheel { get; set; } = new SpinningWheel();
    public Randomizer Randomizer {  get; set; } = new Randomizer();
    public Question Question { get; set; } = new Question();

    public async Task<bool> Play()
    {
        Console.WriteLine("Welcome to the Roulette Game!");

        var subject = await SpinningWheel.Spin(Subjects);

        Question = Randomizer.GetRandomQuestionForASubject(subject);

        //PrintTheQuestion(Question);
        //var input = GetUsrInput();
        //if(CheckIfAnswerIsCorrect(input))
        //{
        //    Console.WriteLine("Correct Answer!");
        //}
        //else
        //{
        //    Console.WriteLine("Wrong Answer!");
        //}

        Console.WriteLine($"You have landed on: {subject}");

        return true;
    }
}











public class Question
{
    public string question { get; set; } 
    public List<string> options { get; set; }
    public string answer { get; set; }
}




public class SpinningWheel
{
    public async Task<string> Spin(List<string> subjects)
    {
        Console.WriteLine("Spinning the wheel...");
        for ( int i = 0; i < 10; i++)
        {
            Console.WriteLine($"========{subjects[0]}========");
            Console.WriteLine($"==============|===============");
            Console.WriteLine($"==============|===============");
            Console.WriteLine($"==============|===============");
            Console.WriteLine($"==============|===============");
            Console.WriteLine($"=============================");
            Console.WriteLine($"{subjects[1]}========{subjects[2]}");

            var tmp = subjects[0];
            subjects[0] = subjects[1];
            subjects[1] = subjects[2];
            subjects[2] = tmp;
            await Task.Delay(1000);
            Console.Clear();

        }

        return subjects[0];

    }
}

public class Randomizer
{
    public List<Question> listofquestion = new List<Question>() { };

    public Question GetRandomQuestionForASubject(string subject)
    {
        return new Question();
    }
}

