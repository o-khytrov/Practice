using System;
using System.IO;

namespace SmallestPositiveInteger
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var X = Int32.Parse(Console.ReadLine().Trim());
            var res = 0;

            for (int i = X + 1; i < 1000000006; i++)
            {
                var product = 1;
                var source = i;
                while (source > 0)
                {
                    var digit = source % 10;
                    source /= 10;
                    product = product * digit;
                }

                if (product % 1000000007 == X)
                {
                    res = i;
                    break;
                }
            }
            Console.WriteLine(res);

            Console.ReadKey();
        }
    }
}