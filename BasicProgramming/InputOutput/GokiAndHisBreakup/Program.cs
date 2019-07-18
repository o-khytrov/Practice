using System;
using System.IO;

namespace GokiAndHisBreakup
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("Console.txt"));

            var N = Int32.Parse(Console.ReadLine());
            var X = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                var y = Int32.Parse(Console.ReadLine());
                if (y >= X)
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