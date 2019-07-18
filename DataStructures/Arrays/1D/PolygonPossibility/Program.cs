using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PolygonPossibility
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

                var N = Int32.Parse(Console.ReadLine().Trim());

                var A = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
                var Max = A.Max(x => x);
                var sum = A.Sum(x => x) - Max;
                if (sum > Max)
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
}