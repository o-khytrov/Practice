using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SockMerchant
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
            Console.WriteLine(A.GroupBy(x => x).Where(g => g.Count() > 1).Sum(x => x.Count() / 2));


            Console.ReadKey();
        }
    }
}