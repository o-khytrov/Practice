using System;

namespace _011_Flyweight
{ // Паттерн Flyweight
    //Используется для экономии памяти
    //Дает возможножность со помощью наследования представить один и тот же объект в разных ролях
    internal abstract class Flyweight
    {
        public abstract void Greeting(string speech);
    }

    internal class Actor : Flyweight
    {
        public override void Greeting(string speech)
        {
            Console.WriteLine(speech);
        }
    }

    internal class RoleAustinPowers : Flyweight
    {
        private Flyweight flyweight;

        public RoleAustinPowers(Flyweight flyweight)
        {
            this.flyweight = flyweight;
        }

        public override void Greeting(string speech)
        {
            this.flyweight.Greeting(speech);
        }
    }

    internal class RoleDrEvil : Flyweight
    {
        private Flyweight flyweight;

        public RoleDrEvil(Flyweight flyweight)
        {
            this.flyweight = flyweight;
        }

        public override void Greeting(string speech)
        {
            this.flyweight.Greeting(speech);
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var actor = new Actor();
            RoleAustinPowers austinPowers = new RoleAustinPowers(actor);

            austinPowers.Greeting("Hello! I'm Austin Powers");

            RoleDrEvil dr = new RoleDrEvil(actor);

            dr.Greeting("Hello! I'm Dr.Evil");

            Console.ReadKey();
        }
    }
}