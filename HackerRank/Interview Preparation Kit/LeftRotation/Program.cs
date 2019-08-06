using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LeftRotation
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var A = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
            var n = A[0];
            var d = A[1];

            A = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
            var q = new Queue<int>();
            for (int i = 0; i < A.Length; i++)
                q.Enqueue(A[i]);
            for (int i = 0; i < d; i++)
            {
                var e = q.Dequeue();
                q.Enqueue(e);
            }
            Console.WriteLine(string.Join(" ", q));
            Console.ReadKey();
        }
    }
}