using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Advent2017
{
    class Day14
    {
        private string Input;
        private string[] Instructions;
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
                foreach(char c in binarystring)
                {
                    if (c == '1')
                        Sum++;
                }
            }
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString();
        }

    }
}