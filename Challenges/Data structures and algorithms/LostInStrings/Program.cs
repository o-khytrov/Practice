using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LostInStrings
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.SetIn(new StreamReader(@"Console.txt"));
            var T = Int32.Parse(Console.ReadLine());
            for (int t = 0; t < T; t++)
            {
                var s1 = Console.ReadLine();
                var s = new string(s1.ToCharArray().Reverse());
                for (int i = 0; i < s1.Length; i++)
                {
                    s1[i] += s[i];
                }
                Console.WriteLine(s);

            }
            Console.ReadKey();
        }
    }
}