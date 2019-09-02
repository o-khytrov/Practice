using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _004_AsyncWaitHandle
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> myDelegate = new Func<int, int, int>(Sum);
            IAsyncResult asyncResult = myDelegate.BeginInvoke(1, 2, null, null);
            Console.WriteLine("Асинхронный метод запущен. Метод Main продолжает работать");
            Console.WriteLine("Метод Main ожидает завершения асинхронной задачи");
            Console.WriteLine(asyncResult.AsyncWaitHandle.GetType());
            asyncResult.AsyncWaitHandle.WaitOne();
            Console.WriteLine("Асинхронный метод завершен. Метод Main продолжает работать");

            int result = myDelegate.EndInvoke(asyncResult);
            Console.WriteLine("Результат " + result);
            Console.ReadKey();
        }

        static int Sum(int a, int b)
        {
            Thread.Sleep(2000);
            return a + b;

        }
    }
}
