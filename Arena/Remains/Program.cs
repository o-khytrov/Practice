using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Remains
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

                var A = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
                var h1 = A[0]; // height of the first building
                var h2 = A[1]; // height of the second building
                var n = A[2]; // number of buildings




                var count = 2;
                long sum = h1 + h2;
                while (count < n)
                {

                    var p2 = h2;
                    var p1 = h1;

                    var next = (Math.Max(p2, p1) - Math.Min(p1, p2));
                    h1 = h2;
                    h2 = next;
                    sum += next;
                    count++;
                }
                Console.WriteLine(sum);
            }

            Console.ReadKey();
        }
    }
}