using System;
using System.IO;
using System.Linq;

namespace JumpingOnTheClouds
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var N = Int32.Parse(Console.ReadLine().Trim());

            var A = Console.ReadLine().Trim().Split(' ').Select(x => x == "0").ToArray();
            int jumps = 0;
            int c = 0;
            while (c < A.Length - 1)
            {
                if (c < A.Length - 2 && A[c + 2])
                {
                    jumps++;
                    c += 2;
                    continue;
                }

                jumps++;
                c++;
            }
            Console.WriteLine(jumps);
            Console.ReadKey();
        }
    }
}