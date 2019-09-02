using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _012_IsBackground
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Первичный поток начал работу");

            Action work = new Action(Procedure);

            work.BeginInvoke(CallBack, work);

            Thread.Sleep(1000);
            Console.WriteLine("\nПервичный поток завершил работу");
        }

        private static void CallBack(IAsyncResult ar)
        {
            Action work = ar.AsyncState as Action;
            if (work != null)
            {
                work.EndInvoke(ar);
            }
        }

        private static void Procedure()
        {
            //Thread.CurrentThread.IsBackground = false;
            Console.WriteLine("\nВторичный поток начал работу");
            for (int i = 0; i < 240; i++)
            {
                Thread.Sleep(20);
                Console.Write(".");
            }
            Console.WriteLine("\nВторичный поток начал работу");
        }
    }
}
