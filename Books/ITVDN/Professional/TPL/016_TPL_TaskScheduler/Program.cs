using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _016_TPL_TaskScheduler
{
    class Program
    {
        static void MyTask1()
        {
            Console.WriteLine("MyTask1 ThreadID {0}", Thread.CurrentThread.ManagedThreadId);
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(200);
                Console.Write("+ ");
            }

        }
        static void MyTask2()
        {
            Console.WriteLine("MyTask2 ThreadID {0}", Thread.CurrentThread.ManagedThreadId);
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(200);
                Console.Write("- ");
            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Main TheradID {0}", Thread.CurrentThread.ManagedThreadId);

            List<Task> tasks = new List<Task>();
            var scheduler = new DelayTaskScheduler();
            var factory = new TaskFactory(scheduler);
            tasks.Add(factory.StartNew(MyTask1));
            tasks.Add(factory.StartNew(MyTask2));

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("All tasks completed");
        }
    }

    public class DelayTaskScheduler : TaskScheduler
    {
        Queue<Task> queue = new Queue<Task>();

        protected override IEnumerable<Task> GetScheduledTasks()
        {
            return queue;
        }

        protected override void QueueTask(Task task)
        {
            Console.WriteLine("Queue Task");
            queue.Enqueue(task);
            WaitCallback callback = (object state) => base.TryExecuteTask(queue.Dequeue());
            //ThreadPool.QueueUserWorkItem(callback, null);
        }

        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            Console.WriteLine("TryExecuteTaskInline");
           return base.TryExecuteTask(task);
        
        }
    }
}
