using System.Collections.Generic;

namespace _014_Command
{
    internal class ControlUnit
    {
        private List<Command> commands = new List<Command>();
        private int current = 0;
        internal void ExecuteCommand(Command command)
        {
            commands[current].Execute();
            current++;
        }



        internal void StoreCommand(Command command)
        {
            commands.Add(command);

        }

        internal void Undo(int levels)
        {
            for (int i = 0; i < levels; i++)
            {
                if (current > 0)
                {
                    commands[--current].UnExecute();
                }
            }
        }

        internal void Redo(int levels)
        {
            for (int i = 0; i < levels; i++)
            {
                if (current < commands.Count - 1)
                {
                    commands[current++].UnExecute();
                }
            }
        }
    }
}