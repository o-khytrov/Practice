using System;
using System.IO;

namespace HelpYourRoommate
{
    internal class Program
    {
        private static bool isPowerOfTwo(int n)
        {
            if (n == 0)
                return false;

            return (int)(Math.Ceiling((Math.Log(n) / Math.Log(2)))) ==
                   (int)(Math.Floor(((Math.Log(n) / Math.Log(2)))));
        }

        private static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("Console.txt"));

            var T = Int32.Parse(Console.ReadLine());
            for (int t = 0; t < T; t++)
            {
                var counter = 1;
                var N = Int32.Parse(Console.ReadLine());
                if (!isPowerOfTwo(N))
                {
                    var log = (int)Math.Floor(Math.Log(N, 2));
                    counter += (N - (int)Math.Pow(2, log));
                }
                Console.WriteLine(counter);
            }
            Console.ReadKey();
        }
    }
}