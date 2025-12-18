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
            { MinigameType.Story, () => new StoryMinigame("Secret") },
            { MinigameType.MLModelGame, () => new MLModelGame("Santa") },
            { MinigameType.QuizGame, () => new QuizGame("Wants") },
            { MinigameType.RouletteGame, () => new RouletteGame("Some") },
            { MinigameType.BoxGame, () => new BoxGame("Secret") },
            { MinigameType.GunGame, () => new GunMiniGame("Gift") }
        };
    }

    public IMinigame CreateMinigame(MinigameType type)
    {
        if (_creators.TryGetValue(type, out var creator))
            return creator();

        throw new ArgumentException($"Unknown minigame type: {type}");
    }
}
