using System;
using System.IO;
using System.Linq;

namespace MinimizeCost
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("Console.txt"));
            var a = Console.ReadLine().Split(' ').Select(Int32.Parse).ToArray();

            var N = a[0];
            var K = a[1];

            var A = Console.ReadLine().Split(' ').Select(Int32.Parse).ToArray();
            var tr = new int[N];
            tr.Fill(0);
            var cost = A.Cost(tr);
            var transAr = (int[])A.Clone();

            for (int i = 0; i < transAr.Length; i++)
            {
                var subArray = transAr.ExtractSubArray(i, K);
                subArray.Print();
                //if (transAr[i] > 0)
                //{
                //    for (int d = i; d < i + K && d < transAr.Length; d++)
                //    {
                //        var val = transAr[i];
                //        var tempArr = (int[])A.Clone();
                //        tempArr.Transfer(i, d, val);
                //        var currentCost = tempArr.Cost(A);

                //    }
                //}

                //var newCost = A.Cost(transAr);
                //if (newCost < cost)
                //{
                //    cost = newCost;
                //}
                

            }
            Console.WriteLine(cost);

            Console.ReadKey();
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

        public static int Cost(this int[] array, int[] trArr)
        {
            var sum = 0;
            var m = "C(x)=";
            for (int i = 0; i < array.Length; i++)
            {
                m = m + $"|{array[i]}+{trArr[i]}|";
                sum += (Math.Abs(array[i] + trArr[i]));
            }
            m = m + $"={sum}";
          //  Console.WriteLine(m);
            return sum;
        }

        public static void Transfer(this int[] array, int source, int destination, int value)
        {
            var temp = array[destination];
            array[destination] = value;
            array[source] -= value - temp;
            // array.Print();
        }

        public static void Print(this int[] array)
        {
            var m = string.Join(" ", array);
           // var m = $"{string.Join(" ", array)}; Sum: {array.Sum(x => x)}";
            Console.WriteLine(m);
        }

      
    }
}