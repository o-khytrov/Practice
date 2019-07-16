using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MemorizeMe
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("Console.txt"));

            var N = Int32.Parse(Console.ReadLine());
            var dict = new Dictionary<int, int>();
            var A = Console.ReadLine().Split(' ').Select(Int32.Parse).ToArray();

            var Q = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < A.Length; i++)
            {
                var num = A[i];
                if (dict.ContainsKey(num))
                {
                    dict[num]++;
                }
                else
                {
                    dict.Add(num, 1);
                }
            }

            for (int q = 0; q < Q; q++)
            {
                var n = Int32.Parse(Console.ReadLine());
                var present = dict.TryGetValue(n, out var count);
                if (!present)
                {
                    Console.WriteLine("NOT PRESENT");
                }
                else
                {
                    Console.WriteLine(count);
                }
            }
            Console.ReadKey();
        }
    }
}