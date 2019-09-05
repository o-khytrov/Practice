using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _009_AsyncAwait_Continuation
{
    class MyClass
    {
        public void Operation()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Основная задача");

        }

        public async Task OperationAsync()
        {
            await Task.Factory.StartNew(Operation);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyClass my = new MyClass();
            Task task = my.OperationAsync();
            task.ContinueWith(t=> Console.WriteLine("\nПродолжение задачи."));
            Console.WriteLine("Первичный поток завершил работу. ThreadID {0}", Thread.CurrentThread.ManagedThreadId);

            Console.ReadKey();
        }
    }
}
