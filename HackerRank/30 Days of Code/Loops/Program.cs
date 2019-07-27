using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Loops
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));


            var n = Int32.Parse(Console.ReadLine().Trim());
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{n} x {i + 1} = {n * i + 1}");
            }
            Console.ReadKey();
        }
    }
}