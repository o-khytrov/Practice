using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MonicaAndGamingObsession
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));


            var N = Int32.Parse(Console.ReadLine().Trim());
            var counter = 0;
            while (N % 2 == 0)
            {
                N /= 2;
                counter++;

            }
            Console.WriteLine(counter);
            Console.ReadKey();
        }
    }
}