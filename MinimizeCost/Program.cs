using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimizeCost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("Console.txt"));
            var a = Console.ReadLine().Split(' ').Select(Int32.Parse).ToArray();

            var N = a[0];
            var K = a[1];

            var A = Console.ReadLine().Split(' ').Select(Int32.Parse).ToArray();
            

        }
    }
    public static class ArrayExtensions
    {
        public static void Fill<T>(this T[] originalArray, T with)
        {
            for (int i = 0; i < originalArray.Length; i++)
            {
                originalArray[i] = with;

            }
        }

        public static int Cost(this int[] array, int[] transferArray)
        {
            var sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += (array[i] + transferArray[i]);
            }
            return sum;
        }

    }
}
