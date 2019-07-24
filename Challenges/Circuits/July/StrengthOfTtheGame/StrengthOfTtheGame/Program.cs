using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StrengthOfTtheGame
{
    internal class Program
    {
        public static List<int[]> Combinations { get; set; }
        public static int Counter { get; set; }
        public static List<int> Results { get; set; }

        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            Combinations = new List<int[]>();

            var A = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();

            var N = A[0]; // Number of players
            var M = A[1];//  Number of parameters

            var P = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();

            Results = new List<int>();
            Results.Add(P.Strength());

            Combinations.Add(P);

            Compute(P, 0);
            var dict = Results.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            var counts = new List<int>();

            for (int i = 0; i <= M; i++)
            {
                var count = 0;
                if (dict.ContainsKey(i))
                {
                    count = dict[i];
                }

                counts.Add(count);
            }
            Console.WriteLine(string.Join(" ", counts));
            Console.ReadKey();
        }

        private static void Compute(int[] array, int ind)
        {
            if (ind > array.Length - 1)
            {
                return;
            }
            for (int i = 0; i <= array[ind]; i++)
            {
                var clone = (int[])array.Clone();
                clone[ind] = i;

                if (!clone.SequenceEqual(array))
                {
                    // Combinations.Add(clone);
                    Results.Add(clone.Strength());
                }
                Compute(clone, ind + 1);
            }
        }
    }
}

public static class Extensions
{
    public static int Strength(this int[] array)
    {
        int strength = 0;
        for (int i = 0; i < array.Length - 1; i++)
        {
            strength = array[i] ^ array[i + 1];
        }
        return strength;
    }

    public static long Power(this int[] array)
    {
        long power = array[0];
        for (int i = 0; i < array.Length - 1; i++)
        {
            power = power * array[i + 1];
        }
        return power;
    }
}