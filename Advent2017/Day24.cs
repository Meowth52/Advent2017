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
            long Sum = 0;
            long Sum2 = 0;
            foreach(List<string> s in Instructions)
            {
                s.Sort();
            }
            foreach (List<string> s in Instructions)
            {

            }
                stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }

    }
}
