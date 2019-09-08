using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_Parallel.For
{
    class Program
    {

        static void Main(string[] args)
        {
            int[] data = new int[100000000];
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = i * i * i / 123;
            }
            timer.Stop();
            Console.WriteLine("Обычный цикл for      :" + timer.ElapsedTicks);

            Action<int> transform = (int i) => data[i] = i * i * i / 123;
            timer.Reset();
            timer.Start();
            Parallel.For(0, data.Length, transform);
            timer.Stop();
            Console.WriteLine("Параллельный цикл for :" + timer.ElapsedTicks);
        }
    }
}
