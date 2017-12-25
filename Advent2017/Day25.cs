using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2017
{
    class Day25
    {
        Stopwatch stopWatch = new Stopwatch();
        private string Input;
        private string[] RawInstructions;
        private Dictionary<char, Turing> Instructions = new Dictionary<char, Turing>();
        Turing TempTure;
        public Day25(string input)
        {
            stopWatch.Start();
            Input = input.Replace("In state ", "_");
            RawInstructions = Input.Split('_');
            foreach (string s in RawInstructions)
            {
                if (s != "" && !s.Contains("Begin"))
                {
                    TempTure = new Turing(s);
                    Instructions.Add(TempTure.GetName(), TempTure);
                }
            }
        }
        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            int Cursor = 0;
            char State = 'A';
            bool CurrentValue;
            char CurrentState;
            Dictionary<int, bool> InfiniteTape = new Dictionary<int, bool>();
            for (int i = 0; i < 12172063; i++)
            {
                if (!InfiniteTape.ContainsKey(Cursor))
                    InfiniteTape.Add(Cursor, false);
                CurrentValue = InfiniteTape[Cursor];
                CurrentState = State;
                InfiniteTape[Cursor] = Instructions[CurrentState].GetWriteValue(CurrentValue);
                State = Instructions[CurrentState].GetNextState(CurrentValue);
                Cursor += Instructions[CurrentState].GetDirection(CurrentValue);
            }
            foreach (KeyValuePair<int, bool> k in InfiniteTape)
            {
                if (k.Value)
                    Sum++;
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }

    }
}
