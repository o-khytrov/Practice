using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GCDproblem
{
    internal class Program
    {
        static int GCD(int[] numbers)
        {
            return numbers.Aggregate(GCD);
        }

        static int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));


            var A = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
            var N = A[0];
            var M = A[1];

            A = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
            for (int i = 0; i < M; i++)
            {

                var Q = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
                var L = Q[0] - 1;
                var R = Q[1] - 1;
                long gcd = 0;
                for (int l = L; l <= R; l++)
                {
                    for (int r = L; r <= R; r++)
                    {
                        Console.WriteLine(string.Join(" ", A.Skip(l).Take(r).ToArray()));
                    }
                }

            }

            Console.ReadKey();
        }
    }
}