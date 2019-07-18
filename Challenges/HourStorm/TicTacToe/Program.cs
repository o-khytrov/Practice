using System;
using System.IO;

namespace TicTacToe
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));
            var ar = new int[3, 3];
            var ZeroCount = 0;
            var XCount = 0;

            var Xhor = 0;
            var Ohor = 0;
            var XVert = 0;
            var Overt = 0;
            var dots = 0;
            var winner = string.Empty;
            for (int i = 0; i < 3; i++)
            {
                var line = Console.ReadLine();
                for (int j = 0; j < line.Length; j++)
                {
                    if (line == "XXX")
                    {
                        Xhor++;
                    }
                    if (line == "OOO")
                    {
                        Ohor++;
                    }
                    if (line[j] == 'X')
                    {
                        XCount++;
                    }
                    if (line[j] == 'O')
                    {
                        ZeroCount++;
                    }
                    if (line[j] == '.')
                    {
                        dots++;
                    }
                    ar[i, j] = line[j];
                }
            }
            for (int j = 0; j < 3; j++)
            {
                var col = string.Empty;

                for (int i = 0; i < 3; i++)
                {
                    col = col + ((char)ar[i, j]).ToString();
                }
                if (col == "XXX")
                {
                    XVert++;
                }
                if (col == "OOO")
                {
                    Overt++;
                }
            }
            var diagonal1 = new string(new char[] { (char)ar[2, 0], (char)ar[1, 1], (char)ar[0, 2] });
            var diagonal2 = new string(new char[] { (char)ar[0, 0], (char)ar[1, 1], (char)ar[2, 2] });
            if (diagonal1 == "XXX")
            {
                XVert++;
            }
            if (diagonal2 == "XXX")
            {
                XVert++;
            }
            if (diagonal2 == "OOO")
            {
                Overt++;
            }
            if (diagonal1 == "OOO")
            {
                Overt++;
            }
            if (ZeroCount > XCount || Math.Abs(XCount - ZeroCount) > 1)
            {
                Console.WriteLine("Wait, what?");
            }
            else
            {
                if (Xhor == 1 && Ohor == 0 || XVert == 1 && Ohor == 0)
                {
                    winner = "X";
                }
                else if (Xhor == 0 && Ohor == 1 || Overt == 1 && XVert == 0)
                {
                    winner = "O";
                }
                if (winner != string.Empty)
                {
                    Console.WriteLine($"{winner} won.");
                }
                else if (dots == 0)
                {
                    Console.WriteLine("It is a draw.");
                }
                else
                {
                    var turn = XCount > ZeroCount;
                    
                }

            }

            Console.ReadKey();
        }
    }
}