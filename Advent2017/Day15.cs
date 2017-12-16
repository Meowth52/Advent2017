using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;

namespace Advent2017
{
    class Day15
    {
        private string Input;
        private string[] Instructions;
        Stopwatch stopWatch = new Stopwatch();
        public Day15(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "_");
            Instructions = Input.Split('_');
        }

        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            long GeneratorA = 0;
            long GeneratorB = 0;
            Int64.TryParse(Instructions[0].Split(' ').Last(), out GeneratorA);
            Int64.TryParse(Instructions[1].Split(' ').Last(), out GeneratorB);
            long GeneratorA2 = GeneratorA;
            long GeneratorB2 = GeneratorB;
            List<long> JudgeA = new List<long>();
            List<long> JudgeB = new List<long>();
            for (int i = 1; i <= 40000000; i++)
            {
                GeneratorA = GeneratorA * 16807 % 2147483647;
                GeneratorB = GeneratorB * 48271 % 2147483647;
                if (GeneratorA % 65536 == GeneratorB % 65536)
                    Sum++;
            }
            while (JudgeA.Count < 5000000)
            {
                GeneratorA2 = GeneratorA2 * 16807 % 2147483647;
                if (GeneratorA2 % 4 == 0)
                    JudgeA.Add(GeneratorA2);
            }
            while (JudgeB.Count < 5000000)
            {
                GeneratorB2 = GeneratorB2 * 48271 % 2147483647;
                if (GeneratorB2 % 8 == 0)
                    JudgeB.Add(GeneratorB2);
            }
            for (int i = 0; i < 5000000; i++)

                if (JudgeA[i] % 65536 == JudgeB[i] % 65536)
                    Sum2++;
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }

    }
}