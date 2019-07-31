using System;
using System.IO;
using System.Linq;

namespace BestIndex
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));
            var line = Console.ReadLine().Trim();
            var N = long.Parse(line);
            var strArr = Console.ReadLine().Split(' ');
            var A = strArr.Where(x => !string.IsNullOrWhiteSpace(x)).Select(long.Parse).ToArray();
            var prefixSums = new long[A.Length];
            var Sums = new long[A.Length];

            prefixSums[0] = A[0];

            for (int i = 1; i < A.Length; i++)
            {
                prefixSums[i] = prefixSums[i - 1] + A[i];
            }

            long bestIndex = 0;
            for (int i = 0; i < A.Length; i++)
            {
                var rest = A.Length - (i + 1);
                var end = i;

                var mult = 2;
                var offset = 0;
                while (offset <= rest)
                {
                    if (offset + mult > rest)
                    {
                        break;
                    }
                    offset += mult;
                    mult++;
                }
                end = (i + offset);
                var start = i - 1;
                long pref = 0;
                if (start >= 0)
                    pref = prefixSums[start];
                var sum = prefixSums[end] - pref;

                if (bestIndex < sum)
                {
                    bestIndex = sum;
                }
            }
            Console.WriteLine(bestIndex);
            Console.ReadKey();
        }
    }
}