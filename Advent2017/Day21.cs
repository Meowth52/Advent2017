using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;

namespace Advent2017
{
    class Day21
    {
        private string Input;
        Stopwatch stopWatch = new Stopwatch();
        private string[] RawInstructions;
        private Dictionary<string,string> SmallEnhancementRules = new Dictionary<string, string>();
        private Dictionary<string, string> BigEnhancementRules = new Dictionary<string, string>();
        List<PictureSegment2x2> Picture2x2 = new List<PictureSegment2x2>();
        List<PictureSegment3x3> Picture3x3 = new List<PictureSegment3x3>();
        public Day21(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "_");
            RawInstructions = Input.Split('_');
            foreach (string s in RawInstructions)
            {
                if (s != "")
                {
                    if (s.Length < 22)
                    {
                        string SplitString = s.Replace(" => ", "_");
                        SmallEnhancementRules.Add(SplitString.Split('_')[0], SplitString.Split('_')[1]);
                    }
                    if (s.Length > 22)
                    {
                        string SplitString = s.Replace(" => ", "_");
                        BigEnhancementRules.Add(SplitString.Split('_')[0], SplitString.Split('_')[1]);
                    }
                }
            }
            Picture3x3.Add(new PictureSegment3x3(".#./..#/###"));

        }

        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            int NumberOfMatches;
            bool Flip = true;
            for(int i = 1; i <= 2; i++)
            {
                if (Flip)
                {
                    NumberOfMatches = 0;
                    Picture2x2.Clear();
                    foreach (PictureSegment3x3 p in Picture3x3)
                    {
                        foreach (KeyValuePair<string, string> r in BigEnhancementRules)
                        {
                            if (p.isMatch(r.Key))
                            {
                                NumberOfMatches++;
                                Picture2x2.Add(new PictureSegment2x2(r.Value.Substring(0, 2) + r.Value.Substring(5, 2)));
                                Picture2x2.Add(new PictureSegment2x2(r.Value.Substring(2, 2) + r.Value.Substring(7, 2)));
                                Picture2x2.Add(new PictureSegment2x2(r.Value.Substring(10, 2) + r.Value.Substring(15, 2)));
                                Picture2x2.Add(new PictureSegment2x2(r.Value.Substring(12, 2) + r.Value.Substring(17, 2)));
                            }
                        }
                    }
                    Flip = false;
                }
                else
                {
                    NumberOfMatches = 0;
                    Picture3x3.Clear();
                    foreach (PictureSegment2x2 p in Picture2x2)
                    {
                        foreach (KeyValuePair<string, string> r in SmallEnhancementRules)
                        {
                            if (p.isMatch(r.Key))
                            {
                                NumberOfMatches++;
                                Picture3x3.Add(new PictureSegment3x3(r.Value.Substring(0, 3) + r.Value.Substring(4, 3) + r.Value.Substring(8, 3)));
                            }
                        }
                    }
                    Flip = true;
                }
            }
            if (Flip)
                foreach (PictureSegment3x3 p in Picture3x3)
                    Sum += p.NumberOfTrue();
            else
                foreach (PictureSegment2x2 p in Picture2x2)
                    Sum += p.NumberOfTrue();

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }

    }
}

