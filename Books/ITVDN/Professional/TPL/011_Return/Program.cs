using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _011_Return
{
    struct Context
    {
        public int a;
        public int b;
    }
    class Program
    {
        static int Sum(object arg)
        {
            int a = ((Context)arg).a;
            int b = ((Context)arg).b;
            Thread.Sleep(2000);
            return a + b;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread is running");
            Context context;
            context.a = 2;
            context.b = 3;
            var task = new Task<int>(Sum, context);
            task.Start();

            Console.WriteLine("Результат выполнения задачи {0}", task.Result);

            Console.ReadKey();
        }
    }
}
