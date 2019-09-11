using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _017_Mediator
{
    //Организует взаимодействие объектов, участвующих в общем процессе
    //Собирает в одном месте бизнесс логику
    //Устраняет связанность между объектами
    //Цетрализует управление

    abstract class Colleague
    {
        protected Mediator mediator;

        public Colleague(Mediator mediator)
        {
            this.mediator = mediator;
        }
    }

    class Cannery : Colleague
    {
        public Cannery(Mediator mediator) : base(mediator)
        {

        }
        public void MakeKetchup(string message)
        {
            string ketchup = "ketchup";
            Console.WriteLine(this.GetType().Name+ " produced " + ketchup);
            mediator.Send(ketchup, this);
        }
    }

    class Shop : Colleague
    {
        public Shop(Mediator mediator) : base(mediator)
        {

        }
        public void SellKetchup(string message)
        {
            Console.WriteLine(this.GetType().Name + " sold " + message);
        }

    }
    class Farmer : Colleague
    {
        public Farmer(Mediator mediator) : base(mediator)
        {

        }

        public void GrowTomato()
        {
            string tomato = "tomato";
            Console.WriteLine(this.GetType().Name + " raised " + tomato);
            mediator.Send(tomato, this);
        }
    }
    abstract class Mediator
    {
        public abstract void Send(string msg, Colleague colleague);
    }

    class ConcreteMediator : Mediator
    {
        public Farmer Farmer { get; set; }
        public Cannery Cannery { get; set; }
        public Shop Shop { get; set; }
        public override void Send(string msg, Colleague colleague)
        {
            if (colleague == Farmer)
            {
                Cannery.MakeKetchup(msg);
            }
            else if (colleague == Cannery)
            {
                Shop.SellKetchup(msg);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {


            var mediator = new ConcreteMediator();
            var farmer = new Farmer(mediator);
            var cannery = new Cannery(mediator);
            var shop = new Shop(mediator);
            mediator.Farmer = farmer;
            mediator.Cannery = cannery;
            mediator.Shop = shop;
            farmer.GrowTomato();

            Console.ReadKey();
        }
    }
}
