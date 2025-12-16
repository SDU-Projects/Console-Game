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
    private readonly int _maxSubjectLength;
    private const int TargetScore = 5;

    public List<string> Subjects = new List<string>() {"Politics","Science","Technology","Culture"};

    public List<Question> Questions = new List<Question>();
    public int Score = 0;

    public RouletteGame()
    {
        int max = 0;
        foreach (var s in Subjects)
            if (s?.Length > max) max = s.Length;
        _maxSubjectLength = max;

        LoadQuestions();
    }

    public async Task Play()
    {
        while (true) 
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Roulette Game!");
            Console.WriteLine($"Reach {TargetScore} points to win!");
            Console.WriteLine();

            while (Score < TargetScore && Questions.Count > 0)
            {
                string subject = await SpinWheel();

                Console.Clear();
                Console.WriteLine($"You landed on: {subject}");
                Console.WriteLine();

                var q = GetRandomQuestion(subject);
                AskQuestion(q);
            }

            if (Score >= TargetScore)
            {
                Console.WriteLine($"\n YOU WON THE GAME! Your word is WORD_ROULETTE ");
                break;
            }
            Console.WriteLine($"\nNo more questions available. Final score: {Score}");
            Console.WriteLine("You did not reach the required score. The game will restart.");
            Console.WriteLine("Press any key to restart the game, or press Q then Enter to quit...");

            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Q)
            {
                Console.WriteLine("Quitting. Goodbye.");
                return;
            }
            Score = 0;
            LoadQuestions();
        }
    }

    public async Task<string> SpinWheel()
    {
        Console.WriteLine("Spinning the wheel...");

        for (int i = 0; i < 20; i++)
        {
            var text = Subjects[i % Subjects.Count] ?? string.Empty;
            Console.Write(text.PadRight(_maxSubjectLength));
            await Task.Delay(80);
            Console.Write("\r" + new string(' ', _maxSubjectLength) + "\r");
        }

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
        var chosen = list[index];
        Questions.Remove(chosen);

        return chosen;
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
            Console.WriteLine("Correct! (+1 point)");
            Score += 1;
        }
        else
        {
            Console.WriteLine("Wrong!");
        }
        string falseText = q.FalseAnswer switch
        {
            "A" => q.A,
            "B" => q.B,
            "C" => q.C,
            _ => "(unknown)"
        };

        Console.WriteLine($"Correct false statement was: {q.FalseAnswer}) {falseText}");

        if (!string.IsNullOrWhiteSpace(q.FalseExplanation))
        {
            Console.WriteLine($"Why that statement is false: {q.FalseExplanation}");
        }

        Console.WriteLine($"Score: {Score}\n");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
    }

    public void LoadQuestions()
    {
        Questions.Clear();

        // POLITICS
        Questions.Add(new Question()
        {
            Subject = "Politics",
            Text = "Golda Meir - She became one of the world’s first female prime ministers — at a time when politics was dominated by men.",
            A = "She entered Israeli politics at a time when women were expected to “support from the sidelines,” yet she became the only woman at the cabinet table for years.",
            B = "During a discussion about assaults on women, a minister suggested a curfew for women. Golda responded with “If there's to be a curfew, let the men stay at home, not the women.” during a discussion about assaults on women, a minister suggested a curfew for women;  ( A curfew is a rule that requires people to stay indoors between specific times, typically at night)",
            C = "She stepped down from politics early in her career because she believed women were not suited for high-pressure decision making.",
            FalseAnswer = "C",
            FalseExplanation = "This is false (and inaccurate historically): Golda Meir did resign as Prime Minister in 1974, but not because she believed women were unsuited for high-pressure decision making.  "
        });

        Questions.Add(new Question()
        {
            Subject = "Politics",
            Text = "Benazir Bhutto - She became the first woman to lead a modern Muslim-majority country.",
            A = "She endured years of house arrest and exile under a military dictatorship, then returned to run for office — showing courage and resilience against authoritarian power.",
            B = "She won a Nobel Peace Prize for her work in promoting women’s rights in Pakistan.",
            C = "During her time in government, she prioritized women’s rights, education, and social reform … advocating for more political participation and legal protections for women.",
            FalseAnswer = "B",
            FalseExplanation = "Benazir Bhutto did not receive a Nobel Peace Prize; she was a prominent leader but was not awarded the Nobel."
        });

        Questions.Add(new Question()
        {
            Subject = "Politics",
            Text = "Jacinda Ardern - Redefining leadership as compassionate, inclusive, and female-led in a traditionally male-dominated world.",
            A = "She became one of the world’s few elected leaders to lead while being a mother of a young child, proving that motherhood and top-level political leadership can coexist.",
            B = "She implemented progressive policies to reduce gender inequality, such as pay equity reforms and free menstrual products in schools, directly improving opportunities for young girls.",
            C = "She became the first female world leader to resign explicitly to encourage younger women to pursue political leadership instead of staying too long in office herself.",
            FalseAnswer = "C",
            FalseExplanation = "Jacinda Ardern cited burnout and a desire to allow fresh leadership; she did not resign specifically to encourage younger women to enter politics."
        });

        // SCIENCE
        Questions.Add(new Question()
        {
            Subject = "Science",
            Text = "Marie Curie - She was a pioneer in science, breaking gender and societal barriers in physics and chemistry.",
            A = "She was the first woman to win a Nobel Prize, and the only person ever to win Nobel Prizes in two different sciences (Physics and Chemistry), showing that women can excel at the highest levels in STEM.",
            B = "She established the first laboratory in France exclusively for women scientists, creating opportunities for female researchers at a time when universities were largely male-only.",
            C = "She became the first female professor at the University of Paris, paving the way for women in academic leadership.",
            FalseAnswer = "B",
            FalseExplanation = "Marie Curie did not found a women-only laboratory; she established research labs and worked within existing institutions."
        });

        Questions.Add(new Question()
        {
            Subject = "Science",
            Text = "Chien-Shiung Wu - She reshaped physics and broke major gender and racial barriers in science.",
            A = "She became the first woman in the world to lead a major nuclear weapons laboratory as its director, overseeing development of nuclear technology during the Cold War.",
            B = "Despite her scientific fame, she was repeatedly denied recognition at the highest level — Lee and Yang won the Nobel Prize for the theory she proved experimentally, but she was not awarded the Nobel, which many consider a glaring example of gender bias in science.",
            C = "She conducted the famous ‘Wu Experiment’ that disproved the law of parity in weak nuclear interactions, providing essential experimental proof — a breakthrough that fundamentally changed physics.",
            FalseAnswer = "A",
            FalseExplanation = "Chien-Shiung Wu did not serve as director of a nuclear weapons laboratory; her key contribution was experimental physics, not lab directorship."
        });

        Questions.Add(new Question()
        {
            Subject = "Science",
            Text = "Henrietta Swan Leavitt - She made groundbreaking contributions to astronomy, enabling measurement of cosmic distances and paving the way for modern astrophysics.",
            A = "She discovered the period-luminosity relationship for Cepheid variable stars, a breakthrough that allowed astronomers to measure the size of the universe.",
            B = "She was the first female professor at Harvard University, breaking gender barriers in academic leadership.",
            C = "Despite being employed in a male-dominated field and often underpaid, she conducted meticulous observations that became foundational for modern astronomy, demonstrating that women could contribute at the highest levels of science.",
            FalseAnswer = "B",
            FalseExplanation = "Henrietta Leavitt was not a professor at Harvard; she worked as a staff observer and did not hold a professorship there."
        });

        // TECHNOLOGY
        Questions.Add(new Question()
        {
            Subject = "Technology",
            Text = "Katherine Johnson, Dorothy Vaughan, Mary Jackson - They became pioneers in mathematics and engineering, proving that women — including women of color — could lead the most critical space missions.",
            A = "Their calculations were essential for John Glenn’s orbital flight, and he personally requested that Katherine Johnson verify the numbers by hand before launching.",
            B = "Dorothy Vaughan became NASA’s first African American female computer programmer and supervised a group of women known as “human computers,” paving the way for women in software engineering.",
            C = "Mary Jackson personally designed the Mercury and Apollo spacecraft, building the vehicles alongside engineers.",
            FalseAnswer = "C",
            FalseExplanation = "Mary Jackson was an engineer and contributed to NASA's work, but she did not personally design the spacecraft; design was a large team effort."
        });

        Questions.Add(new Question()
        {
            Subject = "Technology",
            Text = "Hedy Lamarr - She was not just a Hollywood actress — she co-invented a technology that became the foundation for modern wireless communication, proving that women can excel in STEM even when underestimated.",
            A = "She co-invented a frequency-hopping technology that laid the groundwork for modern wireless communication, showing women could innovate at the highest technical level.",
            B = "She became a role model for women in STEM by successfully balancing a career as a leading Hollywood actress and as an inventor, breaking gender stereotypes in both fields.",
            C = "She was the first woman in history to receive a Nobel Prize for contributions in physics and technology.",
            FalseAnswer = "C",
            FalseExplanation = "Hedy Lamarr did not receive a Nobel Prize; her work was influential but was not recognized by the Nobel committees."
        });

        Questions.Add(new Question()
        {
            Subject = "Technology",
            Text = "Ada Lovelace - She is considered the first computer programmer, proving that women could lead in mathematics and technology long before societal norms allowed it.",
            A = "She became the first female professor of mathematics at Oxford University, breaking academic barriers for women.",
            B = "She predicted that computers could go beyond calculations to create music and art, showing visionary thinking about technology’s possibilities.",
            C = "She wrote the first algorithm intended to be processed by a machine, making her the world’s first computer programmer.",
            FalseAnswer = "A",
            FalseExplanation = "Ada Lovelace was not a professor at Oxford; she was a mathematician who published the first algorithm for a mechanical computer."
        });

        // CULTURE
        Questions.Add(new Question()
        {
            Subject = "Culture",
            Text = "Toni Morrison - She used her writing to amplify Black women’s voices, challenging systemic oppression and inspiring generations of women and writers worldwide.",
            A = "She became the first Black woman to win the Nobel Prize in Literature, highlighting her role in breaking racial and gender barriers in the literary world.",
            B = "She founded her own publishing company, which focused exclusively on women authors, creating unprecedented opportunities for female writers.",
            C = "Her novels often center Black female protagonists, exploring their experiences, struggles, and resilience, empowering women through representation and storytelling.",
            FalseAnswer = "B",
            FalseExplanation = "Toni Morrison co-founded a publishing house (Holt/BE) focused on Black writers earlier in her career but did not found a company that focused exclusively on women authors."
        });

        Questions.Add(new Question()
        {
            Subject = "Culture",
            Text = "Frida Kahlo - She used her art to challenge social norms, explore female identity, and empower women through self-expression and cultural pride.",
            A = "She painted striking self-portraits that explored female identity, physical pain, and resilience, inspiring generations of women to embrace their individuality.",
            B = "She co-founded the Mexican feminist movement, formally establishing the first women’s political party in Mexico.",
            C = "She embraced Mexican culture in her art and fashion, using traditional Tehuana dresses and indigenous symbolism to assert cultural identity and empower women.",
            FalseAnswer = "B",
            FalseExplanation = "Frida Kahlo was politically active and influential, but she did not co-found the Mexican feminist movement or establish the first women's political party."
        });

        Questions.Add(new Question()
        {
            Subject = "Culture",
            Text = "Elizabeth Taylor - She used her fame not just for Hollywood, but to champion causes like HIV/AIDS awareness, showing that women can leverage their influence for social change.",
            A = "She was one of the first celebrities to raise awareness about HIV/AIDS and co-founded the American Foundation for AIDS Research (amfAR), using her influence to fight stigma and save lives.",
            B = "She leveraged her wealth and fame to support humanitarian causes worldwide, including helping fund hospitals and programs for underprivileged children.",
            C = "She was a major advocate for women’s political rights, successfully lobbying for the Equal Rights Amendment to be ratified in the 1970s.   ",
            FalseAnswer = "C",
            FalseExplanation = "Elizabeth Taylor was an activist on many causes but did not successfully lead the lobbying that resulted in ratification of the Equal Rights Amendment; the ERA was not ratified in the 1970s."
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

        public string FalseExplanation = "";
    }
}
