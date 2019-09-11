using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _021_Strategy
{
    class Program
    {
        abstract class Strategy
        {
            public abstract void Sort(ref int[] array);
        }


        class Context
        {
            Strategy strategy;
            int[] array = { 3, 5, 1, 2, 4 };
            public Context(Strategy strategy)
            {
                this.strategy = strategy;
            }
            public void Sort()
            {
                strategy.Sort(ref array);
            }

            public void PrintArray()
            {
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write(array[i] + " ");
                }
                Console.WriteLine();
            }
        }
        class BubbleSort : Strategy
        {
            public override void Sort(ref int[] array)
            {
                Console.WriteLine("Bubble Sort");
            }
        }
        class SelectionSort : Strategy
        {
            public override void Sort(ref int[] array)
            {
                Console.WriteLine("Selection Sort");
            }
        }
        class InsertionSort : Strategy
        {
            public override void Sort(ref int[] array)
            {
                Console.WriteLine("Selection Sort");
            }
        }
        static void Main(string[] args)
        {
        }
    }
}
