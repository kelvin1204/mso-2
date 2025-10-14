using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mso_2
{
    internal interface ExampleInputs
    {
        ICommand GetCommand();
    }

    internal class BasicProgram() 
    {
        public ICommand GetCommand() 
        {
            CompositeCommand compCommand = new CompositeCommand();
            compCommand.Add(new MoveCommand(10));
            compCommand.Add(new TurnCommand(TurnDirection.Right));
            compCommand.Add(new MoveCommand(5));
            compCommand.Add(new TurnCommand(TurnDirection.Left));

            return compCommand;
        }
    }
}
