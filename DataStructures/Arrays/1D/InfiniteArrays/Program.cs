using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace InfiniteArrays
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

                var Q = Int32.Parse(Console.ReadLine().Trim());

                var L = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();

                var R = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();


            }
            Console.ReadKey();
        }
    }
}