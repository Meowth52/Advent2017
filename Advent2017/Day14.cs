using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2017
{
    class Day14
    {
        private string Input;
        private string[] Instructions;
        public bool[,] Grid = new bool[128, 128];
        public Day14(string input)
        {
            Input = input.Replace("\r\n", "");
            Instructions = Input.Split('_');
        }

        public string Result()
        {
            KnotHash RopeKnot;
            int Sum = 0;
            int Sum2 = 0;
            int Position = 0;
            string HexRope;
            string[] Inputs = new string[128];
            for (int i = 0; i <= 127; i++)
            {
                Inputs[i] = Input + "-" + i.ToString();
            }
            foreach (string s in Inputs)
            {
                RopeKnot = new KnotHash(s);
                HexRope = RopeKnot.Result();
                string binarystring = String.Join(String.Empty,
                    HexRope.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
                for (int i = 0; i <= 127; i++)
                {
                    Grid[Position, i] = (binarystring[i] == '1');
                }
                Position++;
                foreach (char c in binarystring)
                {
                    if (c == '1')
                        Sum++;
                }
            }
            for (int x = 0; x <= 127; x++)
            {
                for (int y = 0; y <= 127; y++)
                {
                    if (Grid[x,y])
                    {
                        CheckPosition(new Coordinate(x, y));
                        Sum2++;
                    }
                }
            }
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString();
        }
        public void CheckPosition(Coordinate c)
        {
            Grid[c.X, c.Y] = false;
            if (c.X < 127)
                if (Grid[c.X + 1, c.Y])
                {
                    CheckPosition(new Coordinate(c.X+1, c.Y));
                }
            if (c.Y < 127)
                if (Grid[c.X, c.Y + 1])
                {
                    CheckPosition(new Coordinate(c.X, c.Y+1));
                }
            if (0 < c.X)
                if (Grid[c.X - 1, c.Y])
                {
                    CheckPosition(new Coordinate(c.X-1, c.Y));
                }
            if (0 < c.Y)
                if (Grid[c.X, c.Y-1])
                {
                    CheckPosition(new Coordinate(c.X, c.Y-1));
                }
        }
    }
}