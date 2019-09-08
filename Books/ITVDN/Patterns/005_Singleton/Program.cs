using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005_Singleton
{
    class Singleton
    {
        static Singleton uniqueInstance;
        string singletonData = string.Empty;

        protected Singleton()
        {

        }

        public static Singleton Instance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new Singleton();
            }

            return uniqueInstance;

        }
        public void SingletonOperation()
        {
            singletonData = "SingletonData";
        }

        public string GetSingletonData()
        {
            return singletonData;
        }

    }
    class Program
    {

        static void Main(string[] args)
        {
            var single = Singleton.Instance();
            single.SingletonOperation();
            Console.WriteLine(single.GetSingletonData());
            Console.ReadKey();
        }
    }
}
