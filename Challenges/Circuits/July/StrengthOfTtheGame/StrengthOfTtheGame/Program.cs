using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StrengthOfTtheGame
{
    internal class Program
    {
        public static int counter { get; set; }
        private const int MOD = 1000000007;
        private static Dictionary<int, int> dict = new Dictionary<int, int>();

        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var A = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();

            var N = A[0];// Number of players
            var M = A[1];//  Number of parameters
            var P = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
            var strength = P.Strength();
            // Find maximum element in arr[]
            int max_ele = P[0];
            for (int i = 1; i < P.Length; i++)
                if (P[i] > max_ele)
                    max_ele = P[i];
            // Maximum possible XOR value
            int m = (1 << (int)(Math.Log(max_ele, 2) + 1)) - 1;

            for (int i = 0; i <= m; i++)
            {
                dict.Add(i, 0);
            }

            Compute(P, 0);
            ComputeStack(P);
            var counts = new List<int>();

            for (int i = 0; i <= M; i++)
            {
                var count = 0;

                if (dict.ContainsKey(i))
                {
                    count = dict[i];
                }

                counts.Add(count % MOD);
            }
            Console.WriteLine(counter);
            Console.WriteLine(string.Join(" ", counts));
            Console.ReadKey();
        }

        private static void ComputeStack(int[] array)
        {
            int index = 0;
            var stack = new Stack<int[]>();
            stack.Push(array);

            while (stack.Any())
            {
                var arr = stack.Pop();

                for (int i = 0; i < array[index]; i++)
                {
                    var clone = (int[])array.Clone();
                    clone[index] = i;
                    stack.Push(clone);
                }

                index++;
            }


        }
        private static void Compute(int[] array, int ind)
        {
            counter++;
            if (ind > array.Length - 1)
            {
                return;
            }
            for (int i = 0; i <= array[ind]; i++)
            {
                var clone = (int[])array.Clone();
                clone[ind] = i;

                if (ind == array.Length - 1)
                {
                    dict[clone.Strength()]++;
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