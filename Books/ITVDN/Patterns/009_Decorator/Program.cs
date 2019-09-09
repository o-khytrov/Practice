using System;

namespace _009_Decorator
{
    // Wrapper
    // Работает как обертка над классом, предоставляя его новые возможности

    public abstract class Component
    {
        public abstract void Operation();
    }

    public abstract class Decorator : Component
    {
        public Component Component { protected get; set; }

        public override void Operation()
        {
            if (Component != null)
            {
                Component.Operation();
            }
        }
    }

    public class ConcreteComponent : Component
    {
        public override void Operation()
        {
            Console.WriteLine("Concrete component");
        }
    }

    public class ConcreteDecoratorA : Decorator
    {
        private string addedState = "Some state";

        public override void Operation()
        {
            base.Operation();
            Console.WriteLine(addedState);
        }
    }

    public class ConcreteDecoratorB : Decorator
    {
        private void AddedBehavior()
        {
            Console.WriteLine("Behavior");
        }

        public override void Operation()
        {
            base.Operation();
            AddedBehavior();
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Component component = new ConcreteComponent();
            Decorator decoratorA = new ConcreteDecoratorA();
            Decorator decoratorB = new ConcreteDecoratorB();

            decoratorA.Component = component;
            decoratorB.Component = decoratorA;

            decoratorB.Operation();

            Console.ReadKey();
        }
    }
}