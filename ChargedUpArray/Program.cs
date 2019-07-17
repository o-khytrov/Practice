using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ChargedUpArray
{
    internal class Program
    {
        private static List<List<Int64>> GetSubsets(Int64[] source)
        {
            var dict = source.ToDictionary(x => x, x => 0);

            var length = (Int64)Math.Pow(2, source.Length);
            var result = new List<List<Int64>>();

            for (int i = 0; i < length; i++)
            {
                var combination = new List<Int64>();
                for (int j = 0; j < source.Length; j++)
                {
                    if ((i & (1 << (source.Length - j - 1))) != 0)
                    {
                        combination.Add(source[j]);
                        dict[source[j]]++;
                    }
                }
                result.Add(combination);
            }

            return result;
        }

        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var T = Int64.Parse(Console.ReadLine().Trim());

            for (int t = 0; t < T; t++)
            {
                var N = Int64.Parse(Console.ReadLine().Trim());

                var A = Console.ReadLine().Trim().Split(' ').Select(Int64.Parse).ToArray();
                Int64 counter = 0;
                var dict = A.Distinct().ToDictionary(x => x, x => 0);

                var length = (Int64)Math.Pow(2, A.Length);
                var result = new List<List<Int64>>();

                for (int i = 0; i < length; i++)
                {
                    var combination = new List<Int64>();
                    for (int j = 0; j < A.Length; j++)
                    {
                        if ((i & (1 << (A.Length - j - 1))) != 0)
                        {
                            combination.Add(A[j]);
                            dict[A[j]]++;
                        }
                    }
                    result.Add(combination);
                }
                for (int i = 0; i < A.Length; i++)
                {
                    var el = A[i];
                    var count = dict[el];
                    if (el >= count)
                    {
                        counter += el;
                    }
                }
                Console.WriteLine(counter);
            }

            Console.ReadKey();
        }
    }
}