using System;
using System.IO;
using System.Linq;

namespace GeneratingSequence
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var T = Int64.Parse(Console.ReadLine().Trim());

            for (long t = 0; t < T; t++)
            {
                var A = Console.ReadLine().Trim().Split(' ').Select(Int64.Parse).ToArray();
                var g = A[0];
                var n = A[1];

                var seq = new long[n];
                var dcd = g;
                var val = g *2;
                while (true)
                {
                    if (val % g == 0)
                    {
                        for (long i = 0; i < seq.Length - 1; i++)
                        {
                            seq[i] = val;
                        }
                        break;
                    }
                    val++;
                }
                seq[seq.Length - 1] = seq[seq.Length - 2] + g;

                Console.WriteLine(string.Join(" ", seq));
            }

            Console.ReadKey();
        }
    }
}