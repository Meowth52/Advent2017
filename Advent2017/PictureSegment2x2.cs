﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2017
{
    class PictureSegment2x2
    {
        bool[,] Grid = new bool[2, 2];
        public PictureSegment2x2(string[] s)
        {
            string NoSlashString = s[0].Replace("/", "");
            for (int i = 0; i < 4; i++)
            {
                if (NoSlashString[i] == '#')
                    Grid[(i / 2), (i % 2)] = true;
                else
                    Grid[(i / 2), (i % 2)] = false;
            }
        }
        public PictureSegment2x2(string s)
        {
            string NoSlashString = s.Replace("/", "");
            for (int i = 0; i < 4; i++)
            {
                if (NoSlashString[i] == '#')
                    Grid[(i / 2), (i % 2)] = true;
                else
                    Grid[(i / 2), (i % 2)] = false;
            }
        }
        public string PrintOne()
        {
            StringBuilder s = new StringBuilder();

            for (int i = 0;i <= 1 ; i++)
                if (Grid[0,i])
                    s.Append('#');
                else
                    s.Append('.');
            return s.ToString();
        }
        public string PrintTwo()
        {
            StringBuilder s = new StringBuilder();

            for (int i = 0; i <= 1; i++)
                if (Grid[1, i])
                    s.Append('#');
                else
                    s.Append('.');
            return s.ToString();
        }
        public bool isMatch(string s)
        {
            bool[,] MatchGrid = new bool[2, 2];
            int MatchNumber;
            string NoSlashString = s.Replace("/", "");
            for (int i = 0; i < 4; i++)
            {
                if (NoSlashString[i] == '#')
                    MatchGrid[(i / 2), (i % 2)] = true;
                else
                    MatchGrid[(i / 2), (i % 2)] = false;
            }
            MatchNumber = 0;
            for (int x = 0; x <= 1; x++)
                for (int y = 0; y <= 1; y++)
                    if (Grid[x, y] == MatchGrid[y, (x - 1) * -1])
                        MatchNumber++;
            if (MatchNumber == 4)
                return true;
            MatchNumber = 0;
            for (int x = 0; x <= 1; x++)
                for (int y = 0; y <= 1; y++)
                    if (Grid[x, y] == MatchGrid[x, y])
                        MatchNumber++;
            if (MatchNumber == 4)
                return true;
            MatchNumber = 0;
            for (int x = 0; x <= 1; x++)
                for (int y = 0; y <= 1; y++)
                    if (Grid[x, y] == MatchGrid[(y - 1) * -1, x])
                        MatchNumber++;
            if (MatchNumber == 4)
                return true;
            MatchNumber = 0;
            for (int x = 0; x <= 1; x++)
                for (int y = 0; y <= 1; y++)
                    if (Grid[x, y] == MatchGrid[(x - 1) * -1,y])
                        MatchNumber++;
            if (MatchNumber == 4)
                return true;
            MatchNumber = 0;
            for (int x = 0; x <= 1; x++)
                for (int y = 0; y <= 1; y++)
                    if (Grid[x, y] == MatchGrid[x, (y - 1) * -1])
                        MatchNumber++;
            if (MatchNumber == 4)
                return true;
            MatchNumber = 0;
            for (int x = 0; x <= 1; x++)
                for (int y = 0; y <= 1; y++)
                    if (Grid[x, y] == MatchGrid[(y - 1) * -1, (x - 1) * -1])
                        MatchNumber++;
            if (MatchNumber == 4)
                return true;
            MatchNumber = 0;
            for (int x = 0; x <= 1; x++)
                for (int y = 0; y <= 1; y++)
                    if (Grid[x, y] == MatchGrid[(x - 1) * -1,(y - 1) * -1])
                        MatchNumber++;
            if (MatchNumber == 4)
                return true;
            MatchNumber = 0;
            for (int x = 0; x <= 1; x++)
                for (int y = 0; y <= 1; y++)
                    if (Grid[x, y] == MatchGrid[y,x])
                        MatchNumber++;
            if (MatchNumber == 4)
                return true;
            return false;
        }
        public int NumberOfTrue()
        {
            int ReturnValue = 0;
            foreach (bool b in Grid)
                if (b)
                    ReturnValue++;
            return ReturnValue;
        }
        public string GetPrintout()
        {
            StringBuilder s = new StringBuilder();

            foreach (bool b in Grid)
                if (b)
                    s.Append('#');
                else
                    s.Append('.');
            return s.ToString();
        }
    }
}
