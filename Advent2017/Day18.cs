using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2017
{
    class Day18
    {
        Stopwatch stopWatch = new Stopwatch();
        private string Input;
        private string[] RawInstructions;
        private List<string[]> Instructions = new List<string[]>();
        public Day18(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "_");
            RawInstructions = Input.Split('_');
            foreach (string s in RawInstructions)
            {
                if (s != "")
                    Instructions.Add(s.Split(' '));
            }
        }
        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            int InstructionIndex = 0;
            int LastSound = 0;
            int Target = 0;
            Dictionary<char, int> Registers = new Dictionary<char, int>();
            foreach (string[] s in Instructions)
            {
                if (!Registers.ContainsKey(s[1][0])&&Char.IsLetter(s[1], 0))
                    Registers.Add(s[1][0], 0);
            }
            while (InstructionIndex < Instructions.Count)
            {
                string[] s = Instructions[InstructionIndex];
                if (s[0] == "snd")
                {
                    LastSound = Registers[s[1][0]];
                }
                if (s[0] == "set")
                {
                    if (char.IsNumber(s[2], 0) || s[2][0] == '-')
                        Int32.TryParse(s[2], out Target);
                    else
                        Target = Registers[s[2][0]];
                    Registers[s[1][0]] = Target;
                }
                if (s[0] == "add")
                {
                    if (char.IsNumber(s[2], 0) || s[2][0] == '-')
                        Int32.TryParse(s[2], out Target);
                    else
                        Target = Registers[s[2][0]];
                    Registers[s[1][0]] += Target;
                }
                if (s[0] == "mul")
                {
                    if (char.IsNumber(s[2], 0) || s[2][0] == '-')
                        Int32.TryParse(s[2], out Target);
                    else
                        Target = Registers[s[2][0]];
                    Registers[s[1][0]] *= Target;
                }
                if (s[0] == "mod")
                {
                    if (char.IsNumber(s[2], 0) || s[2][0] == '-')
                        Int32.TryParse(s[2], out Target);
                    else
                        Target = Registers[s[2][0]];
                    Registers[s[1][0]] %= Target;
                }
                if (s[0] == "rcv")
                {
                    if (char.IsNumber(s[1], 0) || s[1][0] == '-')
                        Int32.TryParse(s[1], out Target);
                    else
                        Target = Registers[s[1][0]];
                    if (Target != 0)
                        break;
                }
                if (s[0] == "jgz")
                {
                    if (char.IsNumber(s[1], 0) || s[1][0] == '-')
                        Int32.TryParse(s[1], out Target);
                    else
                        Target = Registers[s[1][0]];
                    if (Target > 0)
                    {
                        if (char.IsNumber(s[2], 0) || s[2][0] == '-')
                            Int32.TryParse(s[2], out Target);
                        else
                            Target = Registers[s[2][0]];
                        InstructionIndex += Target;
                    }
                    else
                    {
                        InstructionIndex++;
                    }
                }
                else
                {
                    InstructionIndex++;
                }
            }
            Sum = LastSound;
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }

    }
}
