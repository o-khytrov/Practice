using System;
using System.IO;
using System.Linq;

namespace TwoStrings
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("Console.txt"));

            var T = Int32.Parse(Console.ReadLine());
            for (int t = 0; t < T; t++)
            {
                var A = Console.ReadLine().Split(' ').ToArray();
                var s1 = new string(A[0].OrderBy(x => x).ToArray());
                var s2 = new string(A[1].OrderBy(x => x).ToArray());
                if (s1 == s2)
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");
                }
            }
            Console.ReadKey();
        }
    }
}