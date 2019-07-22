using System;
using System.IO;

//** Every node contains a value that lies between 1 and N
//** No two nodes contain the same value
//** All the levels are completely filled except possibly the last level
//** Each even-valued node contains and even-valued node as its left child and even-valued node as its right child
//** Each odd-valued node contains and odd-valued node as its left child and even-valued node as its right child

namespace SpecialBinaryTree
{
    public class Node
    {
        private Node Right { get; set; }
        private Node Left { get; set; }
        public int Value { get; set; }

        public static Node Insert(Node root, int value)
        {
            if (root == null)
            {
                root = new Node();
                root.Value = value;
            }
            else
            {
                if (value.IsOdd())
                {
                    if (value.IsOdd())
                    {
                        root.Left = Node.Insert(root.Left, value);
                    }
                    else
                    {
                        root.Right = Node.Insert(root.Right, value);
                    }
                }
                else if (value.isEven())
                {
                    if (value.isEven())
                    {
                        root.Left = Node.Insert(root.Left, value);
                    }
                    else
                    {
                        root.Right = Node.Insert(root.Right, value);
                    }
                }
            }
            return root;
        }

        public static Node BuildTree(int[] values, int min, int max)
        {
            if (min == max)
            {
                return null;
            }
            int median = min + (max - min) / 2;
            return new Node
            {
                Value = values[median],
                Left = BuildTree(values, min, median),
                Right = BuildTree(values, median + 1, max)
            };
        }
    }

    internal class Program
    {
        private static int Factorial(int n)
        {
            var factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            var T = Int32.Parse(Console.ReadLine().Trim());

            for (int t = 0; t < T; t++)
            {
                long maxNumber = 0;
                var N = Int32.Parse(Console.ReadLine().Trim());
                if (N == 2)
                {
                    maxNumber = N;
                }
                else
                {
                    maxNumber = (long)(Math.Pow(N, N - 2));
                }
                Console.WriteLine(Math.Log(4608,N));
                var res = maxNumber % (Math.Pow(10, 9) + 7);
                Console.WriteLine(res);
            }

            Console.ReadKey();
        }
    }

    public static class Extensions
    {/// <summary>
     /// Нечетный
     /// </summary>
     /// <param name="number"></param>
     /// <returns></returns>
        public static bool IsOdd(this int number)
        {
            return number % 2 != 0;
        }

        /// <summary>
        /// Четный
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool isEven(this int number)
        {
            return number % 2 == 0;
        }
    }
}