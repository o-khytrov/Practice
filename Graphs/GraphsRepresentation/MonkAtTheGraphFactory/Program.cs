using System;
using System.IO;
using System.Linq;

namespace MonkAtTheGraphFactory
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var n = Int32.Parse(Console.ReadLine().Trim());

            var A = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
            var isTree = true;
            var edges = A.Sum(x => x)/2;
            isTree = edges == n - 1;
            var message = isTree ? "Yes" : "No";
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}