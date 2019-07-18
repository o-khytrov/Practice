using System;
using System.IO;
using System.Linq;

namespace PepperAndContiguousEvenSubarray
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
                var N = Int32.Parse(Console.ReadLine().Trim());

                var A = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();

                int max = 0;
                int couter = 0;
                for (int i = 0; i < A.Length; i++)
                {
                    if (A[i] % 2 == 0)
                    {
                        couter++;
                    }
                    else
                    {
                        if (max < couter)
                        {
                            max = couter;
                        }
                        couter = 0;
                    }
                    if (max < couter)
                    {
                        max = couter;
                    }
                }
                if (max==0)
                {
                    max = -1;
                }
                Console.WriteLine(max);
            }
            Console.ReadKey();
        }
    }
}