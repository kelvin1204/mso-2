using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using mso_3;

namespace mso_2
{
    public class Grid
    {
        private int _width;
        private int _height;
        public bool[,] _occupied { get; set; }

        public Vector2 goal;

        public Grid(int width, int height)
        {
            _width = width;
            _height = height;
            _occupied = new bool[width, height];
        }
        public void SwitchOccupied(int x, int y) 
        {
            //switch the boolean value in the occupied grid at the location xy
            this._occupied[x, y] = !this._occupied[x, y];
        }

        public static Grid ImportOccupied()
        {
            ///for now hardread the path from example.txt
            ///later make it read from a file given by the user
            string path = "C:\\Users\\storm\\Documents\\GitHub\\mso-2\\mso 2\\example.txt";
            string[] lines = System.IO.File.ReadAllLines(path);
            int width = lines[0].Length;
            int height = lines.Length;
            Grid grid = new Grid(width, height);
            bool[,] occupied = new bool[width, height];
            Vector2 goal = new Vector2(0, 0);
            //parse the lines into the occupied grid
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    switch (lines[y][x])
                    {
                        case '+':
                            occupied[x, y] = true;
                            break;
                        case 'o':
                            occupied[x, y] = false;
                            break;
                        case 'x':
                            goal = new Vector2(x, y);
                            occupied[x, y] = false;
                            break;
                        default:
                            throw new ArgumentException("Invalid character in input file");
                    }
                }
            }
            grid._occupied = occupied;
            grid.goal = goal;
            return grid;
        }

        public bool TryMove(MoveEntity entity, int steps)
        {   
            return true;
        }
        //find the position ahead of the moveentity, and see if it is occupied
        public bool CheckAhead(MoveEntity entity)
        {
            Vector2 ahead = entity.position + entity.direction;
            //we want it to return true if the position ahead is unoccupied (occupied is false) and within bounds
            return (!_occupied[(int)ahead.X, (int)ahead.Y] && CheckBounds(ahead));
        }
        //check if the given position is within the grid bounds
        public bool CheckBounds(Vector2 position)
        {
            return (position.X <= _width && position.Y <= _height);
        }
    }
}