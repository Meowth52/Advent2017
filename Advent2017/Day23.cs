using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2017
{
    class Day23
    {
        Stopwatch stopWatch = new Stopwatch();
        private string Input;
        private string[] RawInstructions;
        private List<string[]> Instructions = new List<string[]>();
        public Day23(string input)
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
            Dictionary<char, long> Registers = new Dictionary<char, long>(){ {'a',0}, { 'b', 0 }, { 'c', 0 }, { 'd', 0 }, { 'e', 0 }, { 'f', 0 }, { 'g', 0 }, { 'h', 0 }};
            int InstructionIndex = 0;
            string Keyword;
            char Target;
            long Value;
            while (InstructionIndex < Instructions.Count)
            {
                string[] s = Instructions[InstructionIndex];
                Keyword = s[0];
                Target = s[1][0];
                if (char.IsNumber(s[2], 0) || s[2][0] == '-')
                    Int64.TryParse(s[2], out Value);
                else
                    Value = Registers[s[2][0]];
                if (Keyword == "set")
                {
                    Registers[Target] = Value;
                }
                if (Keyword == "sub")
                {
                    Registers[Target] -= Value;
                }
                if (Keyword == "mul")
                {
                    Registers[Target] *= Value;
                    Sum++;
                }
                if (Keyword == "jnz" && ((Char.IsLetter(s[1], 0) && Registers[s[1][0]] != 0) || Char.IsNumber(s[1], 0)))
                {
                    InstructionIndex += (int)Value;
                }
                else
                    InstructionIndex++;

            }
            //Part 2
            Registers = new Dictionary<char, long>() { { 'a', 1 }, { 'b', 0 }, { 'c', 0 }, { 'd', 0 }, { 'e', 0 }, { 'f', 0 }, { 'g', 0 }, { 'h', 0 } };
            InstructionIndex = 0;
            while (InstructionIndex < Instructions.Count)
            {
                Sum2++;
                string[] s = Instructions[InstructionIndex];
                Keyword = s[0];
                Target = s[1][0];
                if (char.IsNumber(s[2], 0) || s[2][0] == '-')
                    Int64.TryParse(s[2], out Value);
                else
                    Value = Registers[s[2][0]];
                if (Keyword == "set")
                {
                    Registers[Target] = Value;
                }
                if (Keyword == "sub")
                {
                    Registers[Target] -= Value;
                }
                if (Keyword == "mul")
                {
                    Registers[Target] *= Value;
                }
                if (Keyword == "jnz" && ((Char.IsLetter(s[1], 0) && Registers[s[1][0]] != 0) || Char.IsNumber(s[1], 0)))
                {
                    InstructionIndex += (int)Value;
                }
                else
                    InstructionIndex++;
            }
                stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }

    }
}
