using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006_Adapter
{
    interface ITarget
    {
        void Request();
    }
    public class Adaptee
    {
        protected void SpecificRequest()
        {
            Console.WriteLine("Specific Request");
        }
    }

    public class Adapter : Adaptee, ITarget
    {
        public void Request()
        {
            SpecificRequest();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ITarget target = new Adapter();
            target.Request();

            Console.ReadKey();
        }
    }
}
