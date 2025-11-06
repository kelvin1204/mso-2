using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using mso_3;

namespace mso_2.Commands
{
    public interface ICommand
    {
        string Execute(MoveEntity entity);
    }

    internal class MoveCommand : ICommand
    {
        private int _steps;
        public MoveCommand(int steps) => _steps = steps;
        public string Execute(MoveEntity entity) => entity.Move(_steps);
    }
    public enum TurnDirection
    {
        Left,
        Right
    }
    internal class TurnCommand : ICommand
    {
        private TurnDirection _turnDirection;
        public TurnCommand(TurnDirection turnDirection) => _turnDirection = turnDirection;
        public string Execute(MoveEntity entity) => entity.Turn(_turnDirection);
    }

    internal class CompositeCommand : ICommand
    {
        public readonly List<ICommand> _commands = new List<ICommand>();

        public void Add(ICommand command) => _commands.Add(command);

        public string Execute(MoveEntity entity)
        {
            entity.ResetLastPositions();

            string result = "";

            foreach (var command in _commands)
                result += command.Execute(entity) + ", ";

            return result.TrimEnd(',', ' ') + ".";
        }
    }
    internal class RepeatCommand : ICommand
    {
        public readonly List<ICommand> _commands = new List<ICommand>();
        public readonly int _times;

        public RepeatCommand(int times) => _times = times;

        public void Add(ICommand command) => _commands.Add(command);

        public string Execute(MoveEntity entity)
        {
            string result = "";

            for (int i = 0; i < _times; i++)
            {
                foreach (var command in _commands)
                    result += command.Execute(entity) + ", ";
            }

            return result.TrimEnd(',', ' ');
        }
    }
}
