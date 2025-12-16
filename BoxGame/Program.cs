using System;
using System.Threading;
using System.Collections.Generic;
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
class Program
{
    static void Main()
    {
        Console.WriteLine("GUN GAME");
        Thread.Sleep(2000);
        Console.Clear();
        Console.WriteLine("you move with the arrows and shoot with the spacebar");
        Thread.Sleep(4000);
        Console.Clear();
        List<BALL> Balls = new List<BALL>()
    {
        new BALL("no",0, 1, true),
        new BALL("yes",14, 1, false),
        new BALL("slow",28,1, false)
    };
        bool gameover = false;
        GUN gun = new GUN(14);
        BULLET bullet = null;
        while (!gameover)
        {
            Console.Clear();
            Console.WriteLine("¿Is law enough without a cultural change?");
            if (Console.KeyAvailable)
            {
                ConsoleKey Key = Console.ReadKey(true).Key;
                if (Key == ConsoleKey.LeftArrow)
                {
                    gun.Left();
                }
                if (Key == ConsoleKey.Spacebar)
                {
                    bullet = new BULLET(gun.X + 1, gun.Y - 1);
                }
                if (Key == ConsoleKey.RightArrow)
                {
                    gun.Right();
                }
            }

            gun.Representation();
            if (bullet != null)
            {
                bullet.BULLETREPRESENTATION();
                bullet.Up();
            }
            foreach (BALL BALLS1 in Balls)
            {

                BALLS1.Representation();
                BALLS1.Down();
                if (BALLS1.Y == gun.Y)
                {
                    Console.Clear();
                    Console.WriteLine("FAILED");
                    Thread.Sleep(2000);
                    BALLS1.Y = 1;
                    break;
                }
                if (bullet != null && BALLS1.Y >= bullet.Y && bullet.X == 1)
                {
                    Console.Clear();
                    Console.WriteLine("CORRECT");
                    Console.WriteLine("Law can set rules, but without cultural change inequality continues in everyday life.");
                    Thread.Sleep(8000);
                    Console.Clear();
                    Console.WriteLine("NEXT LEVEL");
                    Thread.Sleep(2000);
                    Console.Clear();
                    gameover = true;
                    break;
                }
                if (bullet != null && BALLS1.Y >= bullet.Y && bullet.X >= 13)
                {
                    Console.WriteLine("INCORRECT");
                    Thread.Sleep(1500);
                    bullet = null;
                    BALLS1.Y -= 1;
                    break;


                }

            }

            Thread.Sleep(500);
        }
        List<BALL> Ballsss = new List<BALL>()
    {
        new BALL("yes",0, 1, false),
        new BALL("fragile",14, 1, false),
        new BALL("no",28,1, true)
    };
        bool gameoverrr = false;
        GUN gunnn = new GUN(14);
        BULLET bullettt = null;
        while (!gameoverrr)
        {
            Console.Clear();
            Console.WriteLine("¿Can there be justice without memory?");
            if (Console.KeyAvailable)
            {
                ConsoleKey Key = Console.ReadKey(true).Key;
                if (Key == ConsoleKey.LeftArrow)
                {
                    gunnn.Left();
                }
                if (Key == ConsoleKey.Spacebar)
                {
                    bullettt = new BULLET(gunnn.X + 1, gunnn.Y - 1);
                }
                if (Key == ConsoleKey.RightArrow)
                {
                    gunnn.Right();
                }
            }

            gunnn.Representation();
            if (bullettt != null)
            {
                bullettt.BULLETREPRESENTATION();
                bullettt.Up();
            }
            foreach (BALL BALLSS1 in Ballsss)
            {

                BALLSS1.Representation();
                BALLSS1.Down();
                if (BALLSS1.Y == gunnn.Y)
                {
                    Console.Clear();
                    Console.WriteLine("FAILED");
                    Thread.Sleep(2000);
                    BALLSS1.Y = 1;
                }
                if (bullettt != null && BALLSS1.Y >= bullettt.Y && bullettt.X == 15)
                {
                    Console.Clear();
                    Console.WriteLine("CORRECT");
                    Console.WriteLine("Without memory there is no accountability, only repetition of injustice.");
                    Thread.Sleep(8000);
                    Console.Clear();
                    Console.WriteLine("NEXT LEVEL");
                    Thread.Sleep(2000);
                    Console.Clear();
                    gameoverrr = true;
                    break;
                }
                if (bullettt != null && BALLSS1.Y >= bullettt.Y && bullettt.X != 15)
                {
                    Console.WriteLine("INCORRECT");
                    Thread.Sleep(1500);
                    bullettt = null;
                    BALLSS1.Y -= 1;
                    break;


                }

            }

            Thread.Sleep(500);
        }
        List<BALL> Ballss = new List<BALL>()
    {
        new BALL("power",0, 1, true),
        new BALL("majority",14, 1, false),
        new BALL("context",28,1, false)
    };
        bool gameoverr = false;
        GUN gunn = new GUN(14);
        BULLET bullett = null;
        while (!gameoverr)
        {
            Console.Clear();
            Console.WriteLine("¿Who defines what is normal?");
            if (Console.KeyAvailable)
            {
                ConsoleKey Key = Console.ReadKey(true).Key;
                if (Key == ConsoleKey.LeftArrow)
                {
                    gunn.Left();
                }
                if (Key == ConsoleKey.Spacebar)
                {
                    bullett = new BULLET(gunn.X + 1, gunn.Y - 1);
                }
                if (Key == ConsoleKey.RightArrow)
                {
                    gunn.Right();
                }
            }

            gunn.Representation();
            if (bullett != null)
            {
                bullett.BULLETREPRESENTATION();
                bullett.Up();
            }
            foreach (BALL BALLSS1 in Ballss)
            {

                BALLSS1.Representation();
                BALLSS1.Down();
                if (BALLSS1.Y == gunn.Y)
                {
                    Console.Clear();
                    Console.WriteLine("FAILED");
                    Thread.Sleep(2000);
                    BALLSS1.Y = 1;
                }
                if (bullett != null && BALLSS1.Y >= bullett.Y && bullett.X == 1)
                {
                    Console.Clear();
                    Console.WriteLine("CORRECT");
                    Console.WriteLine("What is considered “normal” is usually shaped by those who hold power.");
                    Thread.Sleep(8000);
                    Console.Clear();
                    Console.WriteLine("NEXT LEVEL");
                    Thread.Sleep(2000);
                    Console.Clear();
                    gameoverr = true;
                    break;
                }
                if (bullett != null && BALLSS1.Y >= bullett.Y && bullett.X >= 13)
                {
                    Console.WriteLine("INCORRECT");
                    Thread.Sleep(1500);
                    bullett = null;
                    BALLSS1.Y -= 1;
                    break;


                }

            }

            Thread.Sleep(500);
        }
    }
}