using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _004_Cancellation
{
    class Program
    {
        public static void Main()
        {
            CancellationTokenSource cts1 = new CancellationTokenSource();
            CancellationTokenSource cts2 = new CancellationTokenSource();


            cts1.Token.Register(() => Console.WriteLine("cts1 canceled"));

            cts2.Token.Register(() => Console.WriteLine("cts2 canceled"));

            var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(cts1.Token, cts2.Token);
            linkedCts.Token.Register(() => Console.WriteLine("linkedCts canceled"));

            // Pass the CancellationToken and the number-to-count-to into the operation
            ThreadPool.QueueUserWorkItem(o => Count(cts1.Token, 1000));

            Console.WriteLine("Press <Enter> to cancel the operation.");
            Console.ReadLine();
            cts1.CancelAfter(1000); // If Count returned already, Cancel has no effect on it
                                    // Cancel returns immediately, and the method continues running here...
            Console.WriteLine("cts1 canceled={0}, cts2 canceled={1}, linkedCts canceled={2}",
            cts1.IsCancellationRequested, cts2.IsCancellationRequested,
            linkedCts.IsCancellationRequested);
            Console.ReadLine();
        }


        private static void Count(CancellationToken token, Int32 countTo)
        {
            for (Int32 count = 0; count < countTo; count++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Count is cancelled");
                    break; // Exit the loop to stop the operation
                }
                Console.WriteLine(count);
                Thread.Sleep(200); // For demo, waste some time
            }
            Console.WriteLine("Count is done");
        }
    }
}
