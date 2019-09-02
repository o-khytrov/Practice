using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _009_Async_CallBack
{
    class Program
    {
        static int Sum(int a, int b)
        {
            Thread.CurrentThread.IsBackground = false;
            Console.WriteLine("Вторичный поток Id {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(3000);
            return a + b;
        }

        static void CallBack(IAsyncResult asyncResult)
        {
            AsyncResult ar = asyncResult as AsyncResult;
            Func<int, int, int> caller = (Func<int, int, int>)ar.AsyncDelegate;
            int sum = caller.EndInvoke(asyncResult);
            Console.WriteLine(String.Format(asyncResult.AsyncState.ToString(), sum));

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Первичный поток: Id {0}", Thread.CurrentThread.ManagedThreadId);
            Func<int, int, int> func = new Func<int, int, int>(Sum);
            func.BeginInvoke(1, 2, CallBack, "a+b={0}");
            Console.WriteLine("Первичный поток завершил работу");
            Console.ReadKey();
        }
    }
}
