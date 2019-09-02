using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _008_TPL_Factory
{
    class Program
    {
        static void MyTask()
        {
            for (int i = 0; i < 80; i++)
            {
                Thread.Sleep(20);
                Console.Write(".");


            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Main ThreadID {0}", Thread.CurrentThread.ManagedThreadId);

            Task task = Task.Factory.StartNew(MyTask);
            Console.ReadKey();
        }
    }
}
