using System;
using System.IO;
using System.Linq;

namespace GirlfriendsDemands
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            checked
            {
                var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
                if (value == "True")
                    Console.SetIn(new StreamReader("Console.txt"));

                var s = Console.ReadLine();

                var Q = long.Parse(Console.ReadLine().Trim());
                for (int q = 0; q < Q; q++)
                {
                    var A = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
                    var a = A[0];
                    var b = A[1];
                    long dif = b - a;
                    if (a > s.Length - 1)
                    {
                        a = CalculateOffset(s, a);
                    }

                    if (b > s.Length - 1)
                    {
                        b = CalculateOffset(s, b);
                    }

                    if (s[(int)a - 1] == s[(int)b - 1])
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No");
                    }
                }
                Console.ReadKey();
            }
        }

        private static int CalculateOffset(string s, long a)
        {
            var rest = a % s.Length;
            if (rest == 0)
            {
                rest = s.Length;
            }
            return (int)rest;
        }
    }
}