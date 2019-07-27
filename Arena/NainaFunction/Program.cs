using System;
using System.IO;
using System.Numerics;

namespace NainaFunction
{
    internal class Program
    {
        private static BigInteger SumOfDigits(BigInteger n)
        {
            BigInteger sum = 0;

            while (n != 0)
            {
                sum = sum + n % 10;
                n = n / 10;
            }

            return sum;
        }

        private static BigInteger Naina(BigInteger n)
        {
            if (n <= 9)
            {
                return n;
            }
            else
            {
                return Naina(SumOfDigits(n));
            }
        }

        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));
            var T = Int32.Parse(Console.ReadLine().Trim());
            for (int t = 0; t < T; t++)
            {
                var n = BigInteger.Parse(Console.ReadLine().Trim());

                var x = BigInteger.Pow(n, 3);
                Console.WriteLine(Naina((BigInteger)x));
            }

            Console.ReadKey();
        }
    }
}