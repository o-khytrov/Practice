using System;
using System.IO;
using System.Linq;

namespace CountWaysToAssignUniqueCapToEveryPperson
{
    internal class Program
    {
        private static int allmask = 0;
        private const int Mod = 1000000007;

        // array
        private static int[][] caplist = new int[101][];

        private static int[][] dp = new int[1025][];

        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));


            var n = Int32.Parse(Console.ReadLine().Trim());
            CountWays(n);
            Console.ReadKey();
        }

        private static long CountWaysUntil(int mask, int i)
        {
            if (mask == allmask) return 1;

            if (i > 100) return 0;
            if (dp[mask][i] != -1) return dp[mask][i];

            long ways = CountWaysUntil(mask, i + 1);
            var size = caplist.Count(x => x == i);
            for (int j = 0; j < size; j++)
            {
                //we cannot assign him this cap
                  if (mask & (1 << caplist[i][j])) continue;

                // Else assign him this cap and recur for remaining caps with 
                // new updated mask vector 
                else ways += CountWaysUntil(mask | (1 << caplist[i][j]), i + 1);
                ways %= Mod;
            }
            // Save the result and return it. 
            return dp[mask][i] = ways;
        }

        private static void CountWays(int n)
        {
            for (int i = 0; i < n; i++)
            {
                var x = Int32.Parse(Console.ReadLine().Trim());
                caplist[x] = i;
            }
            // set all n bits as 1
            allmask = (1 << n) - 1;
            // initialize all entries in dp as -1
            for (int i = 0; i < dp.Length; i++)
            {
                for (int j = 0; j < dp[i].Length; j++)
                {
                    dp[i][j] = -1;
                }
            }
            Console.WriteLine(CountWaysUntil(0, 1));

        }
    }
}