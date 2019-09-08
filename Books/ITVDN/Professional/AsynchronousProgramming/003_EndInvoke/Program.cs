using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _003_EndInvoke
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> myDelegate = new Func<int, int, int>(Sum);
            IAsyncResult asyncResult = myDelegate.BeginInvoke(1, 2, null, null);
            int result = myDelegate.EndInvoke(asyncResult);
            Console.WriteLine("Result is " + result);
             
            Console.ReadKey();
        }

        static int Sum(int a, int b)
        {
            Thread.Sleep(2000);
            return a + b;

        }
    }
}
