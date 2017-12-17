using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;

namespace Advent2017
{
    class Day17
    {
        private string Input;
        Stopwatch stopWatch = new Stopwatch();
        public Day17(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "");
        }

        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            int CurrentPosition = 0;
            int StepNumber = 0;
            List<int> SpinLock = new List<int>();
            SpinLock.Add(0);
            Int32.TryParse(Input, out StepNumber);
            for (int i = 1; i <= 2017; i++)
            {
                CurrentPosition = ((CurrentPosition + StepNumber)%(i))+1;
                SpinLock.Insert(CurrentPosition, i);
            }
            Sum = SpinLock[SpinLock.IndexOf(2017)+1];
            for (int i = 2018; i <= 50000000; i++)
            {
                CurrentPosition = ((CurrentPosition + StepNumber) % (i)) + 1;
                if (CurrentPosition < 2)
                    SpinLock.Insert(CurrentPosition, i);
            }
            Sum2 = SpinLock[SpinLock.IndexOf(0) + 1];
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }

    }
}
