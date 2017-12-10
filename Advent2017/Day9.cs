using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2017
{
    class Day9
    {
        private string Input;
        public int Sum2 = 0;
        public Day9(string input)
        {
            Input = input;
        }

        public string Result()
        {
            int Sum = 0;
            string IgnoredInput = RemoveIgnored(Input);
            string GarbageCleaned = CleanGarbage(IgnoredInput);
            Sum = GetGroupCount(GarbageCleaned);
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString();
        }
        public string RemoveIgnored(string In)
        {
            StringBuilder SBuilderOut = new StringBuilder();
            bool Ignore = false;
            foreach (char c in In)
            {
                if (Ignore)
                    Ignore = false;
                else if (c == '!')
                    Ignore = true;
                else if (c != '!')
                    SBuilderOut.Append(c);
            }

            return SBuilderOut.ToString();
        }
        public string CleanGarbage(string In)
        {
            StringBuilder SBuilderOut = new StringBuilder();
            bool InGarbage = false;
            foreach (char c in In)
            {
                if (InGarbage)
                {
                    if (c == '>')
                        InGarbage = false;
                    else
                        Sum2++;
                }
                else if (c == '<')
                    InGarbage = true;
                else
                    SBuilderOut.Append(c);
            }
            return SBuilderOut.ToString();
        }
        public int GetGroupCount(string In)
        {
            int Level = 0;
            int Out = 0;
            foreach (char c in In)
            {
                if (c == '{')
                {
                    Level++;
                    Out += Level;
                }
                if (c == '}')
                    Level--;
            }
            return Out;
        }
    }
}

