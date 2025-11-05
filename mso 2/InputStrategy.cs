using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.LinkLabel;

namespace mso_2
{
    internal interface IInputStrategy
    {
        ICommand Read();
    }

    internal class ExampleInput : IInputStrategy
    {
        string example;
        public ExampleInput(string[] input) 
        {
            example = input[0];
        }
        public ICommand Read() 
        {
            Console.WriteLine("Choose: beginner/intermediate/advanced");

            return (example) switch
            {
                "beginner" => new BasicProgram().GetCommand(),
                "intermediate" => new IntermediateProgram().GetCommand(),
                "advanced" => new AdvancedProgram().GetCommand(),
                _ => throw new ArgumentException("Unknown input type")
            };
        }
    }

    internal class StringInput : IInputStrategy 
    {
        protected CompositeCommand command;
        protected List<RepeatCommand> nestedCommands;

        string[] lines = null;
        public StringInput(string[] Lines)
        {
            this.lines = Lines;
            command = new CompositeCommand();
            nestedCommands = new List<RepeatCommand>();
        }
        public virtual ICommand Read() 
        {
            if (lines != null)
                foreach (string line in lines)
                    ProcessLine(line);

            return command; 
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

    internal class FileInput : StringInput
    {
        string filePath = null;

        public FileInput(string[] Lines) : base(Lines)
        {
            this.filePath = Lines[0];
        }
        public override ICommand Read() 
        {
            ReadFile(filePath);
            return command;
        }

        public void SetFilePath(string FilePath) 
        {
            filePath = FilePath;
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
    }
}
