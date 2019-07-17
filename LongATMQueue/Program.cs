using System;
using System.IO;
using System.Linq;

namespace LongATMQueue
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var N = Int32.Parse(Console.ReadLine().Trim());

            var A = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
            int couter = 1;
            for (int i = 0; i < A.Length; i++)
            {
                if (i > 0)
                {
                    if (A[i] < A[i - 1])
                    {
                        couter++;
                    }
                }
            }
            Console.WriteLine(couter);
            Console.ReadKey();
        }
    }
}