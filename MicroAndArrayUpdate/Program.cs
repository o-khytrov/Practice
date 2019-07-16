using System;
using System.IO;
using System.Linq;

namespace MicroAndArrayUpdate
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("Console.txt"));

            var T = Int32.Parse(Console.ReadLine().Trim());
            for (int t = 0; t < T; t++)
            {
                var lA = Console.ReadLine().Trim()
                    .Split(' ')
                    .Select(Int32.Parse)
                    .ToArray();

                var N = lA[0];
                var K = lA[1];

                var A = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
                var counter = 0;
                for (int i = 0; i < A.Length; i++)
                {
                    var val = A[i];
                    if (val < K)
                    {
                        var d = K - val;
                        if (d > counter)
                        {
                            counter = d;
                        }
                    }
                }
                Console.WriteLine(counter);
            }
            Console.ReadKey();
        }
    }
}