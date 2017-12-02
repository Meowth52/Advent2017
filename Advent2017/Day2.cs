using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2017
{
    internal class Day2
    {
        private string Input;
        private string[] Instructions;
        private List<List<int>> Spreadsheet = new List<List<int>>();
        private int Sum;
        private int Sum2;
        public Day2(string input)
        {
            Input = input.Replace("\r\n", "_");
            Instructions = Input.Split('_');
            foreach(string s in Instructions)
            {
                string[] Words;
                Words = s.Split(' ');
                List<int> l = new List<int>();
                foreach(string w in Words)
                {
                    if (w != "")
                    {
                        int ParseTry = -1;
                        Int32.TryParse(w, out ParseTry);
                        l.Add(ParseTry);
                    }
                }
                if(l.Any())
                    Spreadsheet.Add(l);
            }
        }

        public string Result()
        {
            foreach(List<int> l in Spreadsheet)
            {
                l.Sort();
                Sum += l.Last() - l.First();
            }
            foreach(List<int> l in Spreadsheet)
                foreach(int i in l)
                    foreach(int i2 in l)
                    {
                        if (i % i2 == 0 && i != i2)
                            Sum2 += i / i2;
                    }
            return Sum.ToString() + " och del 2 " + Sum2.ToString();
        }
    }
}
