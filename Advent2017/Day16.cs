using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Advent2017
{
    class Day16
    {
        private string Input;
        private string[] Instructions;
        Stopwatch stopWatch = new Stopwatch();
        private List<char> Dancers = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p' };
        public Day16(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "");
            Instructions = Input.Split(',');
        }

        public string Result()
        {
            string Sum = "";
            string Sum2 = "";
            int Counter = 0;
            string StringString = "";
            bool First = true;
            while (StringString != "abcdefghijklmnop")
            {
                foreach (string s in Instructions)
                {
                    if (s != "")
                    {
                        if (s[0] == 'p')
                        {
                            int Position1 = Dancers.IndexOf(s[1]);
                            int Position2 = Dancers.IndexOf(s[3]);
                            char c1 = Dancers[Position1];
                            char c2 = Dancers[Position2];
                            Dancers[Position1] = c2;
                            Dancers[Position2] = c1;
                        }
                        else
                        {
                            int Range = 0;
                            int Range2 = 0;
                            Regex theRegex = new Regex(@"\d+");
                            MatchCollection theMatch = theRegex.Matches(s);
                            Int32.TryParse(theMatch[0].Value, out Range);
                            if (s[0] == 's')
                            {
                                List<char> NewRange = Dancers.GetRange(Dancers.Count - Range, Range);
                                Dancers.RemoveRange(Dancers.Count - Range, Range);
                                Dancers.InsertRange(0, NewRange);
                            }
                            if (s[0] == 'x')
                            {
                                Int32.TryParse(theMatch[1].Value, out Range2);
                                char c = Dancers[Range];
                                char d = Dancers[Range2];
                                Dancers[Range] = d;
                                Dancers[Range2] = c;
                            }
                        }
                    }
                }
                StringString = "";
                foreach (char c in Dancers)
                {
                    StringString += c;
                }
                Counter++;
                if (First)
                {
                    Sum = StringString;
                    First = false;
                }
            }
            for (int i = 1; i <= 1000000000%Counter; i++)
            {
                foreach (string s in Instructions)
                {
                    if (s != "")
                    {
                        if (s[0] == 'p')
                        {
                            int Position1 = Dancers.IndexOf(s[1]);
                            int Position2 = Dancers.IndexOf(s[3]);
                            char c1 = Dancers[Position1];
                            char c2 = Dancers[Position2];
                            Dancers[Position1] = c2;
                            Dancers[Position2] = c1;
                        }
                        else
                        {
                            int Range = 0;
                            int Range2 = 0;
                            Regex theRegex = new Regex(@"\d+");
                            MatchCollection theMatch = theRegex.Matches(s);
                            Int32.TryParse(theMatch[0].Value, out Range);
                            if (s[0] == 's')
                            {
                                List<char> NewRange = Dancers.GetRange(Dancers.Count - Range, Range);
                                Dancers.RemoveRange(Dancers.Count - Range, Range);
                                Dancers.InsertRange(0, NewRange);
                            }
                            if (s[0] == 'x')
                            {
                                Int32.TryParse(theMatch[1].Value, out Range2);
                                char c = Dancers[Range];
                                char d = Dancers[Range2];
                                Dancers[Range] = d;
                                Dancers[Range2] = c;
                            }
                        }
                    }
                }
                StringString = "";
                foreach (char c in Dancers)
                {
                    StringString += c;
                }
            }
            Sum2 = StringString;
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum + " och del 2: " + Sum2 + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }

    }
}
