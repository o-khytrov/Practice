using System;
using System.IO;
using System.Linq;

namespace PlayWithNumbers
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("Console.txt"));

            var A = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            var N = A[0];
            var Q = A[1];
            var a = new long[N];
            A = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();

            var sums = new long[A.Length];
            sums[0] = A[0];
            for (int i = 1; i < A.Length; i++)
            {
                sums[i] = A[i] + sums[i - 1];
            }
            for (int i = 0; i < Q; i++)
            {
                var ar2 = Console.ReadLine().Split(' ').Select(Int32.Parse).ToArray();
                var l = ar2[0];
                var r = ar2[1];

                var length = r - l + 1;
                var index = l - 2;
                if (index < 0)
                {
                    index = 0;
                }
                var sum = sums[r - 1] - sums[index];
                var result = (int)((sum / length));
                Console.WriteLine(result);
            }
            Console.ReadKey();
        }
    }
}