using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_PLINQ
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] array = new int[100000000];

            Parallel.For(0, 100000000, i => array[i] = i);

            array[1000] = -1;
            array[14000] = -2;
            array[15000] = -3;
            array[67600] = -4;
            array[8024540] = -5;
            array[9908000] = -6;
            ParallelQuery<int> negatives = array.AsParallel().AsOrdered().Where(x => x < 0);

            foreach (var element in negatives)
            {
                Console.WriteLine(element + " ");
            }

        }

    }
}
