using System;
using System.Threading;

namespace EventWaitHandleDemo
{
    internal class Program
    {
        private static EventWaitHandle handle = null;
       
        private static void Main(string[] args)
        {
            handle = new EventWaitHandle(false, EventResetMode.ManualReset, "GlobalEvent::GUID");

            Thread thread = new Thread(Function) { IsBackground = true };
            thread.Start();
            Console.WriteLine("Press any key to start work");
            Console.ReadKey();
            handle.Set();
            Console.ReadKey();
        }

        private static void Function()
        {
            handle.WaitOne();
            while (true)
            {
                Console.WriteLine("Hello world!");
                Thread.Sleep(0300);
            }
        }
    }
}