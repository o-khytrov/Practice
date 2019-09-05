using System;
using System.Threading;
using System.Threading.Tasks;

namespace _004_Parallel.For
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] data = new int[100000000];
            Parallel.For(0, data.Length, i => data[i] = i);
            data[300] = -1;

            Action<int, ParallelLoopState> transform = (int i, ParallelLoopState state) =>
            {
                if (data[i] < 0)
                {
                    state.Break();
                }
                Thread.Sleep(1);
                data[i] = i * i * i / 123;
            };

            ParallelLoopResult result = Parallel.For(0, data.Length, transform);
            if (!result.IsCompleted)
            {
                Console.WriteLine("\nЦикл прервался преждевременно" +
                    "Элемент {0} имеет отрицательное значение", result.LowestBreakIteration);
            }

            Console.WriteLine("Основной поток завершен");
            Console.ReadKey();
        }
    }
}