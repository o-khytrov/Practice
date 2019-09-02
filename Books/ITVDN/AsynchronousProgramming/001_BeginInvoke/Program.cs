using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _001_BeginInvoke
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Primary thread: Id {0}", Thread.CurrentThread.ManagedThreadId);

            Action myDelegate = new Action(Method);

            //myDelegate.BeginInvoke(null, null);
            myDelegate.Invoke();
            for (int i = 0; i < 80; i++)
            {
                Thread.Sleep(100);
                Console.Write("1");
            }
        }

        private static void Method()
        {
            Console.WriteLine("Secondary thread: Id {0}", Thread.CurrentThread.ManagedThreadId);
            for (int i = 0; i < 80; i++)
            {
                Thread.Sleep(100);
                Console.Write("2");
            }

        }
    }
}
