using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _012_AsyncAwait_ReturnValue
{
    class MyClass
    {
        int Operation()
        {
            Thread.Sleep(2000);
            return 2 + 2;
        }
        public async Task<int> OperationAsync()
        {
            return await Task<int>.Factory.StartNew(Operation);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyClass my = new MyClass();
            Task<int> task = my.OperationAsync();
            task.ContinueWith(t => Console.WriteLine("Результат {0}", t.Result));

            Console.ReadKey();
        }
    }
}
