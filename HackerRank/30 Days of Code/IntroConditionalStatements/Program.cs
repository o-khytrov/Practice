using System;
using System.IO;

namespace IntroConditionalStatements
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var n = Int32.Parse(Console.ReadLine().Trim());

            bool Weird = false;

            if (n.IsOdd())
            {
                Weird = true;
            }
            else
            if (6 <= n && n <= 20)
            {
                Weird = true;
            }

            var message = Weird ? "Weird" : "Not Weird";
            Console.WriteLine(message);

            Console.ReadKey();
        }
    }

    public static class Extensions
    {
        public static bool IsOdd(this int n)
        {
            return n % 2 != 0;
        }
    }
}