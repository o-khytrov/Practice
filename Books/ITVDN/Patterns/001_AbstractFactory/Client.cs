using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_AbstractFactory
{
    public class Client
    {
        private AbstractWater water;
        private AbstractBottle bottle;
        private AbstractCover cover;
        private AbstractCap cap;
        public Client(AbstractFactory factory)
        {
            water = factory.CreateWater();
            bottle = factory.CreateBottle();
            cap = factory.CreateCap();
            cover = factory.CreateCover();
        }

        public void Run()
        {
            bottle.Interact(water);
            bottle.Interact(cap);
            bottle.Interact(cover);
        }
    }
}
