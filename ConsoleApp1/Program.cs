using Shared.Interfaces;
using Shared.Models;
using System.Threading;

namespace MazeGame;

public class BoxMinigame : IMinigame
{
    public MinigameResult Play()
    {
        BOXGAMEMain();
        return MinigameResult.Victory("box1");
    }

    void BOX1700(string ans1, string ans2)
    {
        Console.WriteLine("┌───────────────┐");
        Console.WriteLine("│     1700      │");
        Console.WriteLine("│ " + ans1.PadRight(13) + " │");
        Console.WriteLine("│ " + ans2.PadRight(13) + " │");
        Console.WriteLine("└───────────────┘");
        Console.WriteLine();
    }

    void BOX1800(string ans3, string ans4)
    {
        Console.WriteLine("┌───────────────┐");
        Console.WriteLine("│     1800      │");
        Console.WriteLine("│ " + ans3.PadRight(13) + " │");
        Console.WriteLine("│ " + ans4.PadRight(13) + " │");
        Console.WriteLine("└───────────────┘");
        Console.WriteLine();
    }

    void BOX1900(string ans5, string ans6)
    {
        Console.WriteLine("┌───────────────┐");
        Console.WriteLine("│     1900      │");
        Console.WriteLine("│ " + ans5.PadRight(13) + " │");
        Console.WriteLine("│ " + ans6.PadRight(13) + " │");
        Console.WriteLine("└───────────────┘");
        Console.WriteLine();
    }

    void BOX2000(string ans7, string ans8)
    {
        Console.WriteLine("┌───────────────┐");
        Console.WriteLine("│     2000      │");
        Console.WriteLine("│ " + ans7.PadRight(13) + " │");
        Console.WriteLine("│ " + ans8.PadRight(13) + " │");
        Console.WriteLine("└───────────────┘");
        Console.WriteLine();
    }

    void BOXGAMEMain()
    {
        string a1 = "", a2 = "", a3 = "", a4 = "";
        string a5 = "", a6 = "", a7 = "", a8 = "";

        string ans1 = "", ans2 = "";
        string ans3 = "", ans4 = "";
        string ans5 = "", ans6 = "";
        string ans7 = "", ans8 = "";

        Console.WriteLine("THE BOX GAME");
        Thread.Sleep(3000);
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("In this game, you will be presented with several phrases");
        Console.WriteLine("you’ll have to decide which century each one belongs to.");
        Console.WriteLine("Be careful — your instincts might mislead you.");
        Thread.Sleep(6000);
        Console.ResetColor();
        Console.Clear();

        while (a1 != "2000")
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("THE BOX GAME");
            BOX1700(ans1, ans2);
            BOX1800(ans3, ans4);
            BOX1900(ans5, ans6);
            BOX2000(ans7, ans8);

            Console.WriteLine("Phrase 1: 95 percent of women would be happier at home.");
            Console.Write("Write the century you think it was said (1700/1800/1900/2000): ");
            a1 = Console.ReadLine() ?? "";

            if (a1 == "2000")
            {
                ans7 = "P1";
                Console.WriteLine("Correct!");
                Thread.Sleep(1500);
            }
            else
            {
                Console.WriteLine("Incorrect!");
                Thread.Sleep(1500);
            }
        }

        while (a2 != "1900")
        {
            Console.Clear();
            Console.WriteLine("Phrase 2: We are here, not because we are law-breakers;");
            Console.Write("Century: ");
            a2 = Console.ReadLine() ?? "";

            if (a2 == "1900")
            {
                ans5 = "P2";
                Console.WriteLine("Correct!");
                Thread.Sleep(1500);
            }
            else
            {
                Console.WriteLine("Incorrect!");
                Thread.Sleep(1500);
            }
        }

        while (a3 != "1700")
        {
            Console.Clear();
            Console.WriteLine("Phrase 3: Woman is born free and remains equal to man in rights.");
            Console.Write("Century: ");
            a3 = Console.ReadLine() ?? "";

            if (a3 == "1700")
            {
                ans1 = "P3";
                Console.WriteLine("Correct!");
                Thread.Sleep(1500);
            }
            else
            {
                Console.WriteLine("Incorrect!");
                Thread.Sleep(1500);
            }
        }

        while (a4 != "1700")
        {
            Console.Clear();
            Console.WriteLine("Phrase 4: I do not wish them to have power over men;");
            Console.Write("Century: ");
            a4 = Console.ReadLine() ?? "";

            if (a4 == "1700")
            {
                ans1 = "P4";
                Console.WriteLine("Correct!");
                Thread.Sleep(1500);
            }
            else
            {
                Console.WriteLine("Incorrect!");
                Thread.Sleep(1500);
            }
        }

        while (a5 != "1800")
        {
            Console.Clear();
            Console.WriteLine("Phrase 5: We hold these truths to be self-evident...");
            Console.Write("Century: ");
            a5 = Console.ReadLine() ?? "";

            if (a5 == "1800")
            {
                ans3 = "P5";
                Console.WriteLine("Correct!");
                Thread.Sleep(1500);
            }
            else
            {
                Console.WriteLine("Incorrect!");
                Thread.Sleep(1500);
            }
        }

        while (a6 != "1800")
        {
            Console.Clear();
            Console.WriteLine("Phrase 6: The legal subordination of one sex to the other...");
            Console.Write("Century: ");
            a6 = Console.ReadLine() ?? "";

            if (a6 == "1800")
            {
                ans3 = "P6";
                Console.WriteLine("Correct!");
                Thread.Sleep(1500);
            }
            else
            {
                Console.WriteLine("Incorrect!");
                Thread.Sleep(1500);
            }
        }

        while (a7 != "1900")
        {
            Console.Clear();
            Console.WriteLine("Phrase 7: One is not born, but rather becomes, a woman.");
            Console.Write("Century: ");
            a7 = Console.ReadLine() ?? "";

            if (a7 == "1900")
            {
                ans5 = "P7";
                Console.WriteLine("Correct!");
                Thread.Sleep(1500);
            }
            else
            {
                Console.WriteLine("Incorrect!");
                Thread.Sleep(1500);
            }
        }

        while (a8 != "2000")
        {
            Console.Clear();
            Console.WriteLine("Phrase 8: We should all be feminists.");
            Console.Write("Century: ");
            a8 = Console.ReadLine() ?? "";

            if (a8 == "2000")
            {
                ans7 = "P8";
                Console.WriteLine("Correct!");
                Thread.Sleep(1500);
            }
            else
            {
                Console.WriteLine("Incorrect!");
                Thread.Sleep(1500);
            }
        }
    }
}
