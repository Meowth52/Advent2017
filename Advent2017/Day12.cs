using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2017
{
    class Day12
    {
        private string Input;
        private string[] Instructions;
        public Day12(string input)
        {
            Input = input.Replace("\r\n", "_");
            Instructions = Input.Split('_');
        }

        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            List<int> VisitedPeople = new List<int>();
            List<VillagePerson> VillagePeople = new List<VillagePerson>();
            Dictionary<int, string> VillageDictonary = new Dictionary<int, string>();
            foreach (string s in Instructions)
            {
                if (s != "")
                {
                    int TryParseInt = 0;
                    string CleanedS = s.Replace(" <-> ", "_");
                    string[] Words = CleanedS.Split('_');
                    Int32.TryParse(Words[0], out TryParseInt);
                    VillageDictonary.Add(TryParseInt, Words[1]);
                }
            }
            VillagePeople.Add(new VillagePerson(0, VillageDictonary, VisitedPeople));
            Sum += VillagePeople.First().CountConnections() + 1;
            foreach (KeyValuePair<int, string> k in VillageDictonary)
            {
                if (!VisitedPeople.Contains(k.Key))
                {
                    VillagePeople.Add(new VillagePerson( k.Key, VillageDictonary, new List<int>()));
                    List<int> veppepp = VillagePeople.Last().getVisitedPeople(new List<int>());
                    foreach (int i in veppepp)
                    {
                        VisitedPeople.Add(i);
                    }
                }

            }
            Sum2 = VillagePeople.Count;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString();
        }

    }
}