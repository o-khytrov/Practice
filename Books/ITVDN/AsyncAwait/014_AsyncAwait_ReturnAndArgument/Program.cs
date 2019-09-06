using System;
using System.Threading;
using System.Threading.Tasks;

namespace _014_AsyncAwait_ReturnAndArgument
{
    internal class MyClass
    {
        private double Operation(object argument)
        {
            Thread.Sleep(2000);
            return (double)argument * (double)argument;
        }

        public async Task<double> OperationAsync(double argument)
        {
            return await Task<double>.Factory.StartNew(Operation, argument);
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            MyClass my = new MyClass();
            var task = my.OperationAsync(2);
            task.ContinueWith(t => Console.WriteLine("Результат {0}", t.Result));
            Console.ReadKey();
        }
    }
}