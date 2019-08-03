using System;
using System.Collections.Generic;
using System.IO;

namespace RodCuttingProblem
{
    internal class Program
    {
        private static int counter;

        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var T = Int32.Parse(Console.ReadLine().Trim());
            for (int t = 0; t < T; t++)
            {
                counter = 0;

                var num = Int32.Parse(Console.ReadLine().Trim());
                Console.WriteLine((int)Math.Log(num + 1,2) - 1);
            }
            Console.ReadKey();
        }

       
    }
}