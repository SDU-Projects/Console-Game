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
            { MinigameType.Story, () => new StoryMinigame("favourite") },
            { MinigameType.MLModelGame, () => new MLModelGame("Banana") },
            { MinigameType.QuizGame, () => new QuizGame("Apple") },
            { MinigameType.Minigame4, () => new StoryMinigame("favourite") },
            { MinigameType.Minigame5, () => new StoryMinigame("favourite") }
        };
    }

    public IMinigame CreateMinigame(MinigameType type)
    {
        if (_creators.TryGetValue(type, out var creator))
            return creator();

        throw new ArgumentException($"Unknown minigame type: {type}");
    }
}
