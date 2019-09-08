using System;

namespace _000_StateMachine
{
    // Состояние радости (S3)
    internal class JoyState : State
    {
        internal JoyState() { Console.WriteLine("Отец в состоянии радости:"); Joy(); }
        protected override void ChangeState(Father father, Mark mark)
        {
            switch (mark)
            {
                case Mark.Two:
                    {
                        father.State = new PityState(); // S1
                        break;
                    }
                case Mark.Five:
                    {
                        father.State = new StrongJoyState(); // S5
                        break;
                    }
            }

        }
        private void Joy() // y4 
        { Console.WriteLine("Радуется успехам сына."); }
    }
}
