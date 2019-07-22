using System;
using System.Collections.Generic;
using System.IO;

namespace SuperBalancedBraket
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var T = Int32.Parse(Console.ReadLine().Trim());
            for (int t = 0; t < T; t++)
            {
                var stack1 = new Stack<char>();
                var line = Console.ReadLine();

                var median = line.Length / 2;
                var leftSide = line.Substring(0, median);
                var rightSide = line.Substring(median, line.Length - median);

                leftSide = leftSide.Replace(")", "");
                rightSide = rightSide.Replace("(", "");
                var final = leftSide + rightSide;
                Console.WriteLine(final.Length);
            }
            Console.ReadKey();
        }
    }
}