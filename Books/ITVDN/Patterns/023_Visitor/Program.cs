using System;
using System.Collections;

namespace _023_Visitor
{
    //Образует обход набора объектов с разнородными интерфейсами

    public abstract class Visitor
    {
        public abstract void VisitBoysHouse(BoysHouse boysHouse);

        public abstract void VisitGirlsHouse(GirlsHouse boysHouse);
    }

    public class BoysHouse : Element
    {
        public override void Accept(Visitor visitor)
        {
            visitor.VisitBoysHouse(this);
        }

        internal void TellFairyTale()
        {
            Console.WriteLine("Fairy Tale...");
        }
    }

    public class GirlsHouse : Element
    {
        public override void Accept(Visitor visitor)
        {
            visitor.VisitGirlsHouse(this);
        }

        internal void GiveDress()
        {
            Console.WriteLine("Dress as a gift");
        }
    }

    internal class Santa : Visitor
    {
        public override void VisitBoysHouse(BoysHouse boysHouse)
        {
            boysHouse.TellFairyTale();
        }

        public override void VisitGirlsHouse(GirlsHouse girlsHouse)
        {
            girlsHouse.GiveDress();
        }
    }

    public abstract class Element
    {
        public abstract void Accept(Visitor visitor);
    }

    internal class Village
    {
        private ArrayList elements = new ArrayList();

        public void Add(Element element)
        {
            elements.Add(element);
        }

        public void Remove(Element element)
        {
            elements.Remove(element);
        }

        public void Accept(Visitor visitor)
        {
            foreach (Element element in elements)
            {
                element.Accept(visitor);
            }
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var village = new Village();
            village.Add(new BoysHouse());
            village.Add(new GirlsHouse());
            village.Accept(new Santa());

            Console.ReadKey();
        }
    }
}