using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoResetEvent__02
{
    class Program
    {
        static AutoResetEvent auto = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            new Thread(Function).Start();
            new Thread(Function) { IsBackground = true }.Start();

            Thread.Sleep(500);
            Console.WriteLine("Press any key to set autoResetEvent into signal state");
            Console.ReadKey();
            auto.Set();
            //auto.Set();

            Console.ReadKey();

        }


        static void Function()
        {
            Console.WriteLine("Thread 1 started and is waiting for a signal");
            auto.WaitOne();
            Console.WriteLine("Thread 1 is finishing");
        }
    }
}
