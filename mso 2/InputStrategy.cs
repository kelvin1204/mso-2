using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace mso_2
{
    internal interface IInputStrategy
    {
        ICommand Read();
    }

    internal class ExampleInput : IInputStrategy
    {
        public ICommand Read() 
        {
            Console.WriteLine("Choose: beginner/intermediate/advanced");

            return (Console.ReadLine()) switch
            {
                "beginner" => new BasicProgram().GetCommand(),
                "intermediate" => new IntermediateProgram().GetCommand(),
                "advanced" => new AdvancedProgram().GetCommand(),
                _ => throw new ArgumentException("Unknown input type")
            };
        }
    }

    internal class FileInput : IInputStrategy
    {
        public ICommand Read() 
        {
            Console.WriteLine("Write filename: ");
            string fileName = Console.ReadLine();

            ReadFile(fileName);
            return command;
        }

        CompositeCommand command;
        List<RepeatCommand> nestedCommands;

        public FileInput() 
        {
            command = new CompositeCommand();
            nestedCommands = new List<RepeatCommand>();
        }

        private void ReadFile(string fileName)
        {
            if (!File.Exists(fileName))
                throw new ArgumentException("File does not exist");

            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    ProcessLine(line);
                }
            }
        }

        internal void ProcessLine(string line) 
        {
            int lineIndenation = CountIndentation(line);
            int lineNestDepth = lineIndenation / 4;
            int nests = nestedCommands.Count;

            String[] lineArgs = line.Substring(lineIndenation).Split(" ");

            ICommand lineCommand;

            switch (lineArgs[0]) 
            {
                case "Move": lineCommand = ProcessMove(lineArgs[1]); break;
                case "Repeat": lineCommand = ProcessRepeat(lineArgs[1]); break;
                case "Turn": lineCommand = ProcessTurn(lineArgs[1]); break;
                default: throw new ArgumentException("Unknown input command");
            }

            if (lineIndenation == 0)
                command.Add(lineCommand);

            else if (lineNestDepth < nests) 
            {
                Console.WriteLine(line);
                Console.WriteLine(lineNestDepth.ToString());
                nestedCommands = nestedCommands[..^(nests - lineNestDepth)];
            }

            else if (lineArgs[0] == "Repeat") 
                nestedCommands[^2].Add(lineCommand);
            
            else
                nestedCommands[^1].Add(lineCommand);
        }

        private ICommand ProcessMove(string steps) 
        {
            try
            {
                return new MoveCommand(int.Parse(steps));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Invalid amount of steps");
            }
        }

        private ICommand ProcessTurn(string direction)
        {
            if (direction == "left")
                return new TurnCommand(TurnDirection.Left);

            else if (direction == "right")
                return new TurnCommand(TurnDirection.Right);

            else
                throw new ArgumentException("Invalid direction");
        }

        private ICommand ProcessRepeat(string steps)
        {
            try
            {
                RepeatCommand repeat = new RepeatCommand(int.Parse(steps));
                nestedCommands.Add(repeat);
                return repeat;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Invalid amount of steps");
            }
        }

        private int CountIndentation(string text)
        {
            int count = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                    count++;
                else
                    break;
            }

            return count;
        }
    }
}
