using System;
using System.IO;
using System.Linq;

namespace StrengthOfTtheGame
{
    internal class Program
    {
        private const int MOD = 1000000007;

        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var A = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
            var n = A[0];
            var m = A[1];
            var team = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var val = new long[512];
            for (int i = 0; i <= team[0]; i++)
            {
                val[i] = 1;
            }
            int counter = 0;
            foreach (var player in team)
            {
                counter++;
                if (counter == 1)
                    continue;

                var temp = new long[512];
                for (int i = 0; i <= player; i++)
                {
                    for (int j = 0; j < 512; j++)
                    {
                        if (val[j] > 0)
                        {
                            long xor = j ^ i;
                            temp[xor] = (temp[xor] + val[j]) % MOD;
                        }
                    }
                }
                val = temp;
            }
            long[] final = new long[m + 1];
            for (int i = 0; i <= m; i++)
            {
                final[i] = val[i];
            }
            Console.WriteLine(string.Join(" ", final.Select(x => x.ToString())));
            Console.ReadKey();
        }
    }
}

public static class Extensions
{
    public static int Strength(this int[] array)
    {
        var rep = string.Empty;
        if (array.Length == 1)
        {
            return array[0];
        }
        var xor = array[0] ^ array[1];
        for (int i = 1; i < array.Length - 1; i++)
        {
            xor = xor ^ array[i + 1];
        }

        return xor;
    }
}