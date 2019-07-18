using System;
using System.IO;
using System.Linq;

namespace StrangeGame
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
                var K = A[1]; // time required to increase the value of a card

                var Alice = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();

                var Bob = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();

                var maxBob = Bob.Max(x => x);
                long counter = 0;
                for (int i = 0; i < Alice.Length; i++)
                {
                    var val = Alice[i];
                    if (val <= maxBob)
                    {
                        counter += (((maxBob - val) + 1) * K);
                    }
                }
                Console.WriteLine(counter);
            }

            Console.ReadKey();
        }
    }
}