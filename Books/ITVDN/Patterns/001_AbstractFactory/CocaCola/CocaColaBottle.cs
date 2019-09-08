using System;

namespace _001_AbstractFactory
{
    public class CocaColaBottle : AbstractBottle
    {
        public override void Interact(AbstractWater water)
        {
            Console.WriteLine(this.GetType().Name + " interacts with " + water.GetType().Name);
        }

        public override void Interact(AbstractCover cover)
        {
            Console.WriteLine(this.GetType().Name + " interacts with " + cover.GetType().Name);
        }

        public override void Interact(AbstractCap cap)
        {
            Console.WriteLine(this.GetType().Name + " interacts with " + cap.GetType().Name);
        }
    }
}
