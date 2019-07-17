using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ChargedUpArray
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

                var subsets = new List<List<int>>();
                for (int i = 0; i < A.Length; i++)
                {
                    subsets.Add(new List<int> { A[i] });
                    var sublist = new List<int> { A[i] };

                    for (int j = i + 1; j < A.Length; j++)
                    {
                        if (i != j)
                        {
                            sublist.Add(A[j]);
                        }
                        subsets.Add(sublist);
                    }
                }

            }

            Console.ReadKey();
        }
    }
}