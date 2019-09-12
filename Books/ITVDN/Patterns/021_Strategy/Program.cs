using System;

namespace _021_Strategy
{
    internal class Program
    {
        //Паттерн обеспечивать возможность выполнять задачу разными способами
        private abstract class Strategy
        {
            public abstract void Sort(ref int[] array);
        }

        private class Context
        {
            private Strategy strategy;
            private int[] array = { 3, 5, 1, 2, 4 };

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

        private class BubbleSort : Strategy
        {
            public override void Sort(ref int[] array)
            {
                Console.WriteLine("Bubble Sort");
                bool isSorted = false;

                do
                {
                    isSorted = true;
                    for (int i = 0; i < array.Length - 1; i++)
                    {
                        if (array[i] > array[i + 1])
                        {
                            isSorted = false;
                            int temp = array[i];
                            array[i] = array[i + 1];
                            array[i + 1] = temp;
                            break;
                        }
                    }
                } while (!isSorted);
            }
        }

        private class SelectionSort : Strategy
        {
            public override void Sort(ref int[] array)
            {
                Console.WriteLine("Selection Sort");

                for (int i = 0; i < array.Length - 1; i++)
                {
                    int k = i;
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[k] > array[j])
                        {
                            k = j;
                        }
                    }
                    if (k != i)
                    {
                        int temp = array[k];
                        array[k] = array[i];
                        array[i] = temp;
                    }
                }
            }
        }

        private class InsertionSort : Strategy
        {
            public override void Sort(ref int[] array)
            {
                Console.WriteLine("Insertion Sort");

                for (int i = 1; i < array.Length; i++)
                {
                    int j = 0;
                    int buffer = array[i];
                    for (j = i - 1; j >= 0; j--)
                    {
                        if (array[j] < buffer)
                        {
                            break;
                        }
                        array[j + 1] = array[j];
                    }

                    array[j + 1] = buffer;
                }
            }
        }

        private static void Main(string[] args)
        {
            var context = new Context(new BubbleSort());
            context.Sort();
            context.PrintArray();

            var context2 = new Context(new InsertionSort());
            context2.Sort();
            context2.PrintArray();

            var context3 = new Context(new SelectionSort());
            context3.Sort();
            context3.PrintArray();

            Console.ReadKey();
        }
    }
}