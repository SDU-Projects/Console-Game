namespace GunGame;

class BULLET
{
    public string bullet = "|";
    public int Y;
    public int X;
    public BULLET(int x, int y)
    {
        Y = y;
        X = x;
    }
    public void Up()
    {
        Y--;
    }
    public void BULLETREPRESENTATION()
    {
        Console.SetCursorPosition(X, Y);
        Console.Write(bullet);
    }
}
