using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using mso_2;

namespace mso_3
{
    public class MoveEntity
    {
        public Vector2 direction;
        public Vector2 position;
        private Grid grid;

        public MoveEntity(Vector2 Direction, Vector2 Position, Grid _grid)
        {
            direction = Direction;
            position = Position;
            grid = _grid;
        }

        public string Turn(TurnDirection turnDirection)
        {
            if (turnDirection == TurnDirection.Right)
            {
                direction = new Vector2(-direction.Y, direction.X);
                return "Turn right";
            }

            else
            {
                direction = new Vector2(direction.Y, -direction.X);
                return "Turn left";
            }
        }

        public string Move(int steps)
        {
            position += direction * steps;
            return "Move " + steps.ToString();
        }

        public string GetStatusString() 
        {
            return "End state " + position.ToString() + " facing "+ GetStringDirection() + ".";
        }

        private string GetStringDirection()
        {
            var key = (direction.X, direction.Y);
            switch (key)
            {
                case (1, 0): return "north";
                case (0, 1): return "east";
                case (-1, 0): return "south";
                case (0, -1): return "west";

                default: return "";
            }
        }
    }
}
