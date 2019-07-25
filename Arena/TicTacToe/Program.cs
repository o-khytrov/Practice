using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TicTacToe
{
    internal class Program
    {
        private const int MOD = 1000000007;
        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            int mod = 1000000007;
            var T = Int32.Parse(Console.ReadLine().Trim());
            for (int t = 0; t < T; t++)
            {
               
                var n = long.Parse(Console.ReadLine().Trim());
                
                if (n == 1)
                {
                    Console.WriteLine("1 1/n");
                }
                else if (n == 0)
                {
                    Console.WriteLine("0 0\n");
                }
                else
                {
                    var m1 = (((((((n % mod) * ((n - 1) % mod)) % mod) * (n - 1) % mod)) % mod) * (250000002 % mod)) % mod;
                    var m = (((((((n % mod) * ((n - 1) % mod)) % mod) * (2 * n - 1) % mod)) % mod) * (166666668 % mod)) % mod;
                    Console.WriteLine($"{m1} {m}");
                }

            }
            Console.ReadKey();
        }
    }
}