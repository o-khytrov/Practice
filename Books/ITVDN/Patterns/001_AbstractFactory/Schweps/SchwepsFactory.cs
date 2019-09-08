using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_AbstractFactory
{
    public class SchwepsWater : AbstractWater { }
    public class SchwepsCap : AbstractCap { }
    public class SchwepsCover : AbstractCover { }
    public class SchwepsBottle : AbstractBottle
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

    class SchwepsFactory : AbstractFactory
    {
        public override AbstractBottle CreateBottle()
        {
            return new SchwepsBottle();
        }

        public override AbstractCap CreateCap()
        {
            return new SchwepsCap();
        }

        public override AbstractCover CreateCover()
        {
            return new SchwepsCover();
        }

        public override AbstractWater CreateWater()
        {
            return new SchwepsWater();
        }
    }
}
