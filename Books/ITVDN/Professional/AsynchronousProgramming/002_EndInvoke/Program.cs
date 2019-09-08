using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _002_EndInvoke
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Primary thread: Id {0}", Thread.CurrentThread.ManagedThreadId);

            Action myDelegate = new Action(Method);

            IAsyncResult result = myDelegate.BeginInvoke(null, null);

            //.EndInvoke(result);

            Console.WriteLine("Primary thread finished its word");
        }

        private static void Method()
        {
            Console.WriteLine("Secondary thread: Id {0}", Thread.CurrentThread.ManagedThreadId);
            for (int i = 0; i < 500; i++)
            {
                Thread.Sleep(100);
                Console.Write("2");
            }

        }
    }
}
