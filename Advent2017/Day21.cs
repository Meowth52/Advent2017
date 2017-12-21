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
        private List<string[]> EnhancementRules = new List<string[]>();
        List<PictureSegment2x2> Picture2x2 = new List<PictureSegment2x2>();
        List<PictureSegment3x3> Picture3x3 = new List<PictureSegment3x3>();
        public Day21(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "_");
            RawInstructions = Input.Split('_');
            foreach (string s in RawInstructions)
            {
                string SplitString = s.Replace(" => ", "_");
                EnhancementRules.Add(s.Split('_'));
                Picture3x3.Add(new PictureSegment3x3({"",""}))
            }
            
        }

        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }

    }
}

