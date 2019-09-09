namespace _014_Command
{
    internal class ArithmeticUnit
    {
        public int Register { get; internal set; }

        internal void Run(char operatinCode, int operand)
        {
            switch (operatinCode)
            {
                case '+':
                    Register += operand;
                    break;
                case '-':
                    Register -= operand;
                    break;
                case '*':
                    Register *= operand;
                    break;
                case '/':
                    Register /= operand;
                    break;
                case '&':
                    Register = Register & operand;
                    break;
                case '|':
                    Register = Register | operand;
                    break;

            }
        }
    }
}