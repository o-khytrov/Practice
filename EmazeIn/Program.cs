using System;
using System.IO;

namespace EmazeIn
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("Console.txt"));
            var s = Console.ReadLine();
            var x = 0;
            var y = 0;
            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case 'R':
                        x++;
                        break;

                    case 'L':
                        x--;
                        break;

                    case 'D':
                        y--;
                        break;

                    case 'U':
                        y++;
                        break;

                    default:
                        break;
                }
            }

            Console.WriteLine($"{x} {y}");
            Console.ReadKey();
        }
    }
}