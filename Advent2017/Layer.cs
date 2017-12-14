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
        public bool WillItCatch(int i)
        {
            int ehhh = (i - 1) % ((Depth - 1) * 2) + 1; //Jag orkar inte komma på variabelnamn på nattskiftet
            if (ehhh > Depth)
                ehhh -= Depth - (ehhh - Depth);
            return ehhh == 1;
        }
    }
}
