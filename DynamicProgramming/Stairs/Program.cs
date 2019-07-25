using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Stairs
{
    internal class Program
    {
        public static Dictionary<int, int> Memorization;
        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var T = Int32.Parse(Console.ReadLine().Trim());
            for (int t = 0; t < T; t++)
            {
                Memorization = new Dictionary<int, int>();
                var A = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
                var n = A[0];
                var k = A[1];

                var number = Compute(n, k);
                Console.WriteLine(number);
            }
            Console.ReadKey();
        }

        private static int Compute(int number, int k)
        {
            int count = 0;
            if (number == 0)
            {
                return 1;
            }
            if (number < 0)
            {
                return 0;
            }
            if (Memorization.ContainsKey(number))
            {
                return Memorization[number];
            }
            for (int i = 1; i <= k; i++)
            {
                count += Compute(number - i, k);
            }
            Memorization.Add(number, count);
            return count;
        }
    }
}