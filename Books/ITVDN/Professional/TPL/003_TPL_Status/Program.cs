using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _003_TPL_Status
{
    class Program
    {
        static void MyStatus()
        {
            Thread.Sleep(3000);
        }

        static void Main(string[] args)
        {
            Task task = new Task(MyStatus);

            Console.WriteLine("1. " + task.Status);

            task.Start();

            Console.WriteLine("2. " + task.Status);

            Thread.Sleep(1000);
            Console.WriteLine("3. " + task.Status);

            Thread.Sleep(3000);
            Console.WriteLine("4. " + task.Status);

            Console.ReadKey();


        }
    }
}
