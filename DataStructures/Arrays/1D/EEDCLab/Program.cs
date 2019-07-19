using System;
using System.IO;
using System.Linq;

namespace EEDCLab
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var N = Int32.Parse(Console.ReadLine().Trim());

            var A = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
            var results = new Boolean[N + 1];
            for (int i = 0; i < A.Length; i++)
            {
                results[i + 1] = A.Check(i);
            }
            var Q = Int32.Parse(Console.ReadLine().Trim());
            for (int q = 0; q < Q; q++)
            {
                var qa = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
                var L = qa[0];
                var R = qa[1];
                var counter = 0;
                for (int i = L; i <= R; i++)
                {
                    if (results[i])
                    {
                        counter++;
                    }
                }
                Console.WriteLine(counter);
            }

            Console.ReadKey();
        }
    }

    public static class Extensions
    {
        public static bool Check(this int[] array, int index)
        {
            var strLeft = string.Join("",
                array.Take(index)
                .Select(x => x.ToString()));

            var strRight = string.Join("",
                array.Skip(index + 1)
                .Select(x => x.ToString()));
            System.Numerics.BigInteger.TryParse(strLeft, out var left);
            System.Numerics.BigInteger.TryParse(strRight, out var right);
            var sum = left + right;

            return (sum % 2 == 0 && sum % 5 == 0 && sum % 3 == 0);
        }
    }
}