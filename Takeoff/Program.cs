using System;
using System.IO;
using System.Linq;

namespace Takeoff
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
                var N = A[0];

                var p = A[1];
                var q = A[2];
                var r = A[3];

                int couneter = 0;
                for (int i = 1; i <= N; i++)
                {
                    var flights = 0;
                    if (i % p == 0)
                        flights++;
                    if (i % q == 0)
                        flights++;
                    if (i % r == 0)
                        flights++;

                    if (flights == 1)
                        couneter++;
                }
                Console.WriteLine(couneter);
            }

            Console.ReadKey();
        }
    }
}