using System;
using System.IO;

namespace SplitHouses
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var N = Int32.Parse(Console.ReadLine().Trim());

            var line = Console.ReadLine();
             //if (line.Contains(".") && !line.EndsWith(".") && !line.StartsWith("."))
            if (line.Contains("H") && line.Contains(".") )
            {
                if (!line.Contains("HH"))
                {
                    Console.WriteLine("YES");
                    Console.WriteLine(line.Replace(".", "B"));
                }
                else
                {
                    Console.WriteLine("NO");
                }
              
            }
            else if (!line.Contains("H") && line.Contains("."))
            {
                Console.WriteLine("YES");
                Console.WriteLine(line.Replace(".", "B"));
            }
            else if (line=="H")
            {
                Console.WriteLine("YES");
                Console.WriteLine(line);
            }
            else
            {
                Console.WriteLine("NO");
            }

            Console.ReadKey();
        }
    }
}