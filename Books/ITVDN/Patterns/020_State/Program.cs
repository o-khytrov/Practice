using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _020_State
{
    //Описывать способы построение программных объектно - ориентированных конечных автоматов

    abstract class State
    {
        public abstract void Handle(Context context);
    }

    class StateA : State
    {
        public override void Handle(Context context)
        {
            context.State = new StateB();
        }
    }

    class StateB : State
    {
        public override void Handle(Context context)
        {
            context.State = new StateA();
        }
    }


    class Context
    {
        public State State { get; set; }

        public Context(State state)
        {
            this.State = state;
        }
        public void Request()
        {
            Console.WriteLine("Current state is " + State.GetType().Name);
            this.State.Handle(this);
            Console.WriteLine("Switched to state  " + State.GetType().Name);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context(new StateA());
            context.Request();
            context.Request();
        }
    }
}
