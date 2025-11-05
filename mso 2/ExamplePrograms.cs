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
            compCommand.Add(new MoveCommand(10));
            compCommand.Add(new TurnCommand(TurnDirection.Right));
            compCommand.Add(new MoveCommand(10));
            compCommand.Add(new TurnCommand(TurnDirection.Right));
            compCommand.Add(new MoveCommand(10));
            compCommand.Add(new TurnCommand(TurnDirection.Right));

            return compCommand;
        }
    }

    internal class IntermediateProgram()
    {
        public ICommand GetCommand()
        {
            CompositeCommand compCommand = new CompositeCommand();

            RepeatCommand repeatCommand = new RepeatCommand(4);
            compCommand.Add(new MoveCommand(10));
            compCommand.Add(new TurnCommand(TurnDirection.Right));
            compCommand.Add(repeatCommand);

            return compCommand;
        }
    }
    internal class AdvancedProgram()
    {
        public ICommand GetCommand()
        {
            CompositeCommand compCommand = new CompositeCommand();
            compCommand.Add(new MoveCommand(5));
            compCommand.Add(new TurnCommand(TurnDirection.Left));
            compCommand.Add(new TurnCommand(TurnDirection.Left));
            compCommand.Add(new MoveCommand(3));
            compCommand.Add(new TurnCommand(TurnDirection.Right));

            RepeatCommand repeatCommand = new RepeatCommand(3);
            compCommand.Add(new MoveCommand(1));
            compCommand.Add(new TurnCommand(TurnDirection.Right));
            compCommand.Add(repeatCommand);

            RepeatCommand repeatCommand2 = new RepeatCommand(5);
            repeatCommand2.Add(new MoveCommand(2));
            repeatCommand.Add(repeatCommand2);
            compCommand.Add(new TurnCommand(TurnDirection.Left));

            return compCommand;
        }
    }
}
