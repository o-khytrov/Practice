using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CountingValleys
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
            int level = 0;
            var valleys = 0;
            for (int i = 0; i < line.Length; i++)
            {
                var c = line[i];
                if (c == 'U')
                {
                    if (level == -1)
                    {
                        valleys++;
                    }
                    level++;
                }
                else if (c == 'D')
                {

                    level--;
                }

            }
            Console.WriteLine(valleys);

            Console.ReadKey();
        }
    }
}