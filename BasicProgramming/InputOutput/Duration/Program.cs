using System;
using System.IO;
using System.Linq;

namespace Duration
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("Console.txt"));
            var N = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                var A = Console.ReadLine().Split(' ').Select(Int32.Parse).ToArray();
                DateTime start = new DateTime(1, 1, 1, A[0], A[1], 0);
                DateTime end = new DateTime(1, 1, 1, A[2], A[3], 0);
                var span = end - start;
                Console.WriteLine($"{span.Hours} {span.Minutes}");
            }
            Console.ReadKey();
        }
    }
}