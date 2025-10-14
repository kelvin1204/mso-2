using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mso_2
{
    internal interface ExamplePrograms
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

    internal class IntermediateProgram()
    {
        public ICommand GetCommand()
        {
            CompositeCommand compCommand = new CompositeCommand();
            compCommand.Add(new MoveCommand(15));
            compCommand.Add(new TurnCommand(TurnDirection.Left));

            RepeatCommand repeatCommand = new RepeatCommand(3);
            repeatCommand.Add(new MoveCommand(5));
            repeatCommand.Add(new TurnCommand(TurnDirection.Left));
            compCommand.Add(repeatCommand);

            return compCommand;
        }
    }
    internal class AdvancedProgram()
    {
        public ICommand GetCommand()
        {
            CompositeCommand compCommand = new CompositeCommand();
            compCommand.Add(new MoveCommand(25));
            compCommand.Add(new TurnCommand(TurnDirection.Right));

            RepeatCommand repeatCommand = new RepeatCommand(2);
            repeatCommand.Add(new TurnCommand(TurnDirection.Right));
            compCommand.Add(repeatCommand);

            RepeatCommand repeatCommand2 = new RepeatCommand(3);
            repeatCommand2.Add(new MoveCommand(5));
            repeatCommand2.Add(new TurnCommand(TurnDirection.Left));
            repeatCommand.Add(repeatCommand2);

            return compCommand;
        }
    }
}
