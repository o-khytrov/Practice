using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HamiltonianAndLagrangian
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var N = Int32.Parse(Console.ReadLine().Trim());

            var A = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();

            var r = new List<int>();
            for (int i = 0; i < A.Length; i++)
            {
                var right = i < A.Length-1 ? A[i + 1] : 0;
                if (A[i] > right)
                {
                    r.Add(A[i]);
                }

            }
            Console.WriteLine(string.Join(" ", r));
            Console.ReadKey();
        }
    }
}