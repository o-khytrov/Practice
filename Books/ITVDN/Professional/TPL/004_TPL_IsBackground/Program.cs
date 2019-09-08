using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _004_TPL_IsBackground
{
    class Program
    {
        static void MyTask()
        {
            Thread.CurrentThread.IsBackground = false;
            for (int i = 0; i < 80; i++)
            {
                Thread.Sleep(100);
                Console.Write(".");
            }

        }
        static void Main(string[] args)
        {
            Task task = new Task(MyTask);
            task.Start();
            Thread.Sleep(500);
            Console.WriteLine("\nMain завершен");
        }
    }
}
