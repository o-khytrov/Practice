using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _000_AsyncResultImplementation
{


    class Program
    {
        static List<int> fibonacciSequence;
        static FibonacciCalculator calculator = new FibonacciCalculator();

        static void Main(string[] args)
        {
            //fibonacciSequence = calculator.Invoke(40);
            //foreach (var item in fibonacciSequence)
            //{
            //    Console.Write("{0} ", item);
            //}


            //IAsyncResult asyncResult = calculator.BeginInvoke(40, null, null);
            //Console.WriteLine("My work");
            //fibonacciSequence = calculator.EndInvoke(asyncResult);
            //foreach (var item in fibonacciSequence)
            //{
            //    Console.Write("{0} ", item);
            //}

            IAsyncResult asyncResult = calculator.BeginInvoke(40, CallBack, calculator);
            Console.ReadKey();
        }

        private static void CallBack(IAsyncResult ar)
        {
            FibonacciCalculator calc = (FibonacciCalculator)ar.AsyncState;

            fibonacciSequence = calc.EndInvoke(ar);
            foreach (var item in fibonacciSequence)
            {
                Console.Write("{0} ", item);
            }
        }
    }
}
