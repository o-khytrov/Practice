using System;
using System.IO;
using System.Linq;

namespace TheBlessing
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("Console.txt"));

            var T = Int32.Parse(Console.ReadLine());
            for (int t = 0; t < T; t++)
            {
                var A = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
                var U = A[0]; 
                var M = A[1]; 
                Console.WriteLine(2 * (A[0] + A[1]));
            }
            Console.ReadKey();
        }
    }
}