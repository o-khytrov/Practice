using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _012_TPL_Exception
{
    class Program
    {
        static void MyTask()
        {
            Console.WriteLine("Task is launched");
            throw new Exception();
            Console.WriteLine("Task is completed");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread is launched");
            Task task = new Task(MyTask);

            try
            {
                task.Start();
                //task.Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception " + ex.GetType()); ;
                Console.WriteLine("Exception " + ex.Message);
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception " + ex.InnerException);
                }

            }
            finally
            {
                Console.WriteLine("Status of the task: " + task.Status);
            }

            Console.WriteLine("Main thread is finished");
        }
    }
}
