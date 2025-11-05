using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using mso_3;

namespace mso_2
{
    internal class Grid
    {
        private int _width;
        private int _height;
        public bool[,] _occupied { get; set; }

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

        public void ImportOccupied() 
        { 
            //dunno what we wanna do for reading in files yet 
            //todo
        }

        public bool TryMove(MoveEntity entity, int steps) 
        {
            for (int i = 0; i < steps; i++)
            {
                if (CheckAhead(entity)) 
                { 
                    
                }
            }
            return true;
        }
        //find the position ahead of the moveentity, and see if it is occupied
        public bool CheckAhead(MoveEntity entity) 
        {
            Vector2 ahead = entity.position + entity.direction;
            return (_occupied[(int)ahead.X, (int)ahead.Y]&&CheckBounds(ahead));     
        }
        public bool CheckBounds(Vector2 position)
        {
            return (position.X <= _width && position.Y <= _height);
        }
    }
}