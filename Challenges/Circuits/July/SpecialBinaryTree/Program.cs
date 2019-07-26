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

        private static void Permute(int[] arr, int l, int r)
        {
            if (l == r)
            {
                Console.WriteLine(string.Join(" ", arr));
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
            arr[l] = arr[l] ^ arr[r];
            arr[r] = arr[l] ^ arr[r];
            arr[l] = arr[l] ^ arr[r];
        }

        private static void Main(string[] args)
        {
            var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
            if (value == "True")
                Console.SetIn(new StreamReader("Console.txt"));

            string line = Console.ReadLine();
            var T = int.Parse(line.Trim());

            for (int t = 0; t < T; t++)
            {
                line = Console.ReadLine();
                var n = int.Parse(line);
                var maxNumberOfTrees = Math.Pow(n, n - 2) % Mod;
                Compute(n);
            }

            Console.ReadKey();
        }
    }

    internal class ArrayTree
    {
        private static int root = 0;
        private static String[] str = new String[10];

        /*create root*/

        public void Root(String key)
        {
            str[0] = key;
        }

        /*create left son of root*/

        public void set_Left(String key, int root)
        {
            int t = (root * 2) + 1;

            if (str[root] == null)
            {
                Console.Write("Can't set child at {0}, no parent found\n", t);
            }
            else
            {
                str[t] = key;
            }
        }

        /*create right son of root*/

        public void set_Right(String key, int root)
        {
            int t = (root * 2) + 2;

            if (str[root] == null)
            {
                Console.Write("Can't set child at {0}, no parent found\n", t);
            }
            else
            {
                str[t] = key;
            }
        }

        public void print_Tree()
        {
            for (int i = 0; i < 10; i++)
            {
                if (str[i] != null)
                    Console.Write(str[i]);
                else
                    Console.Write("-");
            }
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