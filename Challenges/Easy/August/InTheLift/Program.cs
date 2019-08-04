using System;
using System.IO;
using System.Linq;

namespace InTheLift
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
            var k = A[1];

            Console.ReadKey();
        }
    }
}