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
                {
                    Instructions.Add(s.Split(' '));
                }
            }
        }
        public string Result()
        {
            long Sum = 0;
            long Sum2 = 0;
            int InstructionIndex = 0;
            long LastSound = 0;
            long Target = 0;
            Dictionary<char, long> Registers = new Dictionary<char, long>();
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
                        Int64.TryParse(s[2], out Target);
                    else
                        Target = Registers[s[2][0]];
                    Registers[s[1][0]] = Target;
                }
                if (s[0] == "add")
                {
                    if (char.IsNumber(s[2], 0) || s[2][0] == '-')
                        Int64.TryParse(s[2], out Target);
                    else
                        Target = Registers[s[2][0]];
                    Registers[s[1][0]] += Target;
                }
                if (s[0] == "mul")
                {
                    if (char.IsNumber(s[2], 0) || s[2][0] == '-')
                        Int64.TryParse(s[2], out Target);
                    else
                        Target = Registers[s[2][0]];
                    Registers[s[1][0]] *= Target;
                }
                if (s[0] == "mod")
                {
                    if (char.IsNumber(s[2], 0) || s[2][0] == '-')
                        Int64.TryParse(s[2], out Target);
                    else
                        Target = Registers[s[2][0]];
                    Registers[s[1][0]] %= Target;
                }
                if (s[0] == "rcv")
                {
                    if (char.IsNumber(s[1], 0) || s[1][0] == '-')
                        Int64.TryParse(s[1], out Target);
                    else
                        Target = Registers[s[1][0]];
                    if (Target != 0)
                        break;
                }
                if (s[0] == "jgz")
                {
                    if (char.IsNumber(s[1], 0) || s[1][0] == '-')
                        Int64.TryParse(s[1], out Target);
                    else
                        Target = Registers[s[1][0]];
                    if (Target > 0)
                    {
                        if (char.IsNumber(s[2], 0) || s[2][0] == '-')
                            Int64.TryParse(s[2], out Target);
                        else
                            Target = Registers[s[2][0]];
                        InstructionIndex += Convert.ToInt32( Target);
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
            List<long> Sendbuffert0 = new List<long> { 0};
            List<long> Sendbuffert1 = new List<long> ();
            bool InstanceSwitch = false;
            AssamblerRuntime nr0 = new AssamblerRuntime(Instructions);
            nr0.setP(false);
            AssamblerRuntime nr1 = new AssamblerRuntime(Instructions);
            nr1.setP(true);
            while ((Sendbuffert0.Any() || Sendbuffert1.Any()) && (!nr0.isTerminated || !nr1.isTerminated) )
            {
                if (InstanceSwitch && !nr1.isTerminated)
                {
                    Sendbuffert1 = nr1.run(Sendbuffert0);
                    Sum2 += Sendbuffert1.Count;
                    InstanceSwitch = false;
                }
                else if (!nr0.isTerminated)
                {
                    Sendbuffert0 = nr0.run(Sendbuffert1);
                    InstanceSwitch = true;
                }
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }

    }
}
