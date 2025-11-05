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
        private bool[,] _occupied;

        public Grid(int width, int height)
        {
            _width = width;
            _height = height;
            _occupied = new bool[width, height];
        }

        public bool TryMove(MoveEntity entity, Vector2 direction, int steps) 
        {
            return true;
        }
    }
}