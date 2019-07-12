using System;
using System.IO;
using System.Linq;

namespace BestIndex
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("Console.txt"));

            var N = Int32.Parse(Console.ReadLine());
            var strArr = Console.ReadLine().Split(' ');
            var A = strArr.Where(x => !string.IsNullOrWhiteSpace(x)).Select(long.Parse).ToArray();
            for (int i = 0; i < A.Length; i++)
            {
                var x = (N - i) % 3;
                for (int j = i + 1; j < N - x; j++)
                {
                    A[i] += A[j];
                }
            }

            long bestIndex = 0;
            for (int i = 1; i < A.Length; i++)
            {
                long sum = A[i];

                if (sum > bestIndex)
                {
                    bestIndex = sum;
                }
            }
            Console.WriteLine(bestIndex);
            Console.ReadKey();
        }
    }
}