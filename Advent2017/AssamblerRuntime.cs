using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2017
{
    class AssamblerRuntime
    {
        public int AnswereCounter = 0;
        public bool isTerminated = false;
        int InstructionIndex = 0;
        long Target = 0;
        List<long> ReciveBuffert = new List<long>();
        List<long> SendBuffert = new List<long>();
        private List<string[]> Instructions = new List<string[]>();
        Dictionary<char, long> Registers = new Dictionary<char, long>();
        public AssamblerRuntime(List<string[]> instructions)
        {
            Instructions = instructions;
            foreach (string[] s in Instructions)
            {
                if (!Registers.ContainsKey(s[1][0]) && Char.IsLetter(s[1], 0))
                    Registers.Add(s[1][0], 0);
            }
        }
        public List<long> run(List<long> recivebuffert)
        {
            ReciveBuffert = recivebuffert;
            SendBuffert.Clear();
            if (Instructions[InstructionIndex][0] == "rcv" && ReciveBuffert.Count == 0)
                return SendBuffert;
            while (InstructionIndex < Instructions.Count)
            {
                string[] s = Instructions[InstructionIndex];
                if (s[0] == "snd")
                {
                    SendBuffert.Add(Registers[s[1][0]]);
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
                    if (ReciveBuffert.Count == 0)
                    {
                        return SendBuffert;
                    }
                    else
                    {
                        Registers[s[1][0]] = ReciveBuffert.First();
                        ReciveBuffert.RemoveAt(0);
                    }
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
                        InstructionIndex += Convert.ToInt32(Target);
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
            isTerminated = true;
            return SendBuffert;
        }
        public void setP(bool id)
        {
            if (id)
                Registers['p'] = 1;
            else
                Registers['p'] = 0;
        }
    }
}
