using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2017
{
    class Coordinate
    {
        private int x;
        private int y;

        public int X { get { return x; } }
        public int Y { get { return y; } }

        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return string.Format("{0},{1}", X, Y);
        }
        public void Add(Coordinate A)
        {
            x += A.X;
            y += A.Y;
        }
        public Coordinate getPositive()
        {
            int returnX=x;
            int returnY=y;
            if (x < 0)
                returnX = x * -1;
            if (y < 0)
                returnY = y * -1;
            return new Coordinate(returnX, returnY);
        }
    }
}
