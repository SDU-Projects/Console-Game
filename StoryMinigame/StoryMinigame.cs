using Shared.Interfaces;
using Shared.Models;
using Shared.Services;

namespace MazeGame;

public class StoryMinigame : IMinigame
{
    private readonly List<Story> _stories;
    private readonly Random _random;
    private readonly ConsoleUIBase _ui;

    public StoryMinigame()
    {
        _random = new Random();
        _ui = new();
        _stories = new List<Story>
        {
            CreateFootballBanStory()
        };
    }

    public MinigameResult Play()
    {
        _ui.ShowColoredMessage("Welcome to Mini Stories!", ConsoleColor.Cyan);
        
        var story = _stories[_random.Next(_stories.Count)];
        int correctAnswers = 0;

        _ui.ShowColoredMessage($"\n{story.Title}", ConsoleColor.Blue);
        _ui.ShowMessage("");

        foreach (var question in story.Questions)
        {
            _ui.ShowMessage(question.Text);
            
            for (int i = 0; i < question.Options.Count; i++)
            {
                _ui.ShowMessage($"\t{(char)('a' + i)})  {question.Options[i]}");
            }

            var answer = _ui.GetInput()?.ToLower();
            bool isCorrect = answer == question.CorrectAnswer;
            
            if (isCorrect)
            {
                correctAnswers++;
            }

            _ui.ShowMessage($"That's {(isCorrect ? "correct" : "wrong")}! {question.Explanation}\n");
        }

        const int passingScore = 4;
        bool victory = correctAnswers >= passingScore;

        if (victory)
        {
            _ui.ShowColoredMessage($"Congratulations! You scored {correctAnswers}/{story.Questions.Count}!", ConsoleColor.Green);
            return MinigameResult.Victory("mini1");
        }
        else
        {
            _ui.ShowColoredMessage($"You scored {correctAnswers}/{story.Questions.Count}. You need at least {passingScore} to pass. Try again!", ConsoleColor.Red);
            return MinigameResult.Failure();
        }
    }

    private static Story CreateFootballBanStory()
    {
        return new Story
        {
            Title = "The Ban on Women's Football (England, 1921)",
            Questions = new List<Question>
            {
                new Question
                {
                    Text = "It is well known that football (soccer) is the most popular sport in the world. Specifically, that applies to male football league.",
                    Options = new List<string>
                    {
                        "That has always been the case",
                        "Female league used to be more popular",
                        "They used to be equally popular"
                    },
                    CorrectAnswer = "b",
                    Explanation = "In the early 20th century, women's football in the UK drew huge crowds — sometimes tens of thousands of fans, especially after World War I when women's teams raised money for charities. So what changed?"
                },
                new Question
                {
                    Text = "",
                    Options = new List<string>
                    {
                        "Women lost interest",
                        "Men played better",
                        "Women got banned from playing"
                    },
                    CorrectAnswer = "c",
                    Explanation = "In 1921, the Football Association (FA) declared that \"the game of football is quite unsuitable for females,\" and banned women from playing on official FA pitches. What did the women do?"
                },
                new Question
                {
                    Text = "",
                    Options = new List<string>
                    {
                        "Never played again",
                        "Played on small, unofficial fields",
                        "Played on the fields anyway"
                    },
                    CorrectAnswer = "b",
                    Explanation = "Women continued to play, but due to them being banned from the official pitches they were unable to accommodate the crowds of anywhere near similar size as the male league could. When was the ban lifted?"
                },
                new Question
                {
                    Text = "",
                    Options = new List<string>
                    {
                        "1971",
                        "2000",
                        "1937"
                    },
                    CorrectAnswer = "a",
                    Explanation = "The ban lasted 50 years, stalling the growth of women's football for generations. By the time it was lifted in 1971, men's leagues had decades of institutional investment and media exposure. Why is that still relevant?"
                },
                new Question
                {
                    Text = "",
                    Options = new List<string>
                    {
                        "Women didn't learn to play",
                        "It isn't, the leagues are equal",
                        "The gap still affects funding, visibility, and pay equity today"
                    },
                    CorrectAnswer = "c",
                    Explanation = "The historical ban created systemic inequalities that persist in modern women's football."
                }
            }
        };
    }
}
