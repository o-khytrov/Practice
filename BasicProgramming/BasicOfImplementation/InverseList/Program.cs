using System;
using System.IO;
using System.Linq;

namespace InverseList
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var T = Int32.Parse(Console.ReadLine().Trim());
            for (int t = 0; t < T; t++)
            {
                var N = Int32.Parse(Console.ReadLine().Trim());

                var A = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
                var inv = new int[A.Length];
                bool ans = true;
                for (int i = 0; i < A.Length; i++)
                {
                    var val = A[i];
                    inv[val - 1] = i + 1;
                }
                for (int j = 0; j < A.Length; j++)
                {
                    if (A[j] != inv[j])
                    {
                        ans = false;

                        break;
                    }
                }
                var message = ans ? "inverse" : "not inverse";
                Console.WriteLine(message);
            }
            Console.ReadKey();
        }
    }
}