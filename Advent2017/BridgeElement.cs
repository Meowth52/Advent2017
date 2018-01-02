using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2017
{
    class BridgeElement
    {
        int Left = 0;
        int Right = 0;
        public BridgeElement(List<string> s)
        {
            Int32.TryParse(s[0], out Left);
            Int32.TryParse(s[1], out Right);
        }
        public bool Contains(int i)
        {
            return Left == i || Right == i;
        }
        public int BridgeDiver(List<BridgeElement> ElementList, int Match)
        {
            int StrenghtCounter = Left + Right;
            int StrenghtComparer = 0;
            int NextMatch;
            if (Left == Match)
            {
                NextMatch = Right;
            }
            else
            {
                NextMatch = Left;
            }
            foreach(BridgeElement b in ElementList)
            {
                if (b.Contains(NextMatch))
                {
                    List<BridgeElement> TempList = new List<BridgeElement>(ElementList);
                    TempList.Remove(b);
                    StrenghtComparer = b.BridgeDiver(TempList, NextMatch);
                    StrenghtComparer += Left + Right;
                    if (StrenghtComparer > StrenghtCounter)
                        StrenghtCounter = StrenghtComparer;
                }
            }
            return StrenghtCounter;
        }
        public List<int> BridgeJumper(List<BridgeElement> ElementList, int Match)
        {
            List<List<int>> ReturnLists = new List<List<int>>();
            List<int> ReturnList = new List<int>();
            int NextMatch;
            if (Left == Match)
            {
                NextMatch = Right;
            }
            else
            {
                NextMatch = Left;
            }
            foreach (BridgeElement b in ElementList)
            {
                if (b.Contains(NextMatch))
                {
                    List<BridgeElement> TempList = new List<BridgeElement>(ElementList);
                    TempList.Remove(b);
                    ReturnLists.Add(b.BridgeJumper(TempList,NextMatch));
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
            ReturnList.Add(Left);
            ReturnList.Add(Right);
            return ReturnList;
        }
    }
}
