using System;
using System.IO;
using System.Linq;

namespace NewYearChaos
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
                var n = Int32.Parse(Console.ReadLine().Trim());
                var q = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
                var bribes = 0;
                var toChaotic = false;
                for (int i = 0; i < q.Length; i++)
                {
                    var place = i + 1;

                    if (q[i] != place)
                    {
                        var dif = q[i] - place;
                        if (dif > 2)
                        {
                            toChaotic = true;
                            break;
                        }
                        bribes += dif;
                    }
                }
                if (toChaotic)
                {
                    Console.WriteLine("Too chaotic");
                }
                else
                {
                    Console.WriteLine(bribes);
                }
            }

            Console.ReadKey();
        }
    }
}