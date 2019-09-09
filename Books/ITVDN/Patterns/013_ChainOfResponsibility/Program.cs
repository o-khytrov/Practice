using System;
// Передача запроса по цепочке к обработчкку, который сможет его обработать
// Теоретически преимущество этого паттерна заключается в отсутствии управляющего класса, 
namespace _013_ChainOfResponsibility
{
    internal abstract class Handler
    {
        public Handler Successor { get; set; }

        public abstract void HandleReques(int request);
    }

    internal class ConcreteHandler1 : Handler
    {
        public override void HandleReques(int request)
        {
            if (request == 1)
            {
                Console.WriteLine("One");
            }
            else if (Successor != null)
            {
                Successor.HandleReques(request);
            }
        }
    }

    internal class ConcreteHandler2 : Handler
    {
        public override void HandleReques(int request)
        {
            if (request == 2)
            {
                Console.WriteLine("Two");
            }
            else if (Successor != null)
            {
                Successor.HandleReques(request);
            }
        }
    }

    internal class Program

    {
        private static void Main(string[] args)
        {
            Handler handler1 = new ConcreteHandler1();
            Handler handler2 = new ConcreteHandler2();

            handler1.Successor = handler2;
            handler1.HandleReques(1);
            handler1.HandleReques(2);
            Console.WriteLine();
            Console.ReadKey();

        }
    }
}