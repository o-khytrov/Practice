using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _012_Volatile
{
    internal sealed class ThreadsSharingData
    {
        private Int32 m_flag = 0;
        private Int32 m_value = 0;
        // This method is executed by one thread
        public void Thread1()
        {
            // Note: These could execute in reverse order
            m_value = 5;
            Volatile.Write(ref m_flag, 1);
        }
        // This method is executed by another thread
        public void Thread2()
        {

            // Note: m_value could be read before m_flag
            if (Volatile.Read(ref m_flag) == 1)
                Console.WriteLine(m_value);
        }

        static void Main()
        {
            var c = new ThreadsSharingData();
            var t1 = new Thread(c.Thread1);
            var t2 = new Thread(c.Thread2);
            t1.Start();
            t2.Start();
            Console.ReadKey();
        }
    }
    //internal static class StrangeBehavior
    //{
    //    // As you'll see later, mark this field as volatile to fix the problem
    //    private static Boolean s_stopWorker = false;
    //    public static void Main()
    //    {
    //        Console.WriteLine("Main: letting worker run for 5 seconds");
    //        Thread t = new Thread(Worker);
    //        t.Start();
    //        Thread.Sleep(5000);
    //        s_stopWorker = true;
    //        Console.WriteLine("Main: waiting for worker to stop");
    //        t.Join();
    //    }

    //    private static void Worker(Object o)
    //    {
    //        Int32 x = 0;
    //        while (!s_stopWorker) x++;
    //        Console.WriteLine("Worker: stopped when x={0}", x);
    //    }
    //}

}
