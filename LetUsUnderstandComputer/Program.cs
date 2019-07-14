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
                for (int d = 1; d <= X; d++)
                {
                    var r = X / d;
                    var bin = Convert.ToString(d, 2);
                    var rbin = Convert.ToString(r, 2);

                    if (!(rbin.Length > bin.Length))
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