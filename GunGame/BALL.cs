namespace GunGame;

class BALL
{
    public string BALLREPRESENTATION;
    public int X;
    public int Y = 0;
    public bool Correct;
    public BALL(string text, int x, int y, bool correct)
    {
        int distance = 12;
        int padding = distance - text.Length;
        int Left = padding / 2;
        int Right = padding - Left;
        BALLREPRESENTATION = "(" + new string(' ', Left) + text + new string(' ', Right) + ")";
        Y = y;
        X = x;
        Correct = correct;
    }
    public void Down()
    {
        Y++;
    }
    public void Representation()
    {
        Console.SetCursorPosition(X, Y);
        Console.Write(BALLREPRESENTATION);
    }

}
