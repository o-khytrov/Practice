using System;
using System.IO;
using System.Linq;

namespace MaximizeTheEarning
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var S = Int32.Parse(Console.ReadLine().Trim()); // number o streets
            for (int i = 0; i < S; i++)
            {
                var A = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
                var N = A[0];// number of buildings
                var R = A[1];// earning
                A = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
                int couter = R;
                var max = A[0];
                for (int b = 1; b < A.Length; b++)
                {
                    if (A[b] > max)
                    {
                        max = A[b];
                        couter += R;
                    }
                }
                Console.WriteLine(couter);
            }

            Console.ReadKey();
        }
    }
}