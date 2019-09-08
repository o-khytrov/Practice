using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Скрывает сложную подсистему
namespace Facade
{
    class SubSystemA
    {
        public void OperationA()
        {
            Console.WriteLine("Operation A");
        }
    }
    class SubSystemB
    {
        public void OperationB()
        {
            Console.WriteLine("Operation B");
        }
    }

    class SubSystemC
    {
        public void OperationC()
        {
            Console.WriteLine("Operation C");
        }
    }
    class Facade
    {
        SubSystemA SubSystemA = new SubSystemA();
        SubSystemB SubSystemB = new SubSystemB();
        SubSystemC SubSystemC = new SubSystemC();

        public void OperationAB()
        {
            SubSystemA.OperationA();
            SubSystemB.OperationB();
        }

        public void OperationBC()
        {
            SubSystemB.OperationB();
            SubSystemC.OperationC();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Facade facade = new Facade();
            facade.OperationAB();
            facade.OperationBC();

            Console.ReadKey();
        }
    }
}
