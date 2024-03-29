﻿namespace _014_Command
{
    class Calculator
    {
        ArithmeticUnit arithmeticUnit;
        ControlUnit controlUnit;
        public Calculator()
        {
            arithmeticUnit = new ArithmeticUnit();
            controlUnit = new ControlUnit();
        }
        private int Run(Command command)
        {
            controlUnit.StoreCommand(command);
            controlUnit.ExecuteCommand(command);
            return arithmeticUnit.Register;
        }
        public int Add(int operand)
        {
            return Run(new Add(arithmeticUnit, operand));
        }

        public int Sub(int operand)
        {
            return Run(new Sub(arithmeticUnit, operand));
        }

        public int Mul(int operand)
        {
            return Run(new Mul(arithmeticUnit, operand));
        }
        public int Div(int operand)
        {
            return Run(new Div(arithmeticUnit, operand));
        }

        public int And(int operand)
        {
            return Run(new And(arithmeticUnit, operand));
        }

        public int Or(int operand)
        {
            return Run(new Or(arithmeticUnit, operand));
        }

        public int Undo(int levels)
        {
            controlUnit.Undo(levels);
            return arithmeticUnit.Register;
        }

        public int Redo(int levels)
        {
            controlUnit.Redo(levels);
            return arithmeticUnit.Register;
        }

    }
}