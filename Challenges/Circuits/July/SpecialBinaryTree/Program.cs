using System;
using System.Collections.Generic;
using System.IO;

//** Every node contains a value that lies between 1 and N
//** No two nodes contain the same value
//** All the levels are completely filled except possibly the last level
//** Each even-valued node contains and even-valued node as its left child and even-valued node as its right child
//** Each odd-valued node contains and odd-valued node as its left child and even-valued node as its right child

namespace SpecialBinaryTree
{
    internal class Program
    {
        public static int Mod = 1000000007;
        public static int counter;

        private static int Factorial(long n)
        {
            var factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i % Mod;
            }
            return factorial;
        }

        public static Dictionary<int, int> Memorization;

        private static void Compute(int number)
        {
            var array = new int[number];
            for (int i = 0; i < number; i++)
            {
                array[i] = i + 1;
            }
            int n = array.Length;
            Permute(array, 0, n - 1);
        }

        private static void Compute(int[] array, int ind)
        {
            if (ind > array.Length - 1)
            {
                return;
            }
            for (int i = 1; i <= array.Length; i++)
            {
                var clone = (int[])array.Clone();
                clone[ind] = i;

                if (ind == array.Length - 1)
                {
                    var sbt = clone.isSpecialBT(0);
                    if (sbt)
                    {
                        counter++;
                    }
                    Console.WriteLine($"{string.Join(" ", clone)} {sbt}");
                }
                Compute(clone, ind + 1);
            }
        }

        private static void Permute(int[] arr, int l, int r)
        {
            if (l == r)
            {
                var sbt = arr.isSpecialBT(0);
                if (sbt)
                {
                    counter++;
                }
                Console.WriteLine($"{string.Join(" ", arr)} {(sbt ? "special" : "")}");
                return;
            }
            else
            {
                for (int i = l; i <= r; i++)
                {
                    swap(arr, l, i);
                    Permute(arr, l + 1, r);
                    swap(arr, l, i);
                }
            }
        }

        private static void swap(int[] arr, int l, int r)
        {
            var temp = arr[l];
            arr[l] = arr[r];
            arr[r] = temp;
        }

        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));
            var sbt = new int[] { 1, 2, 3, 4 }.isSpecialBT(0);
            string line = Console.ReadLine();
            var T = int.Parse(line.Trim());

            for (int t = 0; t < T; t++)
            {
                counter = 0;
                line = Console.ReadLine();
                var n = int.Parse(line);
                var maxNumberOfTrees = Math.Pow(n, n - 2) % Mod;

                Compute(n);
                Console.WriteLine(counter);
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

        public static bool isSpecialBT(this int[] tree, int index, int parent = 0)
        {
            if (!tree.HasChildren(index))
            {
                return true;
            }

            var root = tree[index];

            var left = tree.GetLeftChild(index);
            var right = tree.GetRightChild(index);
            if (left == 0 && right != 0)
            {
                if (root.isEven() && right.IsOdd() || root.IsOdd() && right.isEven())
                {
                    return true;
                }
                return false;
            }
            else if (left != 0 && right == 0)
            {
                if (root.isEven() && left.isEven() || root.IsOdd() && left.IsOdd())
                {
                    return true;
                }
                return false;
            }
            if (root.isEven() && left.isEven() && right.IsOdd() || root.IsOdd() && left.IsOdd() && right.isEven())
            {
                var indexOfLeftChild = (root * 2) + 1;
                var indexOfRightChild = (root * 2) + 2;

                if (tree.isSpecialBT((indexOfLeftChild * 2) + 1))
                {
                    return (tree.isSpecialBT((indexOfLeftChild * 2) + 2));
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public static bool HasLeftChild(this int[] array, int root)
        {
            return array.Length - 1 >= (root * 2) + 1;
        }

        public static bool HasRightChild(this int[] array, int root)
        {
            return array.Length - 1 >= (root * 2) + 2;
        }

        public static bool HasChildren(this int[] tree, int root)
        {
            return tree.HasLeftChild(root) && tree.HasRightChild(root);
        }

        public static int GetLeftChild(this int[] array, int root)
        {
            var t = (root * 2) + 1;
            if (t > array.Length - 1)
            {
                return 0;
            }
            return array[t];
        }

        public static int GetRightChild(this int[] array, int root)
        {
            var t = (root * 2) + 2;
            if (t > array.Length - 1)
            {
                return 0;
            }
            return array[t];
        }
    }
}