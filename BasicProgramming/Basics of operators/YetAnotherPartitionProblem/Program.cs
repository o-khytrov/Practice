using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace YetAnotherPartitionProblem
{
    internal class Program
    {
        private static void BuildListOfSubsets(int[] originalList, List<int[]> listOfSubsets, int sizeOfSubsetList, int currentLevel, Stack<int> currentList)
        {
            if (currentList.Count == sizeOfSubsetList)
            {
                int[] copy = new int[sizeOfSubsetList];
                currentList.CopyTo(copy, 0);
                listOfSubsets.Add(copy);
            }
            else
                for (int ix = currentLevel; ix < originalList.Length; ix++)
                {
                    currentList.Push(originalList[ix]);
                    BuildListOfSubsets(originalList, listOfSubsets, sizeOfSubsetList, ix + 1, currentList);
                    currentList.Pop();
                }
        }
        private static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("Console.txt"));

            var T = Int32.Parse(Console.ReadLine());
            for (int t = 0; t < T; t++)
            {
                var N = Int32.Parse(Console.ReadLine());
                var A = Console.ReadLine().Split(' ').Select(Int32.Parse).ToArray();
                var xor = A[0] ^ A[1] ^ A[2];
            }

            var a = 5;
            var b = 6;

            Console.WriteLine(Convert.ToString(a, 2));
            Console.WriteLine(Convert.ToString(b, 2));
            Console.WriteLine(Convert.ToString(a & b, 2));
            Console.WriteLine(Convert.ToString(a | b, 2));

            Console.ReadKey();
        }
    }
}