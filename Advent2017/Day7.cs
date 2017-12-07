using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2017
{
    class Day7
    {
        private string Input;
        private string[] Instructions;
        public string HelaJaklaTradet = "";
        public Day7(string input)
        {
            Input = input.Replace("\r\n", "_");
            Instructions = Input.Split('_');
        }

        public string Result()
        {
            string Sum = "";
            int Sum2 = 0;
            int TotalWeight;
            List<string> AllBots = new List<string>();
            List<string> CarriedBots = new List<string>();
            List<TowerBot> Tower = new List<TowerBot>();
            foreach(string s in Instructions)
            {
                Regex theMatch = new Regex(@"([a-z])\w+");
                bool FirstMatch = true;
                foreach (Match m in theMatch.Matches(s))
                {
                    if (FirstMatch)
                    {
                        AllBots.Add(m.ToString());
                        FirstMatch = false;
                    }
                    else
                        CarriedBots.Add(m.ToString());
                }
            }
            foreach (string s in AllBots)
                if (!CarriedBots.Contains(s))
                    Sum = s;
            foreach(string s in Instructions)
            {
                if (s.StartsWith(Sum))
                    Tower.Add(new TowerBot(Instructions,Sum));
            }
            TotalWeight = Tower.First().getTotalWeight();
            //HelaJaklaTradet = Tower.First().getPrint(0, "");
            Sum2 = Tower.First().getTargetWeight(TotalWeight);
            return "Del 1: " + Sum + " och del 2: " + Sum2.ToString() + " " + HelaJaklaTradet;
        }
    }
}
