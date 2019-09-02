using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _013_Thread_Cancellation
{
    class Program
    {
        static void MyTask(object arg)
        {
            CancellationToken token = (CancellationToken)arg;
            token.ThrowIfCancellationRequested();
            Console.WriteLine("MyTask is launched");
            for (int i = 0; i < 80; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Task abort is requested");
                    token.ThrowIfCancellationRequested();
                }
                Thread.Sleep(100);

                Console.Write(".");
            }
            Console.WriteLine("\nMyTask if completed");
        }
        static void Main(string[] args)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            Task task = new Task(MyTask, token);
            task.Start();

            Thread.Sleep(2000);

            try
            {
                cancellationTokenSource.Cancel();
                task.Wait();
            }
            catch (AggregateException ex)
            {

                if (task.IsCanceled)
                {
                    Console.WriteLine("\nЗадача отменена");
                }

                Console.WriteLine("Exception " + ex.GetType()); ;
                Console.WriteLine("Exception " + ex.Message);
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception " + ex.InnerException);
                }
            }
            Console.WriteLine("Основной поток завершен");

            Console.ReadKey();
        }
    }
}
