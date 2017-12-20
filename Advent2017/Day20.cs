using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Advent2017
{
    class Day20
    {
        private string Input;
        private string[] Instructions;
        List<Particle> Particles = new List<Particle>();
        Stopwatch stopWatch = new Stopwatch();
        public Day20(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "_");
            Instructions = Input.Split('_');
        }

        public string Result()
        {
            long SmallestAcceleration = 1000;
            int Iterator = 0;
            string Sum = "";
            int Sum2 = 0;
            foreach(string s in Instructions)
            {
                if (s != "")
                {
                    Particles.Add(new Particle(s,Iterator));
                }
                Iterator++;
            }
            foreach(Particle p in Particles)
            {
                if (p.AccelerationSum() < SmallestAcceleration)
                {
                    SmallestAcceleration = p.AccelerationSum();
                    Sum = p.GetID();
                }
            }
            List<string> Positions = new List<string>();
            List<string> BadPositions = new List<string>();
            List<Particle> SurvivingParticles = new List<Particle>();
            for (int i = 1; i <= 1000; i++)
            {
                Positions.Clear();
                BadPositions.Clear();
                foreach (Particle p in Particles)
                {
                    p.UpdatePosition();
                    string positionsString = p.GetPositionString();
                    if (Positions.Contains(positionsString))
                        BadPositions.Add(positionsString);
                    Positions.Add(positionsString);
                }
                foreach(Particle p in Particles)
                {
                    if (!BadPositions.Contains(p.GetPositionString()))
                        SurvivingParticles.Add(p);
                }
                Particles = new List<Particle>(SurvivingParticles);
                SurvivingParticles.Clear();
            }
            Sum2 = Particles.Count;
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum + " och del 2: " + Sum2 + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
    }
}
