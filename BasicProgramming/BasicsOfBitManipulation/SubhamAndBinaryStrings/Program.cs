using System;
using System.IO;
using System.Linq;

namespace SubhamAndBinaryStrings
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("Console.txt"));
            var T = Int32.Parse(Console.ReadLine());

            for (int t = 0; t < T; t++)
            {
                var N = Int32.Parse(Console.ReadLine());
                var s = Console.ReadLine();
                var zeros = s.Count(x => x == '0');
                Console.WriteLine(zeros);
            }
            Console.ReadKey();
        }
    }
}