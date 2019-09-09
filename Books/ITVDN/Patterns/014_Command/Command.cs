namespace _014_Command
{
    // Предоставляет объектно ориентированное представление запроса
    //Используется для undo

    internal abstract class Command
    {
        protected ArithmeticUnit unit;
        protected int operand;

        public abstract void Execute();

        public abstract void UnExecute();
    }
}