using System;
using System.IO;
using System.Threading;

namespace SpinLock
{
    public class SpinLock
    {
        private int block;
        private int wait;

        public SpinLock(int wait)
        {
            this.wait = wait;
        }

        public void Enter()
        {
            int result = Interlocked.CompareExchange(ref block, 1, 0);
            while (result == 1)
            {
                Thread.Sleep(wait);
                result = Interlocked.CompareExchange(ref block, 1, 0);
            }
        }

        public void Exit()
        {
            Interlocked.Exchange(ref block, 0);
        }
    }

    public class SpinLockManager : IDisposable
    {
        SpinLock block;
        public SpinLockManager(SpinLock spinLock)
        {
            this.block = spinLock;
            block.Enter();

        }
        public void Dispose()
        {
            block.Exit();
        }
    }
    internal class Program
    {
        static Random random = new Random();
        static SpinLock block = new SpinLock(10);
        static FileStream stream = File.Open("log.txt", FileMode.Create, FileAccess.Write, FileShare.None);
        static StreamWriter writer = new StreamWriter(stream);

        static void Function()
        {
            using (new SpinLockManager(block))
            {
                writer.WriteLine("Thread {0} is starting", Thread.CurrentThread.GetHashCode());
                writer.Flush();
            }
            int time = random.Next(10, 200);
            Thread.Sleep(time);
            using (new SpinLockManager(block))
            {
                writer.WriteLine("Thread {0} is finishing", Thread.CurrentThread.GetHashCode());
                writer.Flush();
            }
        }
        private static void Main(string[] args)
        {
            Thread[] threads = new Thread[50];
            for (int i = 0; i < 50; i++)
            {
                threads[i] =  new Thread(Function);
                threads[i].Start();
            }
        }
    }
}