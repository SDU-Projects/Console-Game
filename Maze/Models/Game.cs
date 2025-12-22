using Maze.Enums;
using Maze.Services;

namespace Maze.Models;

public class Game
{
    private readonly Maze _maze;
    private readonly Player _player;
    private readonly ConsoleUI _ui = new();
    private readonly IMinigameFactory _minigameFactory;
    private readonly GameState _state;

    public Game(Maze maze, Player player, IMinigameFactory minigameFactory)
    {
        _maze = maze ?? throw new ArgumentNullException(nameof(maze));
        _player = player ?? throw new ArgumentNullException(nameof(player));
        _minigameFactory = minigameFactory ?? throw new ArgumentNullException(nameof(minigameFactory));
        _state = new GameState(maze.GetRequiredWordsCount());
    }

    public void Start()
    {
        _ui.ShowMazeWelcomeMessage();
        
        while (!_state.IsGameOver)
        {
            _ui.DrawMaze(_maze, _player.CurrentPosition);
            
            if (_maze.HasInteractionAt(_player.CurrentPosition))
            {
                HandleInteraction();
            }

            var direction = _ui.GetMovementDirection();
            ProcessMovement(direction);
        }

        ShowGameResult();
    }

    private void HandleInteraction()
    {
        if (!_ui.AskToPlayMinigame())
            return;

        var minigameType = _maze.GetMinigameTypeAt(_player.CurrentPosition);
        var minigame = _minigameFactory.CreateMinigame(minigameType);
        
        var result = minigame.Play();
        _ui.DrawMaze(_maze, _player.CurrentPosition);

        if (result.Success && !string.IsNullOrEmpty(result.WordCollected))
        {
            _state.CollectWord(result.WordCollected);
            _ui.ShowWordCollected(result.WordCollected, _state.CollectedWords);
        }
    }

    private void ProcessMovement(Direction direction)
    {
        var newPosition = _maze.GetAdjacentPosition(_player.CurrentPosition, direction);

        if (newPosition == null)
        {
            _ui.ShowWallCollision();
            return;
        }
        else
        {
            if (_maze.IsExitPosition((Position)newPosition))
            {
                HandleExitAttempt();
                return;
            }

            if (_maze.IsEntrancePosition((Position)newPosition))
            {
                _ui.ShowMessage("Why would you want to go back?");
                return;
            }

            _player.MoveTo((Position)newPosition);
        }


    }

    private void HandleExitAttempt()
    {
        if (!_state.HasCollectedAllWords())
        {
            _ui.ShowMessage("You haven't completed all minigames yet.");
            return;
        }

        var playerSentence = _ui.AskForSentence(_state.CollectedWords);
        
        if (_state.ValidateSentence(playerSentence))
        {
            _state.CompleteGame();
        }
        else
        {
            _ui.ShowMessage("Incorrect sentence. Try again!");
        }
    }

    private void ShowGameResult()
    {
        if (_state.IsVictory)
        {
            _ui.ShowVictoryMessage();
        }
    }
}
