using System;
using System.Threading;

namespace _006_Async_CallBack
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Первичный поток: Id {0}", Thread.CurrentThread.ManagedThreadId);

            Action action = new Action(Method);

            AsyncCallback callback = new AsyncCallback(CallBack);

            action.BeginInvoke(callback, null);
            Console.WriteLine("Первичный поток продолжает работать");

            Console.ReadKey();

        }

        private static void Method()
        {
            Console.WriteLine("\nВторичный поток: Id {0}", Thread.CurrentThread.ManagedThreadId);

            for (int i = 0; i < 80; i++)
            {
                Thread.Sleep(20);
                Console.Write(".");
            }
            Console.WriteLine("\nВторичный поток завершен.\n");
        }

        static void CallBack(IAsyncResult asyncResult)
        {
            Console.WriteLine("Callback метод. Thread Id {0}", Thread.CurrentThread.ManagedThreadId);
        }
    }
}