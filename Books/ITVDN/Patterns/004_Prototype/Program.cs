namespace _004_Prototype
{
    public abstract class Prototype
    {
        public int Id { get; private set; }

        public Prototype(int id)
        {
            this.Id = id;
        }

        public abstract Prototype Clone();
    }

    public class ConcretePrototype1 : Prototype
    {
        public ConcretePrototype1(int id) : base(id)
        {
        }

        public override Prototype Clone()
        {
            return new ConcretePrototype1(Id);
        }
    }

    public class ConcretePrototype2 : Prototype
    {
        public ConcretePrototype2(int id) : base(id)
        {
        }

        public override Prototype Clone()
        {
            return this.MemberwiseClone() as Prototype ;
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Prototype prototype = null;
            Prototype clone = null;

            prototype = new ConcretePrototype1(1);
            clone = prototype.Clone();

            prototype = new ConcretePrototype2(1);
            clone = prototype.Clone();


        }
    }
}