namespace MazeGame;

public class Story
{
    public string Title { get; set; } = string.Empty;
    public List<Question> Questions { get; set; } = new();
}
