namespace _001_AbstractFactory
{
    public abstract class AbstractBottle
    {
        public abstract void Interact(AbstractWater water);
        public abstract void Interact(AbstractCover cover);

        public abstract void Interact(AbstractCap cap);

    }
}
