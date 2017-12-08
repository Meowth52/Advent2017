using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2017
{
    class Day8
    {
        private string Input;
        private string[] RawInstructions;
        private List<string[]> Instructions = new List<string[]>();
        public Day8(string input)
        {
            Input = input.Replace("\r\n", "_");
            RawInstructions = Input.Split('_');
            foreach (string s in RawInstructions)
            {
                if(s != "")
                    Instructions.Add(s.Split(' '));
            }
        }

        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            Dictionary<string, int> Registers = new Dictionary<string, int>();
            foreach(string[] s in Instructions)
            {
                if (!Registers.ContainsKey(s[0]))
                    Registers.Add(s[0], 0);                    
            }
            foreach(string[] s in Instructions)
            {
                int TestNumber = 0;
                int AddNumber = 0;
                Int32.TryParse(s[6], out TestNumber);
                Int32.TryParse(s[2], out AddNumber);
                if (s[1] == "dec")
                    AddNumber = AddNumber * -1;
                string TestKey = s[4];
                if (s[5] == ">")
                {
                    if (Registers[TestKey] > TestNumber)
                        Registers[s[0]] += AddNumber;
                }
                else if (s[5] == "<")
                {
                    if (Registers[TestKey] < TestNumber)
                        Registers[s[0]] += AddNumber;
                }
                else if (s[5] == ">=")
                {
                    if (Registers[TestKey] >= TestNumber)
                        Registers[s[0]] += AddNumber;
                }
                else if (s[5] == "==")
                {
                    if (Registers[TestKey] == TestNumber)
                        Registers[s[0]] += AddNumber;
                }
                else if (s[5] == "<=")
                {
                    if (Registers[TestKey] <= TestNumber)
                        Registers[s[0]] += AddNumber;
                }
                else if (s[5] == "!=")
                {
                    if (Registers[TestKey] != TestNumber)
                        Registers[s[0]] += AddNumber;
                }
                foreach (KeyValuePair<string, int> r in Registers)
                {
                    if (r.Value > Sum2)
                        Sum2 = r.Value;
                }
            }
            foreach(KeyValuePair<string, int> r in Registers)
            {
                if (r.Value > Sum)
                    Sum = r.Value;
            }
                return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString();
        }
    }
}
