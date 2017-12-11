using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2017
{
    class Day11
    {
        private string Input;
        private string[] Instructions;
        public Day11(string input)
        {
            Input = input.Replace("\r\n", "");
            Instructions = Input.Split(',');
        }

        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            Coordinate LittleTimmy = new Coordinate(0, 0);
            foreach(string s in Instructions)
            {
                LittleTimmy.Add(StringToCoordinate(s));
                if (Sum2 < getDistance(LittleTimmy))
                    Sum2 = getDistance(LittleTimmy);
            }
            Sum = getDistance(LittleTimmy);
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString();
        }
        public int getDistance(Coordinate c)
        {
            Coordinate C = c.getPositive();
            int ReturnValue = C.X + (((C.Y - C.X) + 1) / 2);
            return ReturnValue;
        }
        public Coordinate StringToCoordinate(string s)
        {
            int X = 0;
            int Y = 0;
            if (s.First() == 'n')
                Y++;
            if (s.First() == 's')
                Y--;
            if (s.Last() == 'n')
                Y++;
            if (s.Last() == 's')
                Y--;
            if (s.Last() == 'e')
                X++;
            if (s.Last() == 'w')
                X--;
            return new Coordinate(X, Y);
        }
        
    }
}
