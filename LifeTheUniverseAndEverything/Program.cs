using System;
using System.IO;

namespace LifeTheUniverseAndEverything
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("Console.txt"));
            int d = 0;
            var process = true;
            while (process)
            {
                d = Int32.Parse(Console.ReadLine());
                if (d == 42)
                {
                    process = false;
                }
                else
                {
                    Console.WriteLine(d);
                }
            }
        }
    }
}