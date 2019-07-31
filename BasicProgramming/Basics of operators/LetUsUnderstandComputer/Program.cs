using System;
using System.IO;

namespace LetUsUnderstandComputer
{
    internal class Program
    {
        static int countSetBits(long n)
        {
            int count = 0;
            while (n > 0)
            {
                n = n &= (n - 1);
                count++;
            }

            return count;
        }
        private static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("Console.txt"));

            var T = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < T; i++)
            {
                var X = long.Parse(Console.ReadLine());
                var XBin = Convert.ToString(X, 2);
                long counter = 0;
                for (int d = 1; d <= X; d++)
                {
                    var r = X / d;
                    var bin = countSetBits(d);
                    var rbin = countSetBits(r);

                    if (!(rbin > bin))
                    {
                        counter++;
                    }
                }
                Console.WriteLine(counter);
            }
            Console.ReadKey();
        }
    }
}