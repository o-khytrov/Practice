using System;
using System.IO;
using System.Linq;

namespace CharSum
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("Console.txt"));
            var s = Console.ReadLine();
            var sum = s.ToCharArray().Sum(x => x - 96);
            Console.WriteLine(sum);
        }
    }
}