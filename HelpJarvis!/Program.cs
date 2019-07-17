using System;
using System.IO;
using System.Linq;

namespace HelpJarvis_
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var T = Int32.Parse(Console.ReadLine().Trim());
            for (int t = 0; t < T; t++)
            {
                var A = Console.ReadLine().ToCharArray().Select(x => Int32.Parse(x.ToString())).OrderBy(x => x).ToArray();
                var valid = true;
                for (int i = 0; i < A.Length - 1; i++)
                {
                    if (A[i] + 1 != A[i + 1])
                    {
                        valid = false;
                        break;
                    }
                }
                var message = valid ? "YES" : "NO";
                Console.WriteLine(message);
            }

            Console.ReadKey();
        }
    }
}