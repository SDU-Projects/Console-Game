using System;
using System.Threading;
using System.Text;

class Program
{
    static void BOX1700(string ans1, string ans2)
    {
        Console.WriteLine("┌───────────────┐");
        Console.WriteLine("│     1700      │");
        Console.WriteLine("│ " + ans1.PadRight(13) + " │");
        Console.WriteLine("│ " + ans2.PadRight(13) + " │");
        Console.WriteLine("└───────────────┘");
        Console.WriteLine();
    }

    static void BOX1800(string ans3, string ans4)
    {
        Console.WriteLine("┌───────────────┐");
        Console.WriteLine("│     1800      │");
        Console.WriteLine("│ " + ans3.PadRight(13) + " │");
        Console.WriteLine("│ " + ans4.PadRight(13) + " │");
        Console.WriteLine("└───────────────┘");
        Console.WriteLine();
    }

    static void BOX1900(string ans5, string ans6)
    {
        Console.WriteLine("┌───────────────┐");
        Console.WriteLine("│     1900      │");
        Console.WriteLine("│ " + ans5.PadRight(13) + " │");
        Console.WriteLine("│ " + ans6.PadRight(13) + " │");
        Console.WriteLine("└───────────────┘");
        Console.WriteLine();
    }

    static void BOX2000(string ans7, string ans8)
    {
        Console.WriteLine("┌───────────────┐");
        Console.WriteLine("│     2000      │");
        Console.WriteLine("│ " + ans7.PadRight(13) + " │");
        Console.WriteLine("│ " + ans8.PadRight(13) + " │");
        Console.WriteLine("└───────────────┘");
        Console.WriteLine();
    }


    static void Main()
    {
        string a1 = "";
        string a2 = "";
        string a3 = "";
        string a4 = "";
        string a5 = "";
        string a6 = "";
        string a7 = "";
        string a8 = "";

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
        Thread.Sleep(10000);
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
            a1 = (Console.ReadLine() ?? "");

            if (a1 == "2000")
            {
                Console.WriteLine();
                Console.WriteLine("Correct!");
                ans7 = "P1";
                Thread.Sleep(1500);
                Console.Clear();
                Console.WriteLine("Gavin McInnes is a British-Canadian writer and media personality, known for co-founding VICE in the 1990s and later founding the far-right group Proud Boys. He became controversial for his anti-feminist and nationalist views. He said the phrase \"95% of women would be happier at home\" in an ABC News interview in 2018.");
                Thread.Sleep(10000);
                Console.Clear();
            }
            else if (a1 == "1900" || a1 == "1700" || a1 == "1800")
            {
                Console.WriteLine();
                Console.WriteLine("Incorrect!");
                Thread.Sleep(1500);
            }
            else
            {
                Console.WriteLine("Not a valid response");
                Thread.Sleep(1500);
            }
        }
        Console.Clear();

        while (a2 != "1900")
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("THE BOX GAME");
            BOX1700(ans1, ans2);
            BOX1800(ans3, ans4);
            BOX1900(ans5, ans6);
            BOX2000(ans7, ans8);

            Console.WriteLine("Phrase 2: We are here, not because we are law-breakers; we are here in our efforts to become law-makers.");
            Console.Write("Write the century you think it was said (1700/1800/1900/2000): ");
            a2 = (Console.ReadLine() ?? "");

            if (a2 == "1900")
            {
                Console.WriteLine();
                Console.WriteLine("Correct!");
                ans5 = "P2";
                Thread.Sleep(1500);
                Console.Clear();
                Console.WriteLine("Emmeline Pankhurst said the quote in 1912 during a speech defending the women’s suffrage movement. She was a British political activist who led the suffragette movement in the early 1900s, founded the Women’s Social and Political Union (WSPU), and played a key role in securing voting rights for women in the United Kingdom.");
                Thread.Sleep(10000);
                Console.Clear();
            }
            else if (a2 == "2000" || a2 == "1700" || a2 == "1800")
            {
                Console.WriteLine();
                Console.WriteLine("Incorrect!");
                Thread.Sleep(1500);
            }
            else
            {
                Console.WriteLine("Not a valid response");
                Thread.Sleep(1500);
            }
        }
        Console.Clear();

        while (a3 != "1700")
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("THE BOX GAME");
            BOX1700(ans1, ans2);
            BOX1800(ans3, ans4);
            BOX1900(ans5, ans6);
            BOX2000(ans7, ans8);

            Console.WriteLine("Phrase 3: Woman is born free and remains equal to man in rights.");
            Console.Write("Write the century you think it was said (1700/1800/1900/2000): ");
            a3 = (Console.ReadLine() ?? "");

            if (a3 == "1700")
            {
                Console.WriteLine();
                Console.WriteLine("Correct!");
                ans1 = "P3";
                Thread.Sleep(1500);
                Console.Clear();
                Console.WriteLine("Olympe de Gouges wrote the Declaration of the Rights of Woman and of the Female Citizen in 1791 during the French Revolution and declared that \"Woman is born free and remains equal to man in rights.\"");
                Thread.Sleep(10000);
                Console.Clear();
            }
            else if (a3 == "2000" || a3 == "1900" || a3 == "1800")
            {
                Console.WriteLine();
                Console.WriteLine("Incorrect!");
                Thread.Sleep(1500);
            }
            else
            {
                Console.WriteLine("Not a valid response");
                Thread.Sleep(1500);
            }
        }
        Console.Clear();
        while (a4 != "1700")
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("THE BOX GAME");
            BOX1700(ans1, ans2);
            BOX1800(ans3, ans4);
            BOX1900(ans5, ans6);
            BOX2000(ans7, ans8);

            Console.WriteLine("Phrase 4: I do not wish them to have power over men; but over themselves.");
            Console.Write("Write the century you think it was said (1700/1800/1900/2000): ");
            a4 = (Console.ReadLine() ?? "");

            if (a4 == "1700")
            {
                Console.WriteLine();
                Console.WriteLine("Correct!");
                ans1 = "P4";
                Thread.Sleep(1500);
                Console.Clear();
                Console.WriteLine("Mary Wollstonecraft wrote in 1792 in \"A Vindication of the Rights of Woman\": \"I do not wish them to have power over men; but over themselves.\"");
                Thread.Sleep(10000);
                Console.Clear();
            }
            else if (a4 == "2000" || a4 == "1900" || a4 == "1800")
            {
                Console.WriteLine();
                Console.WriteLine("Incorrect!");
                Thread.Sleep(1500);
            }
            else
            {
                Console.WriteLine("Not a valid response");
                Thread.Sleep(1500);
            }
        }
        Console.Clear();

        while (a5 != "1800")
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("THE BOX GAME");
            BOX1700(ans1, ans2);
            BOX1800(ans3, ans4);
            BOX1900(ans5, ans6);
            BOX2000(ans7, ans8);

            Console.WriteLine("Phrase 5: We hold these truths to be self-evident: that all men and women are created equal.");
            Console.Write("Write the century you think it was said (1700/1800/1900/2000): ");
            a5 = (Console.ReadLine() ?? "");

            if (a5 == "1800")
            {
                Console.WriteLine();
                Console.WriteLine("Correct!");
                ans3 = "P5";
                Thread.Sleep(1500);
                Console.Clear();
                Console.WriteLine("Elizabeth Cady Stanton wrote in the 1848 Seneca Falls Declaration of Sentiments: \"We hold these truths to be self-evident: that all men and women are created equal.\"");
                Thread.Sleep(10000);
                Console.Clear();
            }
            else if (a5 == "2000" || a5 == "1900" || a5 == "1700")
            {
                Console.WriteLine();
                Console.WriteLine("Incorrect!");
                Thread.Sleep(1500);
            }
            else
            {
                Console.WriteLine("Not a valid response");
                Thread.Sleep(1500);
            }
        }
        Console.Clear();
        while (a6 != "1800")
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("THE BOX GAME");
            BOX1700(ans1, ans2);
            BOX1800(ans3, ans4);
            BOX1900(ans5, ans6);
            BOX2000(ans7, ans8);

            Console.WriteLine("Phrase 6: The legal subordination of one sex to the other is wrong in itself.");
            Console.Write("Write the century you think it was said (1700/1800/1900/2000): ");
            a6 = (Console.ReadLine() ?? "");

            if (a6 == "1800")
            {
                Console.WriteLine();
                Console.WriteLine("Correct!");
                ans3 = "P6";
                Thread.Sleep(1500);
                Console.Clear();
                Console.WriteLine("John Stuart Mill argued against the legal subordination of women in \"The Subjection of Women\" (1869), a key text of 19th-century liberal feminism.");
                Thread.Sleep(10000);
                Console.Clear();
            }
            else if (a6 == "2000" || a6 == "1900" || a6 == "1700")
            {
                Console.WriteLine();
                Console.WriteLine("Incorrect!");
                Thread.Sleep(1500);
            }
            else
            {
                Console.WriteLine("Not a valid response");
                Thread.Sleep(1500);
            }
        }
        Console.Clear();
        while (a7 != "1900")
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("THE BOX GAME");
            BOX1700(ans1, ans2);
            BOX1800(ans3, ans4);
            BOX1900(ans5, ans6);
            BOX2000(ans7, ans8);

            Console.WriteLine("Phrase 7: One is not born, but rather becomes, a woman.");
            Console.Write("Write the century you think it was said (1700/1800/1900/2000): ");
            a7 = (Console.ReadLine() ?? "");

            if (a7 == "1900")
            {
                Console.WriteLine();
                Console.WriteLine("Correct!");
                ans5 = "P7";
                Thread.Sleep(1500);
                Console.Clear();
                Console.WriteLine("Simone de Beauvoir wrote in 1949 in \"The Second Sex\": \"One is not born, but rather becomes, a woman.\"");
                Thread.Sleep(10000);
                Console.Clear();
            }
            else if (a7 == "2000" || a7 == "1700" || a7 == "1800")
            {
                Console.WriteLine();
                Console.WriteLine("Incorrect!");
                Thread.Sleep(1500);
            }
            else
            {
                Console.WriteLine("Not a valid response");
                Thread.Sleep(1500);
            }
        }
        Console.Clear();
        while (a8 != "2000")
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("THE BOX GAME");
            BOX1700(ans1, ans2);
            BOX1800(ans3, ans4);
            BOX1900(ans5, ans6);
            BOX2000(ans7, ans8);

            Console.WriteLine("Phrase 8: We should all be feminists.");
            Console.Write("Write the century you think it was said (1700/1800/1900/2000): ");
            a8 = (Console.ReadLine() ?? "");

            if (a8 == "2000")
            {
                Console.WriteLine();
                Console.WriteLine("Correct!");
                ans7 = "P8";
                Thread.Sleep(1500);
                Console.Clear();
                Console.WriteLine("Chimamanda Ngozi Adichie popularised the phrase in her 2014 essay and TEDx talk titled \"We Should All Be Feminists.\"");
                Thread.Sleep(10000);
                Console.Clear();
            }
            else if (a8 == "1900" || a8 == "1700" || a8 == "1800")
            {
                Console.WriteLine();
                Console.WriteLine("Incorrect!");
                Thread.Sleep(1500);
            }
            else
            {
                Console.WriteLine("Not a valid response");
                Thread.Sleep(1500);
            }
        }
    }
}