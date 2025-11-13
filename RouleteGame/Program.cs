



var game = new RouleteGame();
await game.Play();


public class RouleteGame
{
    public List<string> Dots = new List<string>() { ".", "..", "T..."};
    public List<string> Subjects = new List<string>() { "Politics", "Science", "Technology", "Culture" };
    public SpinningWheel SpinningWheel { get; set; } = new SpinningWheel();
    public Randomizer Randomizer {  get; set; } = new Randomizer();
    public Question Question { get; set; } = new Question();

    public async Task<bool> Play()
    {
        Console.WriteLine("Welcome to the Roulette Game!");

        var subject = await SpinningWheel.Spin(Subjects, Dots);

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
    public async Task<string> Spin(List<string> subjects, List<string> dots)
    {
        
        for ( int i = 0; i < 50; i++)
        {
            Console.WriteLine("Spinning the roulette");

            foreach(var dot in dots)
            {
                Console.Write(dot);
                await Task.Delay(30);
                Console.Write("\b\b\b\b    \b\b\b\b");
            }


            var tmp = subjects[0];
            subjects[0] = subjects[1];
            subjects[1] = subjects[2];
            subjects[2] = subjects[3];
            subjects[3] = tmp;
            await Task.Delay(90);
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

