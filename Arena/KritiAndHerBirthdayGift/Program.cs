using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KritiAndHerBirthdayGift
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var N = Int32.Parse(Console.ReadLine().Trim());
            var strings = new string[N];
            var table = new Dictionary<string, List<int>>();
            for (int i = 0; i < N; i++)
            {
                var s = Console.ReadLine();
                strings[i] = s;
                if (table.ContainsKey(s))
                {
                    table[s].Add(i);
                }
                else
                {
                    table.Add(s, new List<int> { i });
                }
            }

            var Q = Int32.Parse(Console.ReadLine().Trim());

            for (int q = 0; q < Q; q++)
            {
                var A = Console.ReadLine().Trim().Split(' ').ToArray();
                var i = Int32.Parse(A[0]) - 1;
                var r = Int32.Parse(A[1]);
                var s = A[2];
                int counter = 0;
                if (table.ContainsKey(s))
                {
                    var kvp = table[s];
                    counter = kvp.Count(x => x >= i && x < r);
                }
             
                Console.WriteLine(counter);
            }
            Console.ReadKey();
        }
    }
}