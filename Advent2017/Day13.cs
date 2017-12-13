using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2017
{
    class Day13
    {
        private string Input;
        private string[] Instructions;
        public Day13(string input)
        {
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
                    k.Value.Initiate(Sum2);
                for (int i =  0; i <= Firewall.Last().Key; i++)
                {

                    if (Firewall.ContainsKey(i))
                    {
                        if (Firewall[i].getPosition() == 1)
                        {
                            Caught = true;
                            break;
                        }
                    }
                    foreach (KeyValuePair<int, Layer> k in Firewall)
                    {
                        k.Value.Move();
                    }
                }
                Sum2++;
            }
            Sum2--;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString();
        }
        
    }
}
