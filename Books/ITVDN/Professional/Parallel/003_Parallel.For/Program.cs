using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_Parallel.For
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = new int[100000000];

            Stopwatch timer = new Stopwatch();

            timer.Start();
            Parallel.For(0, data.Length, i => data[i] = i);
            timer.Stop();

            Console.WriteLine("Параллельная инициализация     {0} секунд.", timer.Elapsed.TotalSeconds);


            timer.Reset();
            timer.Start();
            for (int i = 0; i < data.Length; i++)
                data[i] = i;
            timer.Stop();

            Console.WriteLine("Последовательная инициализация {0} секунд.", timer.Elapsed.TotalSeconds);

            Console.WriteLine();

            timer.Reset();
            timer.Start();
            Parallel.For(0, data.Length, i => data[i] = (i * i * i / 123) + ((int)Math.Sqrt(16)));
            timer.Stop();

            Console.WriteLine("Параллельное преобразование     {0} секунд.", timer.Elapsed.TotalSeconds);

            timer.Reset();
            timer.Start();
            for (int i = 0; i < data.Length; i++)
                data[i] = (i * i * i / 123) + (int)Math.Sqrt(16);
            timer.Stop();

            Console.WriteLine("Последовательное преобразование {0} секунд.", timer.Elapsed.TotalSeconds);
            timer.Reset();
            Console.ReadLine();

        }
    }
}
