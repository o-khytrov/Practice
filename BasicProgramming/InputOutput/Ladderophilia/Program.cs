using System;
using System.IO;

namespace Ladderophilia
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("Console.txt"));

            var s = Int32.Parse(Console.ReadLine());
            Console.WriteLine("*   *");
            for (int i = 0; i < s; i++)
            {
                Console.WriteLine("*   *");
                Console.WriteLine("*****");
                Console.WriteLine("*   *");
            }
            Console.WriteLine("*   *");
            Console.ReadKey();
        }
    }
}