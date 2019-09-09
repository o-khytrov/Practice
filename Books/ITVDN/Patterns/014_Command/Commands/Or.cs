namespace _014_Command
{
    internal class Or : Command
    {
        private ArithmeticUnit arithmeticUnit;

        public Or(ArithmeticUnit arithmeticUnit, int operand)
        {
            this.arithmeticUnit = arithmeticUnit;
            this.operand = operand;
        }

        public override void Execute()
        {
            unit.Run('|', operand);
        }

        public override void UnExecute()
        {
            unit.Run('&', operand);
        }
    }
}