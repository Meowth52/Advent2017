using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2017
{
    class Turing
    {
        string[] RawInstructions;
        char StateName;
        bool[] WriteValue = new bool[2];
        bool[] DirectionIsRight = new bool[2];
        char[] NextState = new char[2];
        public Turing(string input)
        {
            RawInstructions = input.Replace("\r\n", "_").Split('_');
            StateName = RawInstructions[0][0];
            WriteValue[0] = (RawInstructions[2][22] == '1');
            WriteValue[1] = (RawInstructions[6][22] == '1');
            DirectionIsRight[0] = RawInstructions[3].Contains("right");
            DirectionIsRight[1] = RawInstructions[7].Contains("right");
            NextState[0] = RawInstructions[4][26];
            NextState[1] = RawInstructions[8][26];
        }
        public char GetName()
        {
            return StateName;
        }
        public int GetDirection(bool value)
        {
            if (value)
            {
                if (DirectionIsRight[1])
                    return 1;
                else
                    return -1;
            }
            else
            {
                if (DirectionIsRight[0])
                    return 1;
                else
                    return -1;
            }
        }
        public bool GetWriteValue(bool value)
        {
            if (value)
            {
                return WriteValue[1];
            }
            else
            {
                return WriteValue[0];
            }
        }
        public char GetNextState(bool value)
        {
            if (value)
            {
                return NextState[1];
            }
            else
            {
                return NextState[0];
            }
        }
    }
}
