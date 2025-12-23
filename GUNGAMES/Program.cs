using Shared.Interfaces;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MazeGame;

public class GunMinigame : IMinigame
{
    public MinigameResult Play()
    {
        RunGame();
        return MinigameResult.Victory("gun1");
    }

    void RunGame()
    {
        Console.WriteLine("GUN GAME");
        Thread.Sleep(2000);
        Console.Clear();
        Console.WriteLine("you move with the arrows and shoot with the spacebar");
        Thread.Sleep(4000);
        Console.Clear();

        // ===== NIVEL 1 =====
        List<BALL> Balls = new()
        {
            new BALL("no", 0, 1, true),
            new BALL("yes", 14, 1, false),
            new BALL("slow", 28, 1, false)
        };

        PlayLevel(
            "¿Is law enough without a cultural change?",
            Balls,
            correctX: 1,
            "Law can set rules, but without cultural change inequality continues in everyday life."
        );

        // ===== NIVEL 2 =====
        List<BALL> Balls2 = new()
        {
            new BALL("yes", 0, 1, false),
            new BALL("fragile", 14, 1, false),
            new BALL("no", 28, 1, true)
        };

        PlayLevel(
            "¿Can there be justice without memory?",
            Balls2,
            correctX: 15,
            "Without memory there is no accountability, only repetition of injustice."
        );

        // ===== NIVEL 3 =====
        List<BALL> Balls3 = new()
        {
            new BALL("power", 0, 1, true),
            new BALL("majority", 14, 1, false),
            new BALL("context", 28, 1, false)
        };

        PlayLevel(
            "¿Who defines what is normal?",
            Balls3,
            correctX: 1,
            "What is considered “normal” is usually shaped by those who hold power."
        );
    }

    void PlayLevel(string question, List<BALL> balls, int correctX, string explanation)
    {
        bool finished = false;
        GUN gun = new GUN(14);
        BULLET bullet = null;

        while (!finished)
        {
            Console.Clear();
            Console.WriteLine(question);

            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.LeftArrow) gun.Left();
                if (key == ConsoleKey.RightArrow) gun.Right();
                if (key == ConsoleKey.Spacebar) bullet = new BULLET(gun.X + 1, gun.Y - 1);
            }

            gun.Representation();

            if (bullet != null)
            {
                bullet.BULLETREPRESENTATION();
                bullet.Up();
            }

            foreach (var ball in balls)
            {
                ball.Representation();
                ball.Down();

                if (ball.Y == gun.Y)
                {
                    Console.Clear();
                    Console.WriteLine("FAILED");
                    Thread.Sleep(1500);
                    ball.Y = 1;
                }

                if (bullet != null && ball.Y >= bullet.Y)
                {
                    if (bullet.X == correctX)
                    {
                        Console.Clear();
                        Console.WriteLine("CORRECT");
                        Console.WriteLine(explanation);
                        Thread.Sleep(5000);
                        finished = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("INCORRECT");
                        Thread.Sleep(1500);
                        bullet = null;
                        ball.Y--;
                        break;
                    }
                }
            }

            Thread.Sleep(500);
        }
    }
}
