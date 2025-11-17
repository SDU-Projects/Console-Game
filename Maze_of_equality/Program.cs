using Mini_Stories;

namespace Maze
{
    class Program
    {
        public static void Main()
        {
            Vars.connections();
            movement();


            void movement()
            {
                bool running = true;
                Func.draw_maze();
                while (running)
                {
                    string output = "";
                    if (Vars.currentPos == Vars.point12 | Vars.currentPos == Vars.point15 | Vars.currentPos == Vars.point8 | Vars.currentPos == Vars.point14 | Vars.currentPos == Vars.point11)
                    {
                        Console.WriteLine("Would you like to play the minigame? (Y/N)");
                        string? playGame = Console.ReadLine()?.ToLower();
                        switch (playGame)
                        {
                            case "y":
                                if (Vars.currentPos?.interaction != null)
                                {
                                    Vars.currentPos.interaction();
                                }
                                else
                                {
                                    output = "Oh-oh, the programmer didn't implement this function.";
                                }
                                break;

                            case "n":
                                break;

                            default:
                                break;
                        }
                    }

                    // add an else statement here
                    Console.WriteLine("Which way do you want to go? (up, down, left, right)\n");
                    string? command = Console.ReadLine()?.ToLower();
                    switch (command)
                    {
                        case "up":
                            if (Vars.currentPos?.up != null)
                            {
                                Vars.maze[Vars.currentPos.coords[0]][Vars.currentPos.coords[1]] = ' ';
                                Vars.currentPos = Vars.currentPos.up;
                                Vars.maze[Vars.currentPos.coords[0]][Vars.currentPos.coords[1]] = 'O';
                            }
                            else if (Vars.currentPos == Vars.point21)
                            {
                                InteractionPoints.maze_exit();
                                if (Vars.playerWon)
                                {
                                    running = false;
                                    break;
                                }
                            }
                            else
                            {
                                output = "You ran full force into a wall. Ouch.";
                            }
                            break;

                        case "down":
                            if (Vars.currentPos?.down != null)
                            {
                                Vars.maze[Vars.currentPos.coords[0]][Vars.currentPos.coords[1]] = ' ';
                                Vars.currentPos = Vars.currentPos.down;
                                Vars.maze[Vars.currentPos.coords[0]][Vars.currentPos.coords[1]] = 'O';

                            }
                            else if (Vars.currentPos == Vars.point1)
                            {
                                if (Vars.maze[14][1] == ' ')
                                {
                                    InteractionPoints.maze_entrance();
                                    Vars.maze[14][0] = '+';
                                    for (int m = 1; m < 6; m++)
                                    {
                                        Vars.maze[14][m] = '-';
                                    }
                                }
                                else
                                {
                                    output = "You ran full force into a wall. Ouch.";
                                }
                            }
                            else
                            {
                                output = "You ran full force into a wall. Ouch.";
                            }
                            break;

                        case "left":
                            if (Vars.currentPos?.left != null)
                            {
                                Vars.maze[Vars.currentPos.coords[0]][Vars.currentPos.coords[1]] = ' ';
                                Vars.currentPos = Vars.currentPos.left;
                                Vars.maze[Vars.currentPos.coords[0]][Vars.currentPos.coords[1]] = 'O';

                            }
                            else
                            {
                                output = "You ran full force into a wall. Ouch.";
                            }
                            break;

                        case "right":
                            if (Vars.currentPos?.right != null)
                            {
                                Vars.maze[Vars.currentPos.coords[0]][Vars.currentPos.coords[1]] = ' ';
                                Vars.currentPos = Vars.currentPos.right;
                                Vars.maze[Vars.currentPos.coords[0]][Vars.currentPos.coords[1]] = 'O';

                            }
                            else
                            {
                                output = "You ran full force into a wall. Ouch.";
                            }
                            break;

                        default:
                            Console.WriteLine("Invalid command.");
                            running = false;  // delete this later
                            break;
                    }
                    if (running)
                    {
                        Func.draw_maze();

                        if (output != "")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(output);
                            Console.ResetColor();
                        }
                    }
                }
            }
        }
    }

    public class Vars
    {
        public static char[][] maze = [
            ['+', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '+', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', ' ', ' ', 'F', ' ', '|'],
            ['|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'],
            ['|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'],
            ['|', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '+', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '+'],
            ['|', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|', ' ', '2', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'],
            ['|', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '4', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'],
            ['|', ' ', ' ', ' ', ' ', ' ', '+', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '+', ' ', ' ', ' ', ' ', ' ', '+', '-', '-', '-', '-', '-', '+', ' ', ' ', ' ', ' ', ' ', '|'],
            ['|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', '1', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|'],
            ['|', ' ', '3', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', '5', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|'],
            ['+', '-', '-', '-', '-', '-', '-', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '+', '-', '-', '-', '-', '-', '+', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|'],
            ['|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'],
            ['|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'],
            ['|', ' ', ' ', ' ', ' ', ' ', '+', '-', '-', '-', '-', '-', '+', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '+', ' ', ' ', ' ', ' ', ' ', '|'],
            ['|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'],
            ['|', ' ', ' ', 'S', ' ', ' ', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '+'],
        ];

        public static string[] collectedWords = [];
        public static string sentence = "1 2 3 4 5";  // UPDATE WHEN WE HAVE A SENTENCE
        public static int total_words = 5;  // UPDATE WHEN WE HAVE A SENTENCE
        public static bool playerWon = false;

        // 0  1  2  3  4  5  6  7  8  9  10 11 12
        // 0  +-----------+-------------------  F |  0
        // 1  |  X     X  |  X     X            X |  1
        //    |           |                       |  
        // 2  |     |     |     |     +-----------+  2
        //    |     |           |     | 2         |  
        // 3  |     |  X     X4 |     |  X     X  |  3
        // 4  |     +-----------+     +-----+     |  4
        // 5  |  X     X     X  |  X  |  1  |     |  5
        //    | 3               |  5  |  X  |     |
        // 6  +------     |     +-----+     |     |  6
        //    |           |                       |
        // 7  |  X     X  |  X           X     X  |  7
        // 8  |     +-----+-----------------+     |  8
        // 9  |  X                             X  |  9
        // 10 |  S  ------------------------------+  10
        // 0  1  2  3  4  5  6  7  8  9  10 11 12

        // 0  1  2  3  4  5  6  7  8  9  10 11 12
        // 0  +-----------+-------------------  F |  
        // 1  |  17   18  |  19    20          21 |  1
        //    |           |                       |  
        // 2  |     |     |     |     +-----------+  2
        //    |     |       14  |     | O         |  
        // 3  |     |  13     O |     | 15    16  |  5
        // 4  |     +-----------+     +-----+     |  
        // 5  |  8     9    10  | 11  |  O  |     |  7
        //    | O               |  O  | 12  |     |
        // 6  +------     |     +-----+     |     |  
        //    |           |                       |
        // 7  |  3     4  |  5           6     7  |  11
        // 8  |     +-----+-----------------+     |  
        // 9  |  1                             2  |  13
        // 10 |  S  ------------------------------+  
        //       3     9     15   21    27    33


        // points
        public static MazePoint point1 = new([13, 3]);
        public static MazePoint point2 = new([13, 33]);
        public static MazePoint point3 = new([11, 3]);
        public static MazePoint point4 = new([11, 9]);
        public static MazePoint point5 = new([11, 15]);
        public static MazePoint point6 = new([11, 27]);
        public static MazePoint point7 = new([11, 33]);
        public static MazePoint point8 = new([7, 3]);
        public static MazePoint point9 = new([7, 9]);
        public static MazePoint point10 = new([7, 15]);
        public static MazePoint point11 = new([7, 21]);
        public static MazePoint point12 = new([8, 27]);
        public static MazePoint point13 = new([5, 9]);
        public static MazePoint point14 = new([4, 15]);
        public static MazePoint point15 = new([5, 27]);
        public static MazePoint point16 = new([5, 33]);
        public static MazePoint point17 = new([1, 3]);
        public static MazePoint point18 = new([1, 9]);
        public static MazePoint point19 = new([1, 15]);
        public static MazePoint point20 = new([1, 21]);
        public static MazePoint point21 = new([1, 34]);

        public static MazePoint? currentPos;


        public static void connections()
        {
            // point connections
            point1.up = point3;
            point1.right = point2;

            point2.left = point1;
            point2.up = point7;

            point3.down = point1;
            point3.right = point4;

            point4.left = point3;
            point4.up = point9;

            point5.up = point10;
            point5.right = point6;

            point6.left = point5;
            point6.up = point12;
            point6.right = point7;

            point7.left = point6;
            point7.down = point2;
            point7.up = point16;

            point8.up = point17;
            point8.right = point9;

            point9.down = point4;
            point9.left = point8;
            point9.right = point10;

            point10.left = point9;
            point10.down = point5;

            point11.up = point20;

            point12.down = point6;

            point13.up = point18;
            point13.right = point14;

            point14.left = point13;
            point14.up = point19;

            point15.right = point16;

            point16.left = point15;
            point16.down = point7;

            point17.down = point8;
            point17.right = point18;

            point18.left = point17;
            point18.down = point13;

            point19.down = point14;
            point19.right = point20;

            point20.left = point19;
            point20.down = point11;
            point20.right = point21;

            point21.left = point20;

            // point interaction
            point1.interaction = InteractionPoints.maze_entrance;
            point12.interaction = InteractionPoints.MiniStories;
            point15.interaction = InteractionPoints.minigame_2;
            point8.interaction = InteractionPoints.minigame_3;
            point14.interaction = InteractionPoints.minigame_4;
            point11.interaction = InteractionPoints.minigame_5;
            point21.interaction = InteractionPoints.maze_exit;

            currentPos = point1;  // beginning of the game
            maze[currentPos.coords[0]][currentPos.coords[1]] = 'O';
        }
    }

    public class InteractionPoints
    {
        public static void maze_entrance()
        {
            Console.WriteLine("Why would you want to go back to where you came from?");
        }


        public static void maze_exit()
        {
            // Console.WriteLine("You can't exit the maze yet. I haven't added this function.");
            if (Vars.collectedWords.Length == Vars.total_words)
            {
                while (!Vars.playerWon)
                {
                    Console.WriteLine("To complete the maze arrange all collected words in correct order to make a sentence.");
                    Func.write_collected_words();
                    string? playerAnswer = Console.ReadLine()?.ToLower();

                    if (playerAnswer == Vars.sentence)
                    {
                        Vars.playerWon = true;
                        break;
                    }
                }
                Func.end_game();
            }
            else
            {
                Console.WriteLine("You haven't completed all minigames yet.");
            }
        }


        public static void MiniStories()
        {
            string word = "mini1";
            bool victory = MiniStory.Story();

            if (victory)
            {
                Func.NewWordWrite(word);
            }
        }


        public static void minigame_2()
        {
            string word = "mini2";
            bool victory = pretend_that_this_is_a_minigame();  // THIS IS A PLACEHOLDER FUNCTION, REPLACE WHEN MINIGAMES ARE MADE

            if (victory)
            {
                Func.NewWordWrite(word);
            }
        }


        public static void minigame_3()
        {
            string word = "mini3";
            bool victory = pretend_that_this_is_a_minigame();  // THIS IS A PLACEHOLDER FUNCTION, REPLACE WHEN MINIGAMES ARE MADE

            if (victory)
            {
                Func.NewWordWrite(word);
            }
        }


        public static void minigame_4()
        {
            string word = "mini4";
            bool victory = pretend_that_this_is_a_minigame();  // THIS IS A PLACEHOLDER FUNCTION, REPLACE WHEN MINIGAMES ARE MADE

            if (victory)
            {
                Func.NewWordWrite(word);
            }
        }


        public static void minigame_5()
        {
            string word = "mini5";
            bool victory = pretend_that_this_is_a_minigame();  // THIS IS A PLACEHOLDER FUNCTION, REPLACE WHEN MINIGAMES ARE MADE

            if (victory)
            {
                Func.NewWordWrite(word);
            }
        }


        // WHEN MINIGAMES ARE MADE THIS FUNCTION WILL NOT BE NEEDED ANYMORE
        public static bool pretend_that_this_is_a_minigame()
        {
            Console.WriteLine("t for true, f for false");
            string? something = Console.ReadLine()?.ToLower();
            if (something == "t")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class Func
    {
        public static void draw_maze()
        {
            Console.Clear();

            for (int i = 0; i < Vars.maze.Length; i++)
            {
                for (int j = 0; j < Vars.maze[i].Length; j++)
                {
                    Console.Write(Vars.maze[i][j]);
                }
                Console.WriteLine();
            }
        }


        public static void write_collected_words()
        {
            Console.Write($"Words collected:");
            for (int i = 0; i < Vars.collectedWords.Length; i++)
            {
                if (i == 0)
                {
                    Console.Write($" {Vars.collectedWords[i]}");
                }
                else
                {
                    Console.Write($", {Vars.collectedWords[i]}");
                }
            }
            Console.WriteLine(".");
        }


        public static void end_game()
        {
            Console.WriteLine("Congratulations, you've completed the Maze of equality!");
            Console.WriteLine("We hope you enjoyed playing. :)");
        }


        public static void NewWordWrite(string word)
        {
            if (!Vars.collectedWords.Contains(word))
            {
                Vars.collectedWords = [.. Vars.collectedWords, word];
            }
            Console.WriteLine($"New word '{word}' has been added to your collection.");
            write_collected_words();
        }
    }

    public class MazePoint(int[] phy)
    {
        public int[] coords = phy;
        public MazePoint? up;
        public MazePoint? down;
        public MazePoint? left;
        public MazePoint? right;
        public Action? interaction;
    }

}