using System;
using System.IO;
using System.Linq;

namespace TwoArrays
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

            var B = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
            var aI = 0;
            var bI = 0;
            var aSum = 0;
            var bSum = 0;
            for (int i = 0; i < N; i++)
            {
                var a = A[i];
                var b = B[i];
                if (a == -1)
                {
                    aI++;
                }
                else
                {
                    aSum += a;
                }
                if (b == -1)
                {
                    bI++;
                }
                else
                {
                    bSum += b;
                }
            }

            var x = -1;
            var counter = 0;
            var dif = Math.Abs(aSum - bSum);
            for (int r = 1; r <= dif; r++)
            {
                x = r;
                if (((x * aI) + aSum) == ((x * bI) + bSum))
                {
                    counter++;
                }
                r++;
            }
            Console.WriteLine(counter);
            Console.ReadKey();
        }
    }
}