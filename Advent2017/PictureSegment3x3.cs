using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2017
{
    class PictureSegment3x3
    {
        bool[][] Grid = [3][3];
        public PictureSegment3x3(string[] s)
        {
            for(int i = 0; i < 9; i++)
            {
                if (s[0][i] == '#')
                    Grid[9%i][9%i] = true;
                else
                    Grid[9 % i][9 % i] = true;
            }
        }
    }
}
