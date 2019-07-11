using System;
using System.IO;

namespace Factorial
{
    internal class Program
    {
        private static int Factorial(int n)
        {
            var factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }
            return factorial;
        }

        private static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("Console.txt"));
            var N = Int32.Parse(Console.ReadLine());
            Console.WriteLine(Factorial(N));
            Console.ReadKey();
        }
    }
}