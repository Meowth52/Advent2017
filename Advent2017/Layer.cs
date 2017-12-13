using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2017
{
    class Layer //Schmenum
    {
        int Depth;
        int Position;
        int Direction = 1;
        public Layer(int depth)
        {
            Depth = depth;
            Position = 1;
        }
        public int getPosition()
        {
            return Position;
        }
        public void Move()
        {
            Position += Direction;
            if (Position == Depth || Position == 1)
                Direction *= -1;
        }
        public int getDepth()
        {
            return Depth;
        }
        public void Initiate(int i)
        {
            Position = i%Depth+1;
            Direction = (i/(Depth))%2;
            if (Direction == 0)
            {
                Direction = -1;
                Position = Depth - Position;
            }
        }
    }
}
