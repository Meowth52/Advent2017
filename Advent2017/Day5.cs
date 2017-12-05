using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2017
{
    class Day5
    {
        private string Input;
        private string[] Instructions;
        private Dictionary<int, int> TheMaze = new Dictionary<int, int>();
        private Dictionary<int, int> TheMaze2 = new Dictionary<int, int>();
        private int Index = 0;
        public Day5(string input)
        {
            Input = input.Replace("\r\n", "_");
            Instructions = Input.Split('_');
            foreach(string s in Instructions)
            {
                int ParseInt;
                if (Int32.TryParse(s, out ParseInt))
                {
                    TheMaze.Add(Index, ParseInt);
                    TheMaze2.Add(Index, ParseInt);
                    Index++;
                }
            }
        }
        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            Index = 0;
            int NextIndex=0;
            while(TheMaze.ContainsKey(Index))
            {
                Sum++;
                NextIndex += TheMaze[Index];
                TheMaze[Index]++;
                Index = NextIndex;
            }
            Index = 0;
            NextIndex = 0;
            while (TheMaze2.ContainsKey(Index))
            {
                Sum2++;
                NextIndex += TheMaze2[Index];
                if (TheMaze2[Index] >= 3)
                    TheMaze2[Index]--;
                else
                    TheMaze2[Index]++;
                Index = NextIndex;
            }
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString();
        }
    }
}
