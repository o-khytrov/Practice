using System;
using System.Collections;

//Цель паттерна Composite выращивать деревъя
namespace _008_Composite
{
    internal abstract class Component
    {
        protected string name;

        public Component(string name)
        {
            this.name = name;
        }

        public abstract void Operation();

        public abstract void Add(Component component);

        public abstract void Remove(Component component);

        public abstract Component GetChild(int index);
    }

    internal class Leaf : Component
    {
        public Leaf(string name) : base(name)
        {
        }

        public override void Add(Component component)
        {
            throw new InvalidOperationException();
        }

        public override Component GetChild(int index)
        {
            throw new InvalidOperationException();
        }

        public override void Remove(Component component)
        {
            throw new InvalidOperationException();
        }

        public override void Operation()
        {
            Console.WriteLine(name);
        }
    }

    internal class Composite : Component
    {
        private ArrayList nodes = new ArrayList();

        public Composite(string name) : base(name)
        {
        }

        public override void Add(Component component)
        {
            nodes.Add(component);
        }

        public override Component GetChild(int index)
        {
            return nodes[index] as Component;
        }

        public override void Operation()
        {
            Console.WriteLine(name);
            foreach (Component node in nodes)
            {
                node.Operation();
            }
        }

        public override void Remove(Component component)
        {
            nodes.Remove(component);
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Component root = new Composite("ROOT");
            Component branch1 = new Composite("BR1");
            Component branch2 = new Composite("BR2");
            Component leaf1 = new Composite("L1");
            Component leaf2 = new Composite("L2");

            root.Add(branch1);
            root.Add(branch2);
            branch1.Add(leaf1);
            branch2.Add(leaf2);
            root.Operation();
            Console.ReadKey();


        }
    }
}