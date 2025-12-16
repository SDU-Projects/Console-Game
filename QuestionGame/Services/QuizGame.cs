using Shared.Interfaces;
using Shared.Models;
using System.Numerics;

public class QuizGame : IMinigame
{
    private Player player;
    private List<Question> questions;
    private List<Question> availableQuestions;
    private const int CORRECT_POINTS = 3;
    private const int WRONG_PENALTY = 1;
    private const int WINNING_SCORE = 10;
    private string ReturnKeyWord;

    public QuizGame(string word)
    {
        ReturnKeyWord = word;
        player = new Player();
        InitializeQuestions();
        ResetAvailableQuestions();
    }

    private void InitializeQuestions()
    {
        questions = new List<Question>
            {
                new Question(
                    "Both men and women deserve equal __________ in education and career opportunities.",
                    new List<string> { "obstacles", "chances", "restrictions", "punishments" },
                    'B'
                ),
                new Question(
                    "Gender equality means giving everyone the same __________, regardless of gender",
                    new List<string> { "salary", "respect", "color", "height" },
                    'B'
                ),
                new Question(
                    "A society becomes stronger when it values the __________ of both men and women.",
                    new List<string> { "voices", "silence", "shoes", "hobbies" },
                    'B'
                ),

                new Question(
                    "Equal pay for equal __________ is a basic principle of fairness.",
                    new List<string> { "luck", "work", "fashion", "distance" },
                    'B'
                ),

                new Question(
                    "Discrimination based on gender is a violation of human __________.\r\n",
                    new List<string> { "dreams", "rights", "rules", "sports" },
                    'B'
                ),
                new Question(
                    "Empowering women empowers the whole __________.",
                    new List<string> { "family", "community", "kitchen", "classroom" },
                    'B'
                ),
                new Question(
                    "Boys and girls should both be encouraged to follow their __________",
                    new List<string> { "chores", "dreams", "diets", "fears" },
                    'B'
                ),
                new Question(
                    "True equality means sharing both the __________ and the benefits of life.",
                    new List<string> { "burdens", "chairs", "holidays", "colors" },
                    'A'
                ),
                new Question(
                    "v",
                    new List<string> { "denied", "given", "stolen", "hidden" },
                    'B'
                ),
                new Question(
                    "When workplaces support gender equality, everyone has the chance to __________.",
                    new List<string> { "fail", "grow", "vanish", "argue" },
                    'B'
                )
            };
    }

    private void ResetAvailableQuestions()
    {
        availableQuestions = new List<Question>(questions);
    }

    public MinigameResult Play()
    {
        player.Reset();
        ResetAvailableQuestions();
        DisplayWelcome();
        PlayRound();
        DisplayFinalResults();

        Console.WriteLine("\nThank you for playing! Goodbye!");
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
        if(player.Score >= WINNING_SCORE)
        {
            return MinigameResult.Victory(ReturnKeyWord);
        }
        else
        {
            return MinigameResult.Failure();
        }
    }

    private void DisplayWelcome()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔════════════════════════════════════════════╗");
        Console.WriteLine("║         WORD FILL QUIZ CHALLENGE           ║");
        Console.WriteLine("╚════════════════════════════════════════════╝");
        Console.ResetColor();

        Console.WriteLine("\nRules:");
        Console.WriteLine("• Fill in the missing word by choosing the correct option");
        Console.WriteLine($"• Correct answer: +{CORRECT_POINTS} points");
        Console.WriteLine($"• Wrong answer: -{WRONG_PENALTY} point");
        Console.WriteLine($"• Goal: Reach {WINNING_SCORE} points to win!");
        Console.WriteLine("\nPress any key to start...");
        Console.ReadKey();
    }

    private void PlayRound()
    {
        Random random = new Random();

        while (player.Score < WINNING_SCORE && availableQuestions.Count > 0)
        {
            Console.Clear();
            DisplayScore();

            if (player.Score + (availableQuestions.Count * CORRECT_POINTS) < WINNING_SCORE)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n⚠ Not enough questions left to reach the winning score!");
                Console.WriteLine("Game Over - You cannot win anymore.");
                Console.ResetColor();
                break;
            }

            int questionIndex = random.Next(availableQuestions.Count);
            Question currentQuestion = availableQuestions[questionIndex];
            availableQuestions.RemoveAt(questionIndex);

            currentQuestion.Display();

            char userAnswer = GetUserInput();
            ProcessAnswer(currentQuestion, userAnswer);

            if (player.Score >= WINNING_SCORE)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n🎉 CONGRATULATIONS! You've reached the winning score! 🎉");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        if (availableQuestions.Count == 0 && player.Score < WINNING_SCORE)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nNo more questions available!");
            Console.ResetColor();
        }
    }

    private void DisplayScore()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("═══════════════════════════════════════════");
        Console.Write($"Current Score: {player.Score} | ");
        Console.Write($"Target: {WINNING_SCORE} | ");
        Console.WriteLine($"Points Needed: {Math.Max(0, WINNING_SCORE - player.Score)}");

        if (player.AnswerHistory.Count > 0)
        {
            Console.Write("History: ");
            foreach (var result in player.AnswerHistory)
            {
                Console.Write(result + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("═══════════════════════════════════════════");
        Console.ResetColor();
    }

    private char GetUserInput()
    {
        char answer = ' ';
        bool validInput = false;

        do
        {
            Console.Write("Your answer (A/B/C/D): ");
            string input = Console.ReadLine()?.ToUpper();

            if (!string.IsNullOrEmpty(input) && input.Length == 1 &&
                input[0] >= 'A' && input[0] <= 'D')
            {
                answer = input[0];
                validInput = true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input! Please enter A, B, C, or D.");
                Console.ResetColor();
            }
        } while (!validInput);

        return answer;
    }

    private void ProcessAnswer(Question question, char userAnswer)
    {
        Console.WriteLine();

        if (question.CheckAnswer(userAnswer))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"✓ CORRECT! The answer is '{question.CorrectWord}'");
            Console.WriteLine($"You earned {CORRECT_POINTS} points!");
            Console.ResetColor();
            player.AddCorrectAnswer(CORRECT_POINTS);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"✗ WRONG! The correct answer was '{question.CorrectWord}'");
            Console.WriteLine($"You lost {WRONG_PENALTY} point!");
            Console.ResetColor();
            player.AddWrongAnswer(WRONG_PENALTY);
        }
    }

    private void DisplayFinalResults()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔════════════════════════════════════════════╗");
        Console.WriteLine("║              GAME RESULTS                 ║");
        Console.WriteLine("╚════════════════════════════════════════════╝");
        Console.ResetColor();

        Console.WriteLine($"\nFinal Score: {player.Score}");
        Console.WriteLine($"Correct Answers: {player.CorrectAnswers}");
        Console.WriteLine($"Wrong Answers: {player.WrongAnswers}");
        Console.WriteLine($"Total Questions Answered: {player.CorrectAnswers + player.WrongAnswers}");

        if (player.CorrectAnswers + player.WrongAnswers > 0)
        {
            double accuracy = (double)player.CorrectAnswers / (player.CorrectAnswers + player.WrongAnswers) * 100;
            Console.WriteLine($"Accuracy: {accuracy:F1}%");
        }

        if (player.Score >= WINNING_SCORE)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n🏆 YOU ARE A CHAMPION! 🏆");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nBetter luck next time!");
            Console.ResetColor();
        }
    }
}