using System;
using System.Threading;
using System.Threading.Tasks;

namespace _002_TPL_Id
{
    internal class Program
    {
        private static void MyTask()
        {
            Console.WriteLine("MyTask: CurrentId {0} c ManagedThreadId {1} launched", Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2000);

            Console.WriteLine("MyTask: CurrentId " + Task.CurrentId + " finished");
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Main: Task.Current = {0}", Task.CurrentId == null ? "null" : Task.CurrentId.ToString());

            Task task1 = new Task(MyTask);
            Task task2 = new Task(MyTask);

            task1.Start();
            task2.Start();
            Console.WriteLine($"Id of task1 {task1.Id}");
            Console.WriteLine($"Id of task2 {task2.Id}");
            Console.ReadKey();
        }
    }
}