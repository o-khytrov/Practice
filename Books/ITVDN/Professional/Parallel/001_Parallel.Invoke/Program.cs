﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _001_Parallel.Invoke
{
    class Program
    {
        static void MyTask1()
        {
            Console.WriteLine("MyTask1: запущен");
            for (int i = 0; i < 80; i++)
            {
                Thread.Sleep(10);
                Console.Write("+");
            }
            Console.WriteLine("MyTask1: завершен");
        }
        static void MyTask2()
        {
            Console.WriteLine("MyTask2: запущен");
            for (int i = 0; i < 80; i++)
            {
                Thread.Sleep(10);
                Console.Write("-");
            }
            Console.WriteLine("MyTask2: завершен");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Основной поток запущен");
            ParallelOptions options = new ParallelOptions();

            options.MaxDegreeOfParallelism = Environment.ProcessorCount > 2 ? Environment.ProcessorCount - 1 : 1;

            options.MaxDegreeOfParallelism = 2;

            Console.WriteLine("Количество логических ядер CPU: " + Environment.ProcessorCount);
            Console.ReadKey();
            Parallel.Invoke(options, MyTask1, MyTask2);
            //Parallel.Invoke(options, MyTask1, MyTask2, MyTask1, MyTask2);

            Console.WriteLine("Основной поток завершен");
        }
    }
}
