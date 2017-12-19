using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2017
{
    class Day19
    {
        private string Input;
        private string[] Instructions;
        Stopwatch stopWatch = new Stopwatch();
        public char[,] TheGrid = new char[201,201];
        public Day19(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "_");
            Instructions = Input.Split('_');
            for (int x = 0; x<=200;x++)
                for(int y = 0; y <= 200; y++)
                {
                    TheGrid[y, x] = Instructions[x][y];
                }
        }

        public string Result()
        {
            string Sum = "";
            int Sum2 = 0;
            Coordinate CurrentPosition = new Coordinate(0,0);
            Coordinate Direction = new Coordinate(0,1);
            Coordinate TestPosition;
            Coordinate IncomingDirection;
            bool DirectionFound = false;
            bool EndFound = false;
            int DirectionCounter;
            for (int i = 0; i <= 200; i++)
            {
                if (TheGrid[i, 0] == '|')
                    CurrentPosition = new Coordinate(i,0);
            }
            while(!EndFound)
            {
                Sum2++;
                DirectionCounter = 0;
                DirectionFound = false;
                IncomingDirection = new Coordinate(Direction.X * -1, Direction.Y * -1);
                while (!DirectionFound)
                {
                    TestPosition = new Coordinate(CurrentPosition.X, CurrentPosition.Y);
                    TestPosition.Add(Direction);
                    if (TheGrid[TestPosition.X, TestPosition.Y] != ' ')
                    {
                        DirectionFound = true;
                    }
                    else
                    {
                        Direction = DirectionChange(Direction);
                        DirectionCounter++;
                        if (Direction.X == IncomingDirection.X && Direction.Y ==IncomingDirection.Y)
                        {
                            Direction = DirectionChange(Direction);
                            DirectionCounter++;
                        }
                    }
                    if (DirectionCounter > 3)
                    {
                        EndFound = true;
                        break;
                    }
                }
                CurrentPosition.Add(Direction);
                if (Char.IsLetter(TheGrid[CurrentPosition.X, CurrentPosition.Y]))
                    Sum += TheGrid[CurrentPosition.X, CurrentPosition.Y];
            }

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
        Coordinate DirectionChange(Coordinate c)
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

    }
}
