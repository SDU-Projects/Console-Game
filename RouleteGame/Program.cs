using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        var game = new RouletteGame();
        await game.Play();
    }
}

public class RouletteGame
{
    private readonly Random _rng = new();

    public List<string> Subjects = new List<string>() {"Politics","Science","Technology","Culture"};

    public List<Question> Questions = new List<Question>();
    public double Score = 0.0;

    public RouletteGame()
    {
        LoadQuestions();
    }

    public async Task Play()
    {
        Console.WriteLine("Welcome to the Roulette Game!");
        Console.WriteLine("Reach 8 points to win!");
        Console.WriteLine();

        while (Score < 8.0)
        {
            string subject = await SpinWheel();

            Console.WriteLine($"You landed on: {subject}");
            Console.WriteLine();

            var q = GetRandomQuestion(subject);
            AskQuestion(q);
        }

        Console.WriteLine("\n🎉 YOU WON THE GAME! 🎉");
    }
    public async Task<string> SpinWheel()
    {
        Console.WriteLine("Spinning the wheel...");

        for (int i = 0; i <15 ; i++)
        {
            Console.Write(Subjects[i % Subjects.Count]);
            await Task.Delay(80);
            Console.Write("\r      \r");
        }
        ///////I have to fix the spinning, it's broken on screen
        Console.WriteLine();
        return Subjects[_rng.Next(0, Subjects.Count)];
    }
    public Question GetRandomQuestion(string subject)
    {
        var list = Questions.FindAll(q => q.Subject == subject);
        if (list.Count == 0)
        {
           
            list = Questions;
        }

        if (list.Count == 0)
            throw new InvalidOperationException("No questions available. Check LoadQuestions().");

        int index = _rng.Next(0, list.Count);
        return list[index];
    }

    public void AskQuestion(Question q)
    {
        Console.WriteLine(q.Text);
        Console.WriteLine("A) " + q.A);
        Console.WriteLine("B) " + q.B);
        Console.WriteLine("C) " + q.C);
        Console.Write("\nYour answer: ");

        string? raw = Console.ReadLine();
        string input = string.IsNullOrWhiteSpace(raw) ? string.Empty : raw.Trim().ToUpperInvariant();

        if (input == q.FalseAnswer)
        {
            Console.WriteLine("Correct! (+0.5 points)");
            Score += 0.5;
        }
        else
        {
            Console.WriteLine("Wrong!");
        }

        Console.WriteLine($"Correct false statement was: {q.FalseAnswer}");
        Console.WriteLine($"Score: {Score:F1}\n");
    }
    public void LoadQuestions()
    {
        // POLITICS
        Questions.Add(new Question()
        {
            Subject = "Politics",
            Text = "Golda Meir",
            A = "She entered Israeli politics at a time when women were expected to stay on the sidelines.",
            B = "She replied 'let the men stay at home' when curfew for women was suggested.",
            C = "She stepped down early because she believed women were not suited for high-pressure decisions.",
            FalseAnswer = "C"
        });

        Questions.Add(new Question()
        {
            Subject = "Politics",
            Text = "Benazir Bhutto",
            A = "She endured years of house arrest and exile under a military dictatorship.",
            B = "She won a Nobel Peace Prize for her work on women's rights.",
            C = "She prioritized women’s rights, education, and social reform during her time in government.",
            FalseAnswer = "B"
        });

        Questions.Add(new Question()
        {
            Subject = "Politics",
            Text = "Jacinda Ardern",
            A = "She led the country while being a mother to a young child.",
            B = "She introduced gender equality reforms like pay equity and free menstrual products in schools.",
            C = "She resigned mainly to encourage younger women to enter politics.",
            FalseAnswer = "C"
        });

        // SCIENCE
        Questions.Add(new Question()
        {
            Subject = "Science",
            Text = "Marie Curie",
            A = "She was the first woman to win a Nobel Prize and the only person to win in two sciences.",
            B = "She founded the first women-only scientific laboratory in France.",
            C = "She became the first female professor at the University of Paris.",
            FalseAnswer = "B"
        });

        Questions.Add(new Question()
        {
            Subject = "Science",
            Text = "Chien-Shiung Wu",
            A = "She became the first woman to direct a nuclear weapons laboratory.",
            B = "She provided essential experimental proof for the theory that won Lee and Yang the Nobel Prize.",
            C = "She conducted the famous 'Wu Experiment' that disproved parity in weak interactions.",
            FalseAnswer = "A"
        });

        Questions.Add(new Question()
        {
            Subject = "Science",
            Text = "Henrietta Swan Leavitt",
            A = "She discovered the period–luminosity relationship for Cepheid stars.",
            B = "She was the first female professor at Harvard University.",
            C = "Her observations became foundational for modern astronomy.",
            FalseAnswer = "B"
        });

        // TECHNOLOGY
        Questions.Add(new Question()
        {
            Subject = "Technology",
            Text = "Katherine Johnson, Dorothy Vaughan, Mary Jackson",
            A = "Their calculations were essential for John Glenn’s orbital flight.",
            B = "Dorothy Vaughan became NASA’s first African American female computer programmer.",
            C = "Mary Jackson personally designed the Mercury and Apollo spacecraft.",
            FalseAnswer = "C"
        });

        Questions.Add(new Question()
        {
            Subject = "Technology",
            Text = "Hedy Lamarr",
            A = "She co-invented frequency-hopping technology that influenced modern wireless communication.",
            B = "She balanced a Hollywood career while being an inventor.",
            C = "She was the first woman to win a Nobel Prize for physics and technology.",
            FalseAnswer = "C"
        });

        Questions.Add(new Question()
        {
            Subject = "Technology",
            Text = "Ada Lovelace",
            A = "She became the first female professor of mathematics at Oxford University.",
            B = "She predicted that computers could create music and art.",
            C = "She wrote the first algorithm meant for a machine.",
            FalseAnswer = "A"
        });

        // CULTURE
        Questions.Add(new Question()
        {
            Subject = "Culture",
            Text = "Toni Morrison",
            A = "She was the first Black woman to win the Nobel Prize in Literature.",
            B = "She founded a publishing company that focused exclusively on women authors.",
            C = "Her novels often feature Black female protagonists.",
            FalseAnswer = "B"
        });

        Questions.Add(new Question()
        {
            Subject = "Culture",
            Text = "Frida Kahlo",
            A = "She painted self-portraits exploring identity, pain, and resilience.",
            B = "She co-founded the Mexican feminist movement and the first women's political party.",
            C = "She embraced Mexican culture using Tehuana dresses and indigenous symbolism.",
            FalseAnswer = "B"
        });

        Questions.Add(new Question()
        {
            Subject = "Culture",
            Text = "Elizabeth Taylor",
            A = "She helped found amfAR and was an early activist for HIV/AIDS awareness.",
            B = "She supported humanitarian causes worldwide, including hospitals and programs for children.",
            C = "She successfully led lobbying for the Equal Rights Amendment in the 1970s.",
            FalseAnswer = "C"
        });
    }


    public class Question
    {
        public string Subject;
        public string Text;

        public string A;
        public string B;
        public string C;

        public string FalseAnswer;
    }
}
