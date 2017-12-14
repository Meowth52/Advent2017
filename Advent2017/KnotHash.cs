using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2017
{
    class KnotHash
    {
        private string Input;
        int[] RopeKnot2 = new int[256];
        public KnotHash(string input)
        {
            Input = input.Replace("\r\n", "");
            for (int i = 0; i <= 255; i++)
            {
                RopeKnot2[i] = i;
            }
        }
        public string Result()
        {
            string Sum2 = "";
            int SkipSize = 0;
            int CurrentPosition = 0;
            int IteratorInt;
            List<int> TurnList = new List<int>();
            int[] DenseHash = new int[16];
            List<int> InstructionList2 = new List<int>();
            foreach (char c in Input)
            {
                InstructionList2.Add(Convert.ToInt32(c));
            }
            InstructionList2.Add(17);
            InstructionList2.Add(31);
            InstructionList2.Add(73);
            InstructionList2.Add(47);
            InstructionList2.Add(23);
            for (int A = 1; A <= 64; A++)
                foreach (int i in InstructionList2)
                {
                    TurnList.Clear();
                    for (int Pos = CurrentPosition + i - 1; Pos >= CurrentPosition; Pos--)
                    {
                        TurnList.Add(RopeKnot2[Pos % 256]);
                    }
                    IteratorInt = 0;
                    foreach (int Pos in TurnList)
                    {
                        RopeKnot2[(CurrentPosition + IteratorInt) % 256] = Pos;
                        IteratorInt++;
                    }
                    CurrentPosition = (CurrentPosition + SkipSize + i) % 256;
                    SkipSize++;
                }
            for (int i = 0; i <= 15; i++)
            {
                for (int iii = 0; iii <= 15; iii++)
                    DenseHash[i] = DenseHash[i] ^ RopeKnot2[(i * 16) + iii];
            }
            foreach (int i in DenseHash)
            {
                Sum2 += i.ToString("X2");
            }
            return Sum2;
        }
    }
}
