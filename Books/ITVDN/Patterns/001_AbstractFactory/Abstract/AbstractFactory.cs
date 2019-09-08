namespace _001_AbstractFactory
{
    public abstract class AbstractFactory
    {
        public abstract AbstractBottle CreateBottle();
        public abstract AbstractCover CreateCover();
        public abstract AbstractWater CreateWater();
        public abstract AbstractCap CreateCap();

    }
}
