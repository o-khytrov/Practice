using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _006_ChildTasks
{
    class Program
    {
        private static int Sum(int n)
        {
            Console.WriteLine("Sum {0}", Thread.CurrentThread.ManagedThreadId);
            Int32 sum = 0;
            for (; n > 0; n--)
            {
                checked { sum += n; }
                Thread.Sleep(20);
            }

            return sum;
        }
        static void Main(string[] args)
        {
            Task<Int32[]> parent = new Task<Int32[]>(() =>
            {
                var results = new Int32[3]; // Create an array for the results
                                            // This tasks creates and starts 3 child tasks
                new Task(() => results[0] = Sum(10000), TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[1] = Sum(20000), TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[2] = Sum(30000), TaskCreationOptions.AttachedToParent).Start();
                // Returns a reference to the array (even though the elements may not be initialized yet)
                return results;
            });
            parent.Start();
            Console.ReadKey();
        }
    }
}
