using System;
using System.IO;
using System.Linq;

namespace MaximizingExpressions
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
            var C = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
            int sum = 0;

            for (int i = 0; i < N; i++)
            {
                int local = 0;
                Console.WriteLine(C[i]);
                for (int D = 1; D <= C[i]; D++)
                {
                    Console.WriteLine(new string(' ', 5) + D);
                    if ((C[i] & D) == D)
                    {
                        var b = (A[i] ^ (B[i] ^ D));
                        Console.WriteLine(new string(' ', 5) + D + " " + b);
                        if (local < b)
                        {
                            local = b;
                            Console.WriteLine(new string(' ', 10) + D + " " + b);
                        }
                    }
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(new string(' ', 10) + local);
                Console.ResetColor();

                sum += local;
            }
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}