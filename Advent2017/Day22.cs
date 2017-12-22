using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;

namespace Advent2017
{
    class Day22
    {
        private string Input;
        private string[] Instructions;
        Stopwatch stopWatch = new Stopwatch();
        bool[,] TheGrid = new bool[1000,1000];
        public Day22(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "_");
            Instructions = Input.Split('_');
            for(int y = 0; y < 25; y++)
            {
                for (int x = 0; x < 25; x++)
                {
                    if (Instructions[y][x] == '#')
                        TheGrid[x+500, 525-y] = true;
                }
            }
        }

        public string Result()
        {
            Coordinate CurrentPosition = new Coordinate(512, 512);
            Coordinate Direction = new Coordinate(0, 1);
            int Sum = 0;
            int Sum2 = 0;
            for(int i = 0; i < 10000; i++)
            {
                if (TheGrid[CurrentPosition.X, CurrentPosition.Y])
                {
                    Direction = TurnRight(Direction);
                    TheGrid[CurrentPosition.X, CurrentPosition.Y] = false;
                }
                else
                {
                    Direction = TurnLeft(Direction);
                    TheGrid[CurrentPosition.X, CurrentPosition.Y] = true;
                    Sum++;
                }
                CurrentPosition.Add(Direction);
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }

        Coordinate TurnLeft(Coordinate c)
        {
            if (c.X == 1 && c.Y == 0)
                return new Coordinate(0, 1);
            if (c.X == 0 && c.Y == 1)
                return new Coordinate(-1, 0);
            if (c.X == -1 && c.Y == 0)
                return new Coordinate(0, -1);
            if (c.X == 0 && c.Y == -1)
                return new Coordinate(1, 0);
            return new Coordinate(-2, -2);
        }
        Coordinate TurnRight(Coordinate c)
        {
            if (c.X == 1 && c.Y == 0)
                return new Coordinate(0, -1);
            if (c.X == 0 && c.Y == 1)
                return new Coordinate(1, 0);
            if (c.X == -1 && c.Y == 0)
                return new Coordinate(0, 1);
            if (c.X == 0 && c.Y == -1)
                return new Coordinate(-1, 0);
            return new Coordinate(-2, -2);
        }

    }
}
