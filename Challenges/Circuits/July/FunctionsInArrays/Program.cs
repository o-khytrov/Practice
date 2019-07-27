using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace FunctionsInArrays
{
    internal class Program
    {
        public static long Mod = 1000000007;

        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var A = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();

            var N = A[0];
            var M = A[1]; // Количество других массивов
            var K = (int)A[2];

            A = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();

            var results = new long[M];
            for (int z = 0; z < M; z++)
            {
                var B = new long[N];
                for (int j = 0; j < N; j++)
                {
                    var pow = (BigInteger)(A[j]);
                    var l = (BigInteger.Pow(pow, z + 1)) % Mod;
                    B[j] = (long)(l);
                }

                var fArrays = new List<long[]>();
                fArrays.Add((long[])B.Clone());

                for (int i = 1; i < K + 1; i++)
                {
                    var fArray = new long[B.Length];
                    fArray[0] = B[0];
                    for (long q = 1; q < fArray.Length; q++)
                    {
                        fArray[q] = (fArray[q - 1] % Mod + fArrays[i - 1][q] % Mod) % Mod;
                    }

                    fArrays.Add(fArray);
                }
                results[z] = fArrays[K][N - 1] % Mod;
            }

            Console.WriteLine(string.Join(" ", results));
            Console.ReadKey();
        }
    }
}