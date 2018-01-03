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
        private Dictionary<string, string> SmallEnhancementRules = new Dictionary<string, string>();
        private Dictionary<string, string> BigEnhancementRules = new Dictionary<string, string>();
        List<PictureSegment2x2> Picture2x2 = new List<PictureSegment2x2>();
        List<PictureSegment3x3> Picture3x3 = new List<PictureSegment3x3>();
        List<string> BigPicture = new List<string>();
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
            BigPicture.Add(".#.");
            BigPicture.Add("..#");
            BigPicture.Add("###");
        }

        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            int NumberOfMatches;
            for (int i = 1; i <= 18; i++)
            {
                if (BigPicture.Count % 2 != 0)
                {
                    NumberOfMatches = 0;
                    Picture2x2.Clear();
                    Picture3x3.Clear();
                    for (int n = 0; n < Math.Pow(BigPicture.Count / 3, 2); n++)
                    {
                        int y = (n / (BigPicture.Count / 3)) * 3;
                        int x = (n % (BigPicture.Count / 3)) * 3;
                        Picture3x3.Add(new PictureSegment3x3(BigPicture[y+0].Substring(x, 3)+ BigPicture[y + 1].Substring(x, 3) + BigPicture[y + 2].Substring(x, 3)));
                    }
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
                    BigPicture.Clear();
                    int PictureCount = (int)Math.Sqrt(Picture2x2.Count);
                    while (BigPicture.Count < PictureCount * 2)
                    {
                        BigPicture.Add("");
                    }
                    for (int n = 0; n < Picture2x2.Count; n++)
                    {
                        BigPicture[(n / PictureCount) * 2 + 0] += Picture2x2[n].PrintOne();
                        BigPicture[(n / PictureCount) * 2 + 1] += Picture2x2[n].PrintTwo();
                    }
                }
                else
                {
                    NumberOfMatches = 0;
                    Picture3x3.Clear();
                    Picture2x2.Clear();
                    for (int n = 0; n < Math.Pow(BigPicture.Count / 2, 2); n++)
                    {
                        int y = (n / (BigPicture.Count / 2)) * 2;
                        int x = (n % (BigPicture.Count / 2))*2;
                        Picture2x2.Add(new PictureSegment2x2(BigPicture[y + 0].Substring(x, 2) + BigPicture[y + 1].Substring(x, 2)));
                    }
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
                    BigPicture.Clear();
                    int PictureCount = (int)Math.Sqrt(Picture3x3.Count);
                    while (BigPicture.Count < PictureCount * 3)
                    {
                        BigPicture.Add("");
                    }
                    for (int n = 0; n < Picture3x3.Count; n++)
                    {
                        BigPicture[(n / PictureCount) * 3 + 0] += Picture3x3[n].PrintOne();
                        BigPicture[(n / PictureCount) * 3 + 1] += Picture3x3[n].PrintTwo();
                        BigPicture[(n / PictureCount) * 3 + 2] += Picture3x3[n].PrintThree();
                    }
                }
            }
            foreach (string s in BigPicture)
            {
                foreach (char c in s)
                    if (c == '#')
                        Sum++;
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }

    }
}

