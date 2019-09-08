using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SemaphoreSlimSample
{
    class Program
    {
        static SemaphoreSlim pool;

        private static void Function(object number)
        {
            pool.Wait();
            Console.WriteLine("Thread {0} occupied slot of semaphore", number);
            Thread.Sleep(2000);
            Console.WriteLine("Thread {0} ------> left the slot", number);

            pool.Release();
        }

        static void Main(string[] args)
        {
            pool = new SemaphoreSlim(5, 5);


            for (int i = 1; i <= 40; i++)
            {
                new Thread(Function).Start(i);
                Thread.Sleep(500);
            }
            Console.ReadKey();
        }
    }
}
