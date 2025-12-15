namespace Maze;

public class MiniStory
{
    public static int points;

    public static bool Story()
    {
        Console.WriteLine("Welcome to Mini Stories!");
        // add the story
        Action[] arrStories = [TheActualStories.Ban_On_Football];
        int numberOfStories = arrStories.Length;

        int cur_story = FuncsStory.story_picker(numberOfStories);
        MiniStory.points = 0;
        arrStories[cur_story]();

        if (MiniStory.points >= 4)
        {
            Console.WriteLine("Congratulations, you won!");
            return true;
        }
        else
        {
            Console.WriteLine("You lost, try again.");
            return false;
        }
    }
}

public class TheActualStories
{
    public static void Ban_On_Football() // change this into a bool later (unless theres a function handling points?)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("The Ban on Women's Football (England, 1921)");
        Console.ResetColor();

        string? userAnswer;
        string? prev_correct;

        Console.WriteLine("It is well known that football (soccer) is the most popular sport in the world. Specifically, that applies to male football league.");
        Console.WriteLine("\ta)  That has always been the case\n\tb)  Female league used to be more popular.\n\tc)  They used to be equally popular.");
        userAnswer = Console.ReadLine()?.ToLower();

        prev_correct = FuncsStory.ans_checker(userAnswer, "b");

        Console.WriteLine($"That's {prev_correct}! In the early 20th century, women's football in the UK drew huge crowds — sometimes tens of thousands of fans, especially after World War I when women's teams raised money for charities.\nSo what changed?");
        Console.WriteLine("\ta)  Women lost interest.\n\tb)  Men played better.\n\tc)  Women got banned from playing.");
        userAnswer = Console.ReadLine()?.ToLower();

        prev_correct = FuncsStory.ans_checker(userAnswer, "c");

        Console.WriteLine($"That's {prev_correct}! In 1921, the Football Association (FA) declared that “the game of football is quite unsuitable for females,” and banned women from playing on official FA pitches.\nWhat did the women do?");
        Console.WriteLine("\ta)  Never played again.\n\tb)  Played on small, unofficial fields.\n\tc)  Played on the fields anyway.");
        userAnswer = Console.ReadLine()?.ToLower();

        prev_correct = FuncsStory.ans_checker(userAnswer, "b");

        Console.WriteLine($"That's {prev_correct}! Women continue to play, but due to them being banned from the official pitches they were unable to accomodate the crowds of anywhere near to similar size as the male league could.\nWhen was the ban lifted?");
        Console.WriteLine("\ta)  1971\n\tb)  2000\n\tc)  1937");
        userAnswer = Console.ReadLine()?.ToLower();

        prev_correct = FuncsStory.ans_checker(userAnswer, "a");

        Console.WriteLine($"That's {prev_correct}! The ban lasted 50 years, stalling the growth of women's football for generations. By the time it was lifted in 1971, men's leagues had decades of institutional investment and media exposure.\nWhy is that still relevant?");
        Console.WriteLine("\ta)  Women didn't learn to play.\n\tb)  It isn't, the leagues are equal.\n\tc)  The gap still affects funding, visibility, and pay equity today.");
        userAnswer = Console.ReadLine()?.ToLower();

        prev_correct = FuncsStory.ans_checker(userAnswer, "c");

        Console.WriteLine($"That's {prev_correct}!");
    }
}

public class FuncsStory
{
    public static int story_picker(int numberOfStories)
    {
        Random rnd = new Random();
        int pickedStory = rnd.Next(0, numberOfStories);

        return pickedStory;
    }

    public static string ans_checker(string userAnswer, string corrAnswer)
    {
        string corr;
        if (userAnswer == corrAnswer)
        {
            corr = "correct";
            MiniStory.points++;
        }
        else
        {
            corr = "wrong";
        }

        return corr;
    }
}
