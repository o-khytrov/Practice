using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _015_Interpreter
{
    abstract class AbstractExpression
    {
        public abstract void Interpret(Context context);
    }
    class TerminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            context.Result = context.Source[context.Position] == context.Vocabulary;
        }
    }

    class NonTerminalExpression : AbstractExpression
    {
        AbstractExpression nonTerminalExpression;
        AbstractExpression terminalExpression;

        public override void Interpret(Context context)
        {
            if (context.Position < context.Source.Length)
            {
                terminalExpression = new TerminalExpression();
                terminalExpression.Interpret(context);
                context.Position++;
                if (context.Result)
                {
                    nonTerminalExpression = new NonTerminalExpression();
                    nonTerminalExpression.Interpret(context);
                }
            }

        }
    }

    class Context
    {
        public string Source { get; set; }
        public char Vocabulary { get; set; }
        public bool Result { get; set; }
        public int Position { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context
            {
                Vocabulary = 'a',
                Source = "aaa"
            };

            var expression = new NonTerminalExpression();
            expression.Interpret(context);
            Console.WriteLine(context.Result);

            Console.ReadKey();
        }
    }
}
