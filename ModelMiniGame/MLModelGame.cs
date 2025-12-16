using ModelMiniGame.DTOs;
using ModelMiniGame.Models;
using Shared.Interfaces;
using Shared.Models;
using System;

namespace ModelMiniGame;

public class MLModelGame : IMinigame
{
    private readonly Services.ApiService _apiService;
    private readonly GameResult _gameResult;
    private const int MaxRounds = 5;
    private const string apiUrl = "https://localhost:52869/";
    private string ReturnKeyWord;


    public MLModelGame(string word)
    {
        ReturnKeyWord = word;
        _apiService = new Services.ApiService(apiUrl);
        _gameResult = new GameResult { TotalRounds = MaxRounds };
    }

    public MinigameResult Play()
    {
        DisplayWelcome();

        for (int round = 1; round <= MaxRounds; round++)
        {
            PlayRoundAsync(round).Wait();

            if (round < MaxRounds)
            {
                Console.WriteLine("\nPress any key to continue to next round...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        DisplayFinalResults();

        if (_gameResult.CorrectGuesses >= 1)
            return MinigameResult.Victory(ReturnKeyWord);
        else
            return MinigameResult.Failure(); 
    }

    private void DisplayWelcome()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔════════════════════════════════════════════════════════╗");
        Console.WriteLine("║     GENDER EQUALITY ASSESSMENT GUESSING GAME           ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════╝");
        Console.ResetColor();

        Console.WriteLine("\n📋 GAME RULES:");
        Console.WriteLine("   • You'll evaluate 5 gender equality statements");
        Console.WriteLine("   • Rate each statement from 1-5:");
        Console.WriteLine("     1 = Severe inequality (very bad)");
        Console.WriteLine("     2 = Significant concerns");
        Console.WriteLine("     3 = Moderate/mixed situation");
        Console.WriteLine("     4 = Generally positive");
        Console.WriteLine("     5 = Excellent equality");
        Console.WriteLine("\n   • Try to match the AI model's prediction!");
        Console.WriteLine("   • Score points for exact matches\n");

        Console.WriteLine("Press any key to start...");
        Console.ReadKey();
        Console.Clear();
    }

    private async Task PlayRoundAsync(int roundNumber)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine($"║                    ROUND {roundNumber}/{MaxRounds}                       ║");
        Console.WriteLine($"╚═══════════════════════════════════════════════════════╝");
        Console.ResetColor();

        Console.WriteLine("\n📝 Enter a gender equality statement:");
        Console.ForegroundColor = ConsoleColor.White;
        string statement = Console.ReadLine()?.Trim();
        Console.ResetColor();

        if (string.IsNullOrWhiteSpace(statement))
        {
            statement = GetDefaultStatement(roundNumber);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"Using example: {statement}");
            Console.ResetColor();
        }

        int userGuess = GetUserGuess();

        Console.WriteLine("\n🤖 AI is analyzing the statement...");

        try
        {
            var prediction = await _apiService.PredictAsync(statement);
            int modelPrediction = (int)Math.Round(prediction.PredictedLabel);

            modelPrediction = Math.Clamp(modelPrediction, 1, 5);

            DisplayRoundResult(roundNumber, statement, userGuess, modelPrediction, prediction);

            bool isCorrect = userGuess == modelPrediction;
            var round = new GameRound
            {
                RoundNumber = roundNumber,
                Statement = statement,
                UserGuess = userGuess,
                ModelPrediction = modelPrediction,
                IsCorrect = isCorrect,
                Difference = Math.Abs(userGuess - modelPrediction)
            };

            _gameResult.Rounds.Add(round);
            if (isCorrect) _gameResult.CorrectGuesses++;
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n❌ Error getting prediction: {ex.Message}");
            Console.WriteLine("This round will be skipped.");
            Console.ResetColor();
        }
    }

    private int GetUserGuess()
    {
        while (true)
        {
            Console.WriteLine("\n🎯 Your assessment (1-5):");
            Console.Write("   Your guess: ");

            if (int.TryParse(Console.ReadLine(), out int guess) && guess >= 1 && guess <= 5)
            {
                return guess;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   ⚠️  Invalid input! Please enter a number between 1 and 5.");
            Console.ResetColor();
        }
    }

    private void DisplayRoundResult(int roundNumber, string statement, int userGuess,
                                   int modelPrediction, ModelOutputDTO fullPrediction)
    {
        Console.WriteLine("\n" + new string('─', 60));
        Console.WriteLine("📊 RESULTS:");
        Console.WriteLine(new string('─', 60));

        Console.WriteLine($"\n   Statement: \"{statement}\"");
        Console.WriteLine($"\n   Your guess:      {userGuess} {GetEmojiForScore(userGuess)}");
        Console.WriteLine($"   AI prediction:   {modelPrediction} {GetEmojiForScore(modelPrediction)}");

        if (fullPrediction.Score != null && fullPrediction.Score.Length > 0)
        {
            Console.WriteLine($"\n   AI Confidence: {GetConfidenceBar(fullPrediction.Score)}");
        }

        bool isCorrect = userGuess == modelPrediction;
        int difference = Math.Abs(userGuess - modelPrediction);

        Console.WriteLine();
        if (isCorrect)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("   ✅ PERFECT MATCH! You guessed correctly! +1 point");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"   ❌ Not quite! Off by {difference} point{(difference > 1 ? "s" : "")}");
        }
        Console.ResetColor();

        Console.WriteLine(new string('─', 60));

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\n   Current Score: {_gameResult.CorrectGuesses}/{roundNumber}");
        Console.ResetColor();
    }

    private string GetEmojiForScore(int score)
    {
        return score switch
        {
            1 => "😰 (Severe)",
            2 => "😟 (Significant)",
            3 => "😐 (Moderate)",
            4 => "🙂 (Positive)",
            5 => "😊 (Excellent)",
            _ => ""
        };
    }

    private string GetConfidenceBar(float[] scores)
    {
        if (scores == null || scores.Length == 0) return "";

        var maxScore = scores.Max();
        var maxIndex = Array.IndexOf(scores, maxScore);
        var percentage = (maxScore * 100).ToString("F1");

        return $"{percentage}% confident in class {maxIndex + 1}";
    }

    private void DisplayFinalResults()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n╔════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                   GAME OVER!                           ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════╝");
        Console.ResetColor();

        Console.WriteLine($"\n🎯 FINAL SCORE: {_gameResult.CorrectGuesses}/{_gameResult.TotalRounds}");
        Console.WriteLine($"📈 Accuracy: {_gameResult.AccuracyPercentage:F1}%\n");

        // Performance rating
        string rating = _gameResult.CorrectGuesses switch
        {
            5 => "🏆 PERFECT! You think exactly like the AI!",
            4 => "⭐ EXCELLENT! You're very aligned with the AI!",
            3 => "👍 GOOD! You understand the patterns!",
            2 => "📚 LEARNING! Keep practicing!",
            _ => "🎓 BEGINNER! Try to understand AI's perspective!"
        };

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"   {rating}\n");
        Console.ResetColor();

        Console.WriteLine("📋 ROUND BREAKDOWN:");
        Console.WriteLine(new string('═', 60));

        foreach (var round in _gameResult.Rounds)
        {
            var statusIcon = round.IsCorrect ? "✅" : "❌";
            var color = round.IsCorrect ? ConsoleColor.Green : ConsoleColor.Red;

            Console.Write($"   Round {round.RoundNumber}: ");
            Console.ForegroundColor = color;
            Console.Write($"{statusIcon} ");
            Console.ResetColor();
            Console.WriteLine($"You: {round.UserGuess} | AI: {round.ModelPrediction}");

            if (!round.IsCorrect)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"           (Off by {round.Difference})");
                Console.ResetColor();
            }
        }

        Console.WriteLine(new string('═', 60));

        if (_gameResult.Rounds.Any())
        {
            var avgDifference = _gameResult.Rounds.Average(r => r.Difference);
            Console.WriteLine($"\n📊 Average difference: {avgDifference:F2} points");
        }

        Console.WriteLine("\n\nThank you for playing! 🎮");
    }

    private string GetDefaultStatement(int roundNumber)
    {
        var examples = new[]
        {
            "Women in our company receive equal pay for equal work",
            "Leadership positions are distributed fairly between genders",
            "Parental leave policies support all parents equally",
            "Women face barriers to promotion in our organization",
            "Our hiring process eliminates gender bias effectively"
        };

        return examples[Math.Min(roundNumber - 1, examples.Length - 1)];
    }
}
