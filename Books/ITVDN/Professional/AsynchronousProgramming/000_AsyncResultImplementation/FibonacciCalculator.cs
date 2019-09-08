using System;
using System.Collections.Generic;
using System.Threading;

namespace _000_AsyncResultImplementation
{
    public class FibonacciCalculator
    {
        List<int> fibonacciSequence = new List<int>();
        int count;

        public IEnumerable<long> MyFib(int n)
        {
            yield return 0;
            yield return 1;
            yield return 1;
            var x = 1;
            var y = 1;
            var counter = 2;
            while (counter < n)
            {

                yield return x + y;
                x = x + y;
                y = x - y;
                counter++;

            }
        }
        public List<int> Invoke(int count)
        {
            this.count = count;
            Fibinacci(null);
            return fibonacciSequence;
        }

        public IAsyncResult BeginInvoke(int count, AsyncCallback callback, object @object)
        {
            this.count = count;
            var fig = new Func<int, List<int>>(Fibinacci);
            return fig.BeginInvoke(count, callback, @object);
        }

        public List<int> EndInvoke(IAsyncResult result)
        {
            var asyncResult = result as System.Runtime.Remoting.Messaging.AsyncResult;

            Func<int, List<int>> fibonaci = asyncResult.AsyncDelegate as Func<int, List<int>>;

            fibonacciSequence = fibonaci.EndInvoke(result);

            return fibonacciSequence;

        }
        void Fibinacci(object arg)
        {
            Func<int, int> fib = null;
            fib = (x) => x > 1 ? fib(x - 1) + fib(x - 2) : x;
            for (int i = 0; i < count; i++)
            {
                fibonacciSequence.Add(fib.Invoke(i));
            }
        }

        List<int> Fibinacci(int cont)
        {
            Func<int, int> fib = null;
            fib = (x) => x > 1 ? fib(x - 1) + fib(x - 2) : x;
            for (int i = 0; i < count; i++)
            {
                fibonacciSequence.Add(fib.Invoke(i));
            }
            return fibonacciSequence;
        }
    }
}
