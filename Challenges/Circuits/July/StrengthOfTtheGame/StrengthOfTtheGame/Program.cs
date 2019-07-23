using System;
using System.IO;
using System.Linq;

namespace StrengthOfTtheGame
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var A = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
            var N = A[0]; // Number of players

            var M = A[1];//  Number of parameters

            var P = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
            var results = new int[N];
            var strenght = P.Strength();
            for (int i = 0; i < M; i++)
            {
                int count = 0;
                results[i] = count;
            }
            Console.WriteLine(string.Join(" ", results));
            Console.ReadKey();
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
    }
}