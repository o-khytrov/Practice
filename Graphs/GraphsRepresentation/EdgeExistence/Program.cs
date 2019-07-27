using System;
using System.IO;
using System.Linq;

namespace EdgeExistence
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var A = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
            var N = A[0]; // number of nodes
            var E = A[1]; // number of edges
            var matrix = new int[N, N];
            for (int i = 0; i < E; i++)
            {
                A = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
                var a = A[0];
                var b = A[1];
                matrix[a, b] = 1;
                matrix[b, a] = 1;
            }

            var Q = Int32.Parse(Console.ReadLine().Trim());
            for (int i = 0; i < Q; i++)
            {

                var q = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
                var answer = matrix[q[0], q[1]] == 1 ? "YES" : "NO";
                Console.WriteLine(answer);
            }
            Console.ReadKey();
        }
    }
}