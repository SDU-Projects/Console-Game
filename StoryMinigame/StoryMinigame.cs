using Shared.Interfaces;
using Shared.Models;
using Shared.Services;

namespace MazeGame;

public class StoryMinigame : IMinigame
{
    private readonly List<Story> _stories;
    private readonly Random _random;
    private readonly ConsoleUIBase _ui;
    private string ReturnKeyWord;

    public StoryMinigame(string word)
    {
        ReturnKeyWord = word;
        _random = new Random();
        _ui = new();
        _stories = new List<Story>
        {
            CreateFootballBanStory(),
            CreateErasureOfWomenStory()
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
            return MinigameResult.Victory(ReturnKeyWord);
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
                        "That has always been the case.",
                        "Female league used to be more popular.",
                        "They used to be equally popular."
                    },
                    CorrectAnswer = "b",
                    Explanation = "In the early 20th century, women's football in the UK drew huge crowds — sometimes tens of thousands of fans, especially after World War I when women's teams raised money for charities."
                },
                new Question
                {
                    Text = "So what changed?",
                    Options = new List<string>
                    {
                        "Women lost interest.",
                        "Men played better.",
                        "Women got banned from playing."
                    },
                    CorrectAnswer = "c",
                    Explanation = "In 1921, the Football Association (FA) declared that \"the game of football is quite unsuitable for females,\" and banned women from playing on official FA pitches."
                },
                new Question
                {
                    Text = "What did the women do?",
                    Options = new List<string>
                    {
                        "They never played again.",
                        "They played on small, unofficial fields.",
                        "They played on the fields anyway."
                    },
                    CorrectAnswer = "b",
                    Explanation = "Women continued to play, but due to them being banned from the official pitches they were unable to accommodate the crowds of anywhere near similar size as the male league could."
                },
                new Question
                {
                    Text = "When was the ban lifted?",
                    Options = new List<string>
                    {
                        "1971",
                        "2000",
                        "1937"
                    },
                    CorrectAnswer = "a",
                    Explanation = "The ban lasted 50 years, stalling the growth of women's football for generations. By the time it was lifted in 1971, men's leagues had decades of institutional investment and media exposure."
                },
                new Question
                {
                    Text = "Why is that still relevant?",
                    Options = new List<string>
                    {
                        "Women didn't learn to play.",
                        "It isn't, the leagues are equal.",
                        "The gap still affects funding, visibility, and pay equity today."
                    },
                    CorrectAnswer = "c",
                    Explanation = "The historical ban created systemic inequalities that persist in modern women's football."
                }
            }
        };
    }

    private static Story CreateErasureOfWomenStory()
    {
        return new Story
        {
            Title = "The Systematic Erasure of Women Artists, Writers, and Scientists (ongoing, reinforced in the 19th-20th centuries)",
            Questions = new List<Question>
            {
                new Question
                {
                    Text = "It is well known that the cultural \"canon\" (the list of who is taught as the great artists, writers, and scientists) is dominated by men.",
                    Options = new List<string>
                    {
                        "They were the only ones achieving anything.",
                        "Women did not partake in those.",
                        "Women were often erased, forgotten, or misattributed."
                    },
                    CorrectAnswer = "c",
                    Explanation = "Even when women created art, literature, or scientific discoveries, they were often dismissed, misattributed, or forgotten. Examples include Rosalind Franklin in DNA research, Camille Claudel in sculpture, and many others overshadowed by male contemporaries."
                },
                new Question
                {
                    Text = "What exactly happened to women's work?",
                    Options = new List<string>
                    {
                        "Women's work was systematically ignored, dismissed, or credited to men.",
                        "It was given more recognition than men's work.",
                        "Women chose not to publish or share their work."
                    },
                    CorrectAnswer = "a",
                    Explanation = "Women produced significant work, but due to systemic bias, it was often dismissed or attributed to male colleagues."
                },
                new Question
                {
                    Text = "What did that lead to?",
                    Options = new List<string>
                    {
                        "Equal recognition of men and women.",
                        "A cultural canon that underrepresents women's contributions.",
                        "Women dominating the canon."
                    },
                    CorrectAnswer = "b",
                    Explanation = "This erasure shaped who gets remembered, studied, and celebrated, leaving women largely absent from the \"official\" story."
                },
                new Question
                {
                    Text = "How does this affect young people today?",
                    Options = new List<string>
                    {
                        "It makes boys see women as naturally more intellectual.",
                        "It has no effect anymore.",
                        "Young girls see fewer female \"geniuses\", which reinforces stereotypes."
                    },
                    CorrectAnswer = "c",
                    Explanation = "Underrepresentation influences perceptions of who is seen as creative or intelligent."
                },
                new Question
                {
                    Text = "Why is this history important to remember?",
                    Options = new List<string>
                    {
                        "It isn't important anymore.",
                        "Because the effects still shape visibility, recognition, and stereotypes today.",
                        "Because women no longer produce significant work."
                    },
                    CorrectAnswer = "b",
                    Explanation = "Understanding the past helps explain why recognition gaps persist today."
                }
            }
        };
    }
}
