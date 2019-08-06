using System;
using System.IO;
using System.Linq;

namespace _2DArrays
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var matrix = new int[6, 6];
            for (int i = 0; i < 6; i++)
            {
                var a = Console.ReadLine().Trim().Split(' ').Select(Int32.Parse).ToArray();
                for (int j = 0; j < 6; j++)
                {
                    matrix[i, j] = a[j];
                }
            }
            int h = 0;
            int v = 0;
            int maxSum = int.MinValue;
            for (h = 0; h < matrix.GetLength(0); h++)
            {
                for (v = 0; v < matrix.GetLength(1); v++)
                {
                    int r = h;
                    int c = v;
                    int sum = 0;
                    if (c + 3 <= matrix.GetLength(1) && r + 3 <= matrix.GetLength(0))
                    {
                        for (c = v; c < v + 3; c++)
                        {
                            sum += matrix[r, c];
                            sum += matrix[r + 2, c];
                        }
                        c = v;
                        sum += matrix[r + 1, c + 1];
                        if (sum > maxSum)
                        {
                            maxSum = sum;
                        }
                    }
                }
            }
            Console.WriteLine(maxSum);
            Console.ReadKey();
        }
    }
}