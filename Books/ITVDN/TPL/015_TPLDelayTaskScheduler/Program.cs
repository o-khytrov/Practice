using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _015_TPLDelayTaskScheduler
{
    class Program
    {
        static void MyTask()
        {
            Console.WriteLine("MyTask ThreadID {0}", Thread.CurrentThread.ManagedThreadId);

            for (int i = 0; i < 010; i++)
            {
                Thread.Sleep(200);
                Console.Write("+");
            }
        }

        static void Main(string[] args)
        {
            TaskScheduler scheduler = new DelayTaskScheduler();

            TaskFactory factory = new TaskFactory(scheduler);

            Task task = factory.StartNew(MyTask);

            TaskAwaiter awaiter = task.GetAwaiter();

            while (!awaiter.IsCompleted)
            {
                Console.Write(".");
                Thread.Sleep(100);

            }
            Console.WriteLine("\nAll tasks completed");
            Console.ReadKey();
        }

        public class DelayTaskScheduler : TaskScheduler
        {
            Queue<Task> queue = new Queue<Task>();
            AutoResetEvent auto = new AutoResetEvent(false);

            protected override IEnumerable<Task> GetScheduledTasks()
            {
                return queue;
            }

            protected override void QueueTask(Task task)
            {
                Console.WriteLine("Queue Task ThreadID {0}", Thread.CurrentThread.ManagedThreadId);
                queue.Enqueue(task);

                WaitOrTimerCallback callback = (object state, bool timeout) => { base.TryExecuteTask(queue.Dequeue()); };
                ThreadPool.RegisterWaitForSingleObject(auto, callback, null, 2000, true);

            }

            protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
            {
                return false;
            }
        }
    }
}
