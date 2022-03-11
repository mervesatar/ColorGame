using System;

namespace Color_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int score = 0;
            long timepassed;
            long first;
            long second;
            GetAppInfo();
            GreetUser();
            PrintColorMessage(ConsoleColor.Blue, "The aim in this game is to select the color of the word. \n" +
                "Press 'A' for choosing the left option, press 'D' for right option. \n");

            string[] colors = { "Green", "Yellow", "Blue","Magenta","White", "Red"}; 
            ConsoleColor[] colorsConsole = {  ConsoleColor.Green, ConsoleColor.Yellow,ConsoleColor.Blue, ConsoleColor.Magenta, 
ConsoleColor.White, ConsoleColor.Red };
            PrintColorMessage(ConsoleColor.White, "Press 'y' to play the game!! Press any other key to exit.");
            string input=Console.ReadLine();
            if (input.ToLower() == "y")
            {
              first  = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                while (true)
                {
                    Random rnd = new Random();
                    int colorInt = rnd.Next(0, colors.Length );
                    int color3 = rnd.Next(0, colors.Length );
                    int colorFirst = rnd.Next(0, colors.Length );

                    while (colorFirst == colorInt)
                    {
                        colorFirst = rnd.Next(0, colors.Length);
                     
                    }

                    string [] newArray = {colors[colorInt], colors[colorFirst]};
                    int last = rnd.Next(0, 2);
                    PrintColorMessage(colorsConsole[colorInt], colors[color3]+"\n");
                    PrintColorMessage(ConsoleColor.White, newArray[last]);
                    PrintColorMessage(ConsoleColor.White, "  -----  ");
                    PrintColorMessage(ConsoleColor.White, last==1?newArray[0]:newArray[1]+"\n");
                    int last2 = last == 1 ? 0 : 1;
                    string chose = Console.ReadLine();
                    if (chose.ToLower() == "a")
                    {
                        if (newArray[last] == colors[colorInt])
                        {
                            PrintColorMessage(ConsoleColor.DarkGreen, "CORRECT!!" + "\n");
                            score++;
                            continue;
                        }
                        else
                        {
                            PrintColorMessage(ConsoleColor.DarkRed, "FAILED!" + "\n");
                            second = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                            timepassed = second - first;
                            PrintColorMessage(ConsoleColor.DarkBlue, "Score: " + score + "\n" + "Time passed: " + timepassed);
                            return;

                        }
                    }
                    else if (chose.ToLower() == "d")
                    {
                        if (newArray[last2] == colors[colorInt])
                        {
                            PrintColorMessage(ConsoleColor.DarkGreen, "CORRECT!!" + "\n");
                            score++;
                            continue;
                        }
                        else
                        {
                            PrintColorMessage(ConsoleColor.DarkRed, "FAILED!" + "\n");
                            second = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                            timepassed = second - first;
                            PrintColorMessage(ConsoleColor.DarkBlue, "Score: " + score + "\n" + "Time passed: " + timepassed);
                            return;
                        }

                    }
                    else
                    {
                        second = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                        timepassed = second - first;
                        PrintColorMessage(ConsoleColor.DarkBlue, "Score: " + score + "\n" + "Time passed: " + timepassed);
                        return;
                    }
                }
                }

         
        }
        static void GetAppInfo()
        {
            string appName = "Color Game";
            string appVersion = "1.0.0";
            string appAuthor = "Merve Satar";

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("{0}: Version {1} by {2}", appName, appVersion, appAuthor);

            Console.ResetColor();
        }

        static void GreetUser()
        {
            Console.WriteLine("What is your name?");

            string inputName = Console.ReadLine();

            Console.WriteLine("Hello {0}, let's play a game...", inputName);
        }

        static void PrintColorMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;

            Console.Write(message);

            Console.ResetColor();
        }
    }
}
