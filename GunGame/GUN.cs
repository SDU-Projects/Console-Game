namespace GunGame;

class GUN
{
    public int Y = 25;
    public int X;
    public string GUNREPRESENTATION = "[^]";

    public void Left()
    {
        if (X > 0)
        {
            X -= 14;
        }
        else
        {
            Console.WriteLine("you cant move to the left");
        }
    }
    public void Right()
    {
        if (X < 28)
        {
            X += 14;
        }
        else
        {
            Console.WriteLine("you cant move to the right");
        }
    }
    public GUN(int initX)
    {
        X = initX;
    }
    public void Representation()
    {
        Console.SetCursorPosition(X, Y);
        Console.Write(GUNREPRESENTATION);
    }
}
