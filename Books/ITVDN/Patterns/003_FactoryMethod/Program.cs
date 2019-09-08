using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_FactoryMethod
{
    public abstract class Product
    {

    }
    public abstract class Creator
    {
        public abstract Product FactoryMethod();
    }

    public class ConcreteProduct : Product
    {
        public ConcreteProduct()
        {
            Console.WriteLine(this.GetType().Name + " " + this.GetHashCode());
        }

    }
    public class ConcreteCreator : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProduct();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var creator = new ConcreteCreator();
            var product = creator.FactoryMethod();

            Console.ReadKey();
        }
    }
}
