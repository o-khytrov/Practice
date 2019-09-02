using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _014_TPL_ContinuationOptions
{
    class Program
    {
        static int MyTask()
        {
            byte result = 255;

            //checked
            {
                result += 1;
            }
            return result;
        }
        static void Main(string[] args)
        {
            Task<int> task = new Task<int>(MyTask);
        }
    }
}
