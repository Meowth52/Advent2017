using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2017
{
    class TowerBot
    {
        string BotName;
        int Weight;
        int TotalWeight;
        string Instruction;
        int TestWeight = 0;
        string TreePrintout;
        List<TowerBot> LargeDisc = new List<TowerBot>();
        public TowerBot(string[] Instructions, string botName)
        {
            BotName = botName;
            Regex theMatch = new Regex(@"([a-z])\w+");
            foreach (string s in Instructions)
            {
                if (theMatch.Match(s).Value == BotName)
                {
                    Instruction = s;
                }
            }
            bool FirstMatch = true;
            foreach (Match m in theMatch.Matches(Instruction))
            {
                if (FirstMatch)
                {
                    FirstMatch = false;
                }
                else
                    LargeDisc.Add(new TowerBot(Instructions, m.ToString()));
            }
            theMatch = new Regex(@"([0-9])\w+");
            Int32.TryParse( theMatch.Match(Instruction).Value, out Weight);
        }
        public int getTotalWeight()
        {
            TotalWeight = Weight;
            foreach (TowerBot t in LargeDisc)
                TotalWeight += t.getTotalWeight();            
            return TotalWeight;
        }
        //public string getPrint(int depth, string PrintSoFar)
        //{
        //    depth++;
        //    foreach (TowerBot t in LargeDisc)
        //    {
        //        PrintSoFar += "/r";
        //        for (int i = depth; i > 0; i--)
        //            PrintSoFar += "    ";
        //        PrintSoFar += BotName +", " + Weight.ToString() + ", " + TotalWeight.ToString();
        //        PrintSoFar += t.getPrint(depth, PrintSoFar);
        //    }
        //    return PrintSoFar;
        //}
        public int getTargetWeight(int ParentTotalWeight)
        {
            int MaybyReturnValue = 0;
            if (LargeDisc.Any())
            {
                foreach (TowerBot t in LargeDisc)
                {
                    if (t.TotalWeight == ParentTotalWeight / LargeDisc.Count)
                    {
                        TestWeight = t.getTargetWeight(TotalWeight);
                        if (TestWeight > 0)
                            return TestWeight;
                        else
                        {
                            ;
                        }
                    }
                    if (t.TestWeight > MaybyReturnValue)
                        MaybyReturnValue = t.TestWeight;
                }
            }
            return MaybyReturnValue;
        }
    }
}
