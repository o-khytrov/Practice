using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CostOfBalloons
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("Console.txt"));
            var T = Int32.Parse(Console.ReadLine());
            for (int t = 0; t < T; t++)
            {
                var A = Console.ReadLine().Split(' ').Select(Int32.Parse).ToArray();
                var costGb = A[0]; // cost of green ballons
                var costPb = A[1]; // cost of purple ballons
                var n = Int32.Parse(Console.ReadLine());
                var scores = new Dictionary<int, int[]>(); //number of participants
                for (int i = 0; i < n; i++)
                {
                    var a = Console.ReadLine().Split(' ').Select(Int32.Parse).ToArray();
                    scores.Add(i, a);
                }
                var p1 = scores.Where(x => x.Value[0] == 1).Count(); //
                var p2 = scores.Where(x => x.Value[1] == 1).Count();
                var money = Math.Min(p1 * costGb + p2 * costPb, p2 * costGb + p1 * costPb);
                Console.WriteLine(money);
            }
            Console.ReadKey();
        }
    }
}