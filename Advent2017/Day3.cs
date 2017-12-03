using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2017
{
    internal class Day3
    {
        private string Input;
        public Day3(string input)
        {
            Input = input;
        }

        public struct Coordinate
        {
            private readonly int x;
            private readonly int y;

            public int X { get { return x; } }
            public int Y { get { return y; } }

            public Coordinate(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public override string ToString()
            {
                return string.Format("{0},{1}", X, Y);
            }
        }
        public string Result()
        {
            int TargetNumber;
            Coordinate Direction = new Coordinate(1,0);
            Coordinate LastPosition = new Coordinate(0, 0);
            Coordinate ThisPosition = new Coordinate();
            Int32.TryParse(Input, out TargetNumber);
            int Sum = 0;
            int Sum2 = 0;
            Dictionary<Coordinate, int> SpiralBank = new Dictionary<Coordinate, int>();
            SpiralBank.Add(new Coordinate(0,0), 1);
            for (int i = 2; i<=TargetNumber; i++)
            {
                ThisPosition = CoordinateSum(LastPosition, Direction);
                SpiralBank.Add(ThisPosition, i);
                Coordinate WantedPosition = CoordinateSum(ThisPosition, DirectionChange(Direction));
                if (!SpiralBank.ContainsKey(WantedPosition))
                    Direction = DirectionChange(Direction);
                LastPosition = ThisPosition;
            }
            Sum = ThisPosition.X + ThisPosition.Y;
            SpiralBank.Clear();
            SpiralBank.Add(new Coordinate(0, 0), 1);
            List<Coordinate> AllAdjantDirections = new List<Coordinate>();
            AllAdjantDirections.Add(new Coordinate(1, 0));
            AllAdjantDirections.Add(new Coordinate(1, 1));
            AllAdjantDirections.Add(new Coordinate(0, 1));
            AllAdjantDirections.Add(new Coordinate(-1, 1));
            AllAdjantDirections.Add(new Coordinate(-1, 0));
            AllAdjantDirections.Add(new Coordinate(-1, -1));
            AllAdjantDirections.Add(new Coordinate(0, -1));
            AllAdjantDirections.Add(new Coordinate(1, -1));
            ThisPosition = new Coordinate(0, 0);
            LastPosition = new Coordinate(0, 0);
            Direction = new Coordinate(1, 0);
            int TestCounter = 0;
            while (Sum2 < TargetNumber)
            {
                ThisPosition = CoordinateSum(LastPosition, Direction);
                foreach(Coordinate c in AllAdjantDirections)
                {
                    if (SpiralBank.ContainsKey(CoordinateSum(c, ThisPosition)))
                        TestCounter += SpiralBank[CoordinateSum(c, ThisPosition)];
                }
                Sum2 = TestCounter;
                TestCounter = 0;
                SpiralBank.Add(ThisPosition, Sum2);
                Coordinate WantedPosition = CoordinateSum(ThisPosition, DirectionChange(Direction));
                if (!SpiralBank.ContainsKey(WantedPosition))
                    Direction = DirectionChange(Direction);
                LastPosition = ThisPosition;
            }
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString();
        }
        Coordinate CoordinateSum(Coordinate A, Coordinate B)
        {
            return (new Coordinate(A.X + B.X, A.Y + B.Y));
        }
        Coordinate DirectionChange(Coordinate c)
        {           
            if (c.X == 1 && c.Y == 0)                
                return new Coordinate(0,1);
            if (c.X == 0 && c.Y == 1)
                return new Coordinate(-1, 0);
            if (c.X == -1 && c.Y == 0)
                return new Coordinate(0, -1);
            if (c.X == 0 && c.Y == -1)
                return new Coordinate(1, 0);
            return new Coordinate(-2,-2);
        }
    }
}