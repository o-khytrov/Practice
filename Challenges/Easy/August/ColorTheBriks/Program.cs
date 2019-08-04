using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ColorTheBriks
{
    public class Brik
    {
        public int number;
        public bool Colored;
        public bool Disconnected;
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var A = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
            int N = A[0];
            int K = A[1];
            var dict = new Dictionary<int, bool>();

            var colored = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
            var bricks = new List<Brik>();
            for (int i = 1; i <= N; i++)
            {
                var Brik = new Brik { number = i, Colored = colored.Contains(i) };
                Brik.Disconnected = !Brik.Colored && !colored.Contains(i + 1) && !colored.Contains(i - 1);
                bricks.Add(Brik);
            }
            var disconnected = bricks.Count(x => x.Disconnected);
            var uncolored = N - K;
            var forbidden = 0;
            if (disconnected > 0)
            {
                forbidden = Factorial(uncolored - disconnected) % 100000007;
            }

            var comb = Factorial(uncolored) % 100000007;
            var ans = comb - forbidden;
            Console.WriteLine(ans);
            Console.ReadKey();
        }

        private static int Factorial(int n)
        {
            var factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}