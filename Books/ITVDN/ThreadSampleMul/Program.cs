using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSampleMul
{
    class Program
    {
        [ThreadStatic]
        public static int counter;

        public static void Method()
        {
            if (counter < 100)
            {
                counter++;
                Console.WriteLine(counter + " Start " + Thread.CurrentThread.GetHashCode());
                Thread thread = new Thread(Method);
                thread.Start();
                thread.Join();
            }
            Console.WriteLine("Thread {0} finished ", Thread.CurrentThread.GetHashCode());
        }
        static void Main(string[] args)
        {
            Thread thread = new Thread(Method);
            thread.Start();
            thread.Join();
            Console.ReadKey();

        }
    }
}
