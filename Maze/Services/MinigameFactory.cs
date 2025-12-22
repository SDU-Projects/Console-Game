using GunGame;
using Maze.Enums;
using MazeGame;
using ModelMiniGame;
using Shared.Interfaces;

namespace Maze.Services;

public interface IMinigameFactory
{
    IMinigame CreateMinigame(MinigameType type);
}

public class MinigameFactory : IMinigameFactory
{
    private readonly Dictionary<MinigameType, Func<IMinigame>> _creators;

    public MinigameFactory()
    {
        _creators = new Dictionary<MinigameType, Func<IMinigame>>
        {
            { MinigameType.Story, () => new StoryMinigame("Recognize") },
            { MinigameType.MLModelGame, () => new MLModelGame("women's") },
            { MinigameType.QuizGame, () => new QuizGame("history") },
            { MinigameType.RouletteGame, () => new RouletteGame("change") },
            { MinigameType.BoxGame, () => new BoxGame("society") },
            { MinigameType.GunGame, () => new GunMiniGame("today") }
        };
    }

    public IMinigame CreateMinigame(MinigameType type)
    {
        if (_creators.TryGetValue(type, out var creator))
            return creator();

        throw new ArgumentException($"Unknown minigame type: {type}");
    }
}
