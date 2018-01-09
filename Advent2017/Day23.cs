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
            Dictionary<char, long> Registers = new Dictionary<char, long>(){ {'a',0}, { 'b', 0 }, { 'c', 0 }, { 'd', 0 }, { 'e', 0 }, { 'f', 0 }, { 'g', 0 }, { 'h', 0 }, { '1', 1 } };
            int InstructionIndex = 0;
            char Keyword;
            char Target;
            long Value;
            while (InstructionIndex < Instructions.Count)
            {
                string[] s = Instructions[InstructionIndex];
                Keyword = s[0][2];
                Target = s[1][0];
                if (char.IsNumber(s[2], 0) || s[2][0] == '-')
                    Int64.TryParse(s[2], out Value);
                else
                    Value = Registers[s[2][0]];
                switch (Keyword)
                {
                    case 't':
                        Registers[Target] = Value;
                        InstructionIndex++;
                        break;
                    case 'b':
                        Registers[Target] -= Value;
                        InstructionIndex++;
                        break;
                    case 'l':
                        Registers[Target] *= Value;
                        Sum++;
                        InstructionIndex++;
                        break;
                    case 'z':
                        if (Registers[s[1][0]] != 0)
                        {
                            InstructionIndex += (int)Value;
                        }
                        else
                            InstructionIndex++;
                        break;
                    default:
                        ;
                        break;

                }
            }
            //Part 2
            float x = 0;
            for (long b = 91117; b < 108100; b += 17)
            {
                bool isPrime = true;
                for (long i = 2; i < b; i++)
                {
                    x = b % i;
                    if (x == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (!isPrime)
                    Sum2++;
            }           
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }

    }
}
