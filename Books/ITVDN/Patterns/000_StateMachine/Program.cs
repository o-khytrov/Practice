using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _000_StateMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            var father = new Father();

            father.FindOut(Mark.Two);
            father.FindOut(Mark.Five);
            father.FindOut(Mark.Five);
            father.FindOut(Mark.Five);
            father.FindOut(Mark.Five);

        }
    }
}
