using System;

namespace _000_StateMachine
{
    internal class StrongJoyState : State
    {
        internal StrongJoyState() { Console.WriteLine("Отец в состоянии сильной радости:"); Exult(); }
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
        private void Exult() // y5
        { Console.WriteLine("Ликует и гордится сыном."); }
    }
}
