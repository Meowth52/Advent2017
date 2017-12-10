using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2017
{
    class Day10
    {
        private string Input;
        private string[] InstructionStrings;
        int[] RopeKnot = new int[256];
        int[] RopeKnot2 = new int[256];
        List<int> Instructions = new List<int>();
        int TryParseInt = 0;
        public Day10(string input)
        {
            Input = input.Replace("\r\n", "");
            InstructionStrings = Input.Split(',');
            foreach (string s in InstructionStrings)
            {
                Int32.TryParse(s, out TryParseInt);
                Instructions.Add(TryParseInt);
            }
            for (int i = 0; i <= 255; i++)
            {
                RopeKnot[i] = i;
                RopeKnot2[i] = i;
            }
        }

        public string Result()
        {
            int Sum = 0;
            string Sum2 = "";
            int SkipSize = 0;
            int CurrentPosition = 0;
            int IteratorInt;
            List<int> TurnList = new List<int>();
            int[] DenseHash = new int[16];
            foreach (int i in Instructions)
            {
                TurnList.Clear();
                for (int Pos = CurrentPosition + i - 1; Pos >= CurrentPosition; Pos--)
                {
                    TurnList.Add(RopeKnot[Pos % 256]);
                }
                IteratorInt = 0;
                foreach (int Pos in TurnList)
                {
                    RopeKnot[(CurrentPosition + IteratorInt) % 256] = Pos;
                    IteratorInt++;
                }
                CurrentPosition += SkipSize + i;
                SkipSize++;
            }
            Sum = RopeKnot[0] * RopeKnot[1];
            SkipSize = 0;
            CurrentPosition = 0;
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
                    CurrentPosition = (CurrentPosition + SkipSize + i)%256;
                    SkipSize++;
                }
            for(int i = 0; i <= 15; i++)
            {
                for (int iii = 0; iii <= 15; iii++)
                    DenseHash[i] = DenseHash[i] ^ RopeKnot2[(i*16) + iii];
            }
            foreach(int i in DenseHash)
            {
                Sum2 += i.ToString("X2");
            }
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString();
        }

    }
}