using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _009_TPL_Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Основной поток запущен.");
            Task task = Task.Factory.StartNew(() =>
            {

                for (int i = 0; i < 80; i++)
                {
                    Thread.Sleep(20);
                    Console.WriteLine(".");
                }
            });
            task.Wait();

            task.Dispose();
            Console.WriteLine("Main thread is finished");

            Console.ReadKey();
        }



    }
}
