using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _007_TPL_WaitAll_Any
{
    class Program
    {
        static void MyTask()
        {
            Console.WriteLine("MyTask: CurrentId " + Task.CurrentId + " запущен.");
            Thread.Sleep(2000);
            Console.WriteLine("MyTask: CurrentId " + Task.CurrentId + " завершен.");


        }
        static void MyTask2()
        {
            Console.WriteLine("MyTask2: CurrentId " + Task.CurrentId + " запущен.");
            Thread.Sleep(3000);
            Console.WriteLine("MyTask2: CurrentId " + Task.CurrentId + " завершен.");


        }
        static void Main(string[] args)
        {
            Console.WriteLine("Primary thread is launched");
            Task task1 = new Task(MyTask);
            Task task2 = new Task(MyTask2);

            task1.Start();
            task2.Start();

            Console.WriteLine("Id задачи task1: " + task1.Id);
            Console.WriteLine("Id задачи task2: " + task2.Id);

            Task.WaitAny(task1, task2);

            Console.WriteLine("Основной поток завершен");

            Console.ReadKey();
        }
    }
}
