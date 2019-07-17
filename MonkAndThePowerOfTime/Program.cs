using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MonkAndThePowerOfTime
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var N = Int32.Parse(Console.ReadLine().Trim());

            var Order = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
            var queue = new Queue<int>();
            for (int i = 0; i < N; i++)
            {
                queue.Enqueue(Order[i]);
            }

            var IdealOrder = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();

            int counter = 0;
            int step = 0;
            while (queue.Any())
            {
                var p = queue.Dequeue();
                if (p != IdealOrder[step])
                {
                    queue.Enqueue(p);
                }
                else
                {
                    step++;
                }
                counter++;
            }
            Console.WriteLine(counter);
            Console.ReadKey();
        }
    }
}