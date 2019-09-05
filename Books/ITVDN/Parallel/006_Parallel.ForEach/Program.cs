using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _006_Parallel.ForEach
{
    class Element
    {
        public int A { get; set; }
    }
    class Program
    {

        static void Main(string[] args)
        {
            IList<Element> elements = new List<Element>();
            Action<int> initialize = i => elements.Add(new Element { A = i });

            Parallel.For(0, 10000, initialize);
            elements[300].A = -1;

            Action<Element, ParallelLoopState> transform = (Element element, ParallelLoopState state) =>
            {
                if (element.A < 0)
                {
                    state.Break();

                }
                Thread.Sleep(1);
                element.A = 111 * 222 * 333 / 444;
            };

            ParallelLoopResult parallelLoopResult = Parallel.ForEach(elements, transform);
            if (!parallelLoopResult.IsCompleted)
            {
                Console.WriteLine("Обход коллекции завершился преждевременно ");
                Console.WriteLine("Элемент {0} имеет отрицательное значение", parallelLoopResult.LowestBreakIteration);
            }
            Console.WriteLine("Main thread finished");

            Console.ReadKey();
        }
    }
}
