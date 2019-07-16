using System;
using System.IO;
using System.Linq;

namespace BinaryQueries
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("Console.txt"));

            var A = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
            var N = A[0];
            var Q = A[1];

            A = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
            for (int q = 0; q < Q; q++)
            {
                var qar = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
                if (qar[0] == 0)
                {
                    var val = A[qar[2] - 1];
                    if (val == 1)
                    {
                        Console.WriteLine("ODD");
                    }
                    else
                    {
                        Console.WriteLine("EVEN");
                    }
                }
                else if (qar[0] == 1) // flip bit
                {
                    var bit = qar[1] - 1;
                    A[bit] = A[bit] == 1 ? 0 : 1;
                }
            }
            Console.ReadKey();
        }
    }
}