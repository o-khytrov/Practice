namespace _002_Builder
{
    public class ConcreteBuilder : Builder
    {
        House house = new House();
        public override void BuildBasement()
        {
            house.Add(new Basement());
        }

        public override void BuildRoof()
        {
            house.Add(new Roof());
        }

        public override void BuildStorey()
        {
            house.Add(new Storey());
        }

        public override House GetResult()
        {
            return house;
        }
    }
}
