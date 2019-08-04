using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sequences
{
    internal class Program
    {
        public static bool IsInF(long n, long a, long b)
        {
            var Fib = new List<long>();
            Fib.Add(a);
            Fib.Add(b);
            int i = 2;
            while (Fib.Last() < n)
            {
                var next = Fib[i - 2] + Fib[i - 1];
                if (next == n)
                {
                    return true;
                }
                Fib.Add(next);
                i++;
            }
            return false;
        }

        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var A = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var a = A[0];
            var b = A[1];

            var Q = long.Parse(Console.ReadLine().Trim());
            var p = $"{a} {b}${Q}";
            for (int q = 0; q < Q; q++)
            {
                var x = long.Parse(Console.ReadLine().Trim());

                p = p + $"${x}";
            }
            throw new Exception(p);
            Console.ReadKey();
        }
    }
}