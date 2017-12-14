using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2017
{
    class Day13
    {
        private string Input;
        private string[] Instructions;
        Stopwatch stopWatch = new Stopwatch();
        public Day13(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "_");
            Instructions = Input.Split('_');
        }

        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            int TryParseWord0 = 0;
            int TryParseWord1 = 0;
            bool Caught = true;
            Dictionary<int, Layer> Firewall = new Dictionary<int, Layer>();
            foreach(string s in Instructions)
            {
                if (s != "")
                {
                string CleanedS = s.Replace(": ", "_");
                string[] Words = CleanedS.Split('_');
                Int32.TryParse(Words[0], out TryParseWord0);
                Int32.TryParse(Words[1], out TryParseWord1);
                Firewall.Add(TryParseWord0, new Layer(TryParseWord1));
                }
            }
            for (int i = 0; i <= Firewall.Last().Key; i++)
            {

                if (Firewall.ContainsKey(i))
                {
                    if (Firewall[i].getPosition() == 1)
                    {
                        Sum += i * Firewall[i].getDepth();
                    }
                }
                foreach (KeyValuePair<int, Layer> k in Firewall)
                {
                    k.Value.Move();
                }
            }
            while (Caught)
            {
                Caught = false;
                foreach (KeyValuePair<int, Layer> k in Firewall)
                    if (k.Value.WillItCatch(Sum2 + k.Key))
                    {
                        Caught = true;
                        break;
                    }
                Sum2++;
            }
            Sum2-=2;
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
        
    }
}
