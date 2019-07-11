using System;
using System.IO;
using System.Linq;

namespace CountDivisors
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("Console.txt"));

            var A = Console.ReadLine().Split(' ').Select(Int32.Parse).ToArray();
            var l = A[0];
            var r = A[1];
            var k = A[2];
            int count = 0;
            for (int i = l; i <= r; i++)
            {
                if (i % k == 0)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
            Console.ReadKey();
        }
    }
}