using System;
using System.IO;
using System.Linq;

namespace Anagrams
{
    internal struct Letter
    {
        public char C { get; set; }
        public int Count { get; set; }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.SetIn(new StreamReader(@"D:\Console.txt"));
            var T = Int32.Parse(Console.ReadLine());
            for (int t = 0; t < T; t++)
            {
                var s1 = Console.ReadLine();
                var s2 = Console.ReadLine();
                var temp = s1;
                if (s2.Length > s1.Length)
                {
                    s1 = s2;
                    s2 = temp;
                }
                int count = 0;
                var common = s1.Intersect(s2).ToArray();

                var t2 = new string(s2.Where(x => common.Contains(x)).ToArray());
                var t1 = new string(s1.Where(x => common.Contains(x)).ToArray());

                count += s2.Length - t2.Length;
                count += s1.Length - t1.Length;
                s2 = t2;
                s1 = t1;
                var d1 = s1.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
                var d2 = s2.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
                foreach (var kvp in d1)
                {
                    count += Math.Abs(kvp.Value - d2[kvp.Key]);
                }
                Console.WriteLine(count);
                Console.ReadKey();
            }
        }
    }
}