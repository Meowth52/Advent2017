using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2017
{
    class Day24
    {
        Stopwatch stopWatch = new Stopwatch();
        private string Input;
        private string[] RawInstructions;
        private List<List<string>> Instructions = new List<List<string>>();
        string[] SplitString;
        public Day24(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "_");
            RawInstructions = Input.Split('_');
            foreach (string s in RawInstructions)
            {
                if (s != "")
                {
                    SplitString = s.Split('/');
                    Instructions.Add(SplitString.OfType<string>().ToList());
                }
            }
        }
        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            int SumCompare = 0;
            List<BridgeElement> BridgeElements = new List<BridgeElement>();
            List<List<int>> ReturnLists = new List<List<int>>();
            List<int> ReturnList = new List<int>();
            foreach (List<string> s in Instructions)
            {
                BridgeElements.Add(new BridgeElement(s));
            }
            foreach(BridgeElement b in BridgeElements)
            {
                if (b.Contains(0))
                {
                    List<BridgeElement> TempList = new List<BridgeElement>(BridgeElements);
                    TempList.Remove(b);
                    SumCompare = b.BridgeDiver(TempList, 0);
                    if (SumCompare > Sum)
                        Sum=SumCompare;
                    ReturnLists.Add(b.BridgeJumper(TempList, 0));
                }
            }
            foreach (List<int> l in ReturnLists)
            {
                if (l.Count > ReturnList.Count)
                {
                    ReturnList = new List<int>(l);
                }
                else if (l.Count == ReturnList.Count && l.Sum() > ReturnList.Sum())
                {
                    ReturnList = new List<int>(l);
                }
            }
            Sum2 = ReturnList.Sum();
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }

    }
}
