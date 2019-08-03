using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PowerFailure
{
    public static class Extensions
    {
        public static bool IsPrime(this int n)
        {
            var r = true;
            var c = n - 1;
            while (c > 1)
            {
                if (n % c == 0)
                {
                    r = false;
                    break;
                }
                c--;
            }
            return r;
        }
    }
    internal class Program
    {
        static int MOD = 100000007;
        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var T = Int32.Parse(Console.ReadLine().Trim());
            for (int t = 0; t < T; t++)
            {

                var A = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
                var n = A[0]; // His lab has n machines.
                var m = A[1]; // They have one battery of each voltage rating from 1 to M.

                var V = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).OrderByDescending(x => x).ToArray();
                //The ith machine requires a battery with voltage rating of atleast Vi volts

                //He thinks that Mandark has planted bombs in batteries with a prime voltage rating. 
                var combinations = 1;
                for (int i = 0; i < V.Length; i++)
                {

                    int ways = 0;
                    for (int j = V[i]; j <= m; j++)
                    {
                        if (!j.IsPrime())
                        {
                            ways++;
                        }
                    }
                    m = V[i];
                    combinations *= ways;
                }
                Console.WriteLine(combinations);
            }

            Console.ReadKey();
        }
    }
}