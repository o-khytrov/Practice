using System;
using System.IO;

namespace LetUsUnderstandComputer
{
    internal class Program
    {

        private static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("Console.txt"));

            var T = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < T; i++)
            {
                var X = long.Parse(Console.ReadLine());
                var XBin = Convert.ToString(X, 2);
                long counter = 0;
                if (X == 0)
                {
                    Console.WriteLine("0");
                    continue;
                }
                else if (X == 1)
                {
                    Console.WriteLine("1");
                    continue;
                }
                var b = Math.Log(X, 2);
                if (b % 2 == 0)
                {
                    Console.WriteLine(X - (long)(Math.Pow(2, b / 2) + 1));
                }
                else
                {
                    var c = Math.Ceiling(b / 2);
                    var n = (long)(X / Math.Pow(2, c));
                    Console.WriteLine(X - n);
                }
              
            }
            Console.ReadKey();
        }
    }
}