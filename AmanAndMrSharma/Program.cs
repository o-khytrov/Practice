using System;
using System.IO;
using System.Linq;

namespace AmanAndMrSharma
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("Console.txt"));

            var D = Int32.Parse(Console.ReadLine());
            var t = 0;
            for (int d = 0; d < D; d++)
            {
                var A = Console.ReadLine().Split(' ').Select(Int32.Parse).ToArray();
                var r = A[0];
                var x = A[1];
                var distance = x * 100;
                var circleLength = 2 * 22 * r / 7;
                var dif = distance - circleLength;
                if (dif > 1)
                {
                    t++;
                }
            }
            Console.WriteLine(t);
            Console.ReadKey();
        }
    }
}