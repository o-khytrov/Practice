using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TheCastleGate
{
    using System;

    internal class Program
    {
        //Tap the gates as many times as there are unordered pairs
        //of distinct integers from 1 to N whose bit-wise XOR does not exceed N
        private static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("Console.txt"));

            var T = Int32.Parse(Console.ReadLine());

            //for (int t = 0; t < T; t++)
            //{
            //    var N = Int32.Parse(Console.ReadLine());
            //    var set = new List<Tuple<int, int>>();
            //    for (int i = 2; i <= N; i++)
            //    {
            //        for (int j = 1; j <= N; j++)
            //        {
            //            if (j != i)
            //            {
            //                if ((i ^ j) < N)
            //                {
            //                    var tup = new Tuple<int, int>(Math.Max(i, j), Math.Min(i, j));
            //                    set.Add(tup);
            //                }
            //            }
            //        }
            //    }
            //    var res = set.Distinct().Count();
            //    Console.WriteLine(res);
            //}
            for (int t = 0; t < T; t++)
            {
                int count = 0;

                int n = int.Parse(Console.ReadLine());
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {
                        if ((i ^ j) <= n && (i ^ 1) >= 1)

                            ++count;
                    }
                }
                Console.WriteLine(count / 2);
            }

            Console.ReadKey();
        }
    }
}