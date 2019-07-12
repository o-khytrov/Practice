using System;
using System.Collections.Generic;
using System.IO;

namespace SevenSegmentDisplay
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var d = new Dictionary<int, int>
            {
                { 0,6},
                { 1,2},
                { 2,5},
                { 3,5},
                { 4,4},
                { 5,5},
                { 6,6},
                { 7,3},
                { 8,7},
                { 9,6},
            };
            Console.SetIn(new StreamReader("Console.txt"));
            var T = Int32.Parse(Console.ReadLine());
            for (int t = 0; t < T; t++)
            {
                var line = Console.ReadLine();
                var s = 0;
                foreach (var c in line)
                {
                    var n = Int32.Parse(c.ToString());
                    s += d[n];
                }
                var ones = s / 2;

                var a = new int[ones];
                a.Fill(1);
                if (s % 2 != 0)
                {
                    a[0] = 7;
                }
                Console.WriteLine(string.Join("", a));
            }
            Console.ReadKey();
        }
    }

    public static class ArrayExtensions
    {
        public static void Fill<T>(this T[] originalArray, T with)
        {
            for (int i = 0; i < originalArray.Length; i++)
            {
                originalArray[i] = with;
            }
        }
    }
}