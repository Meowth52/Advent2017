﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2017
{
    class PictureSegment3x3
    {
        bool[,] Grid = new bool[3,3];
        public PictureSegment3x3(string[] s)
        {
            string NoSlashString = s[0].Replace("/","");
            for(int i = 0; i < 9; i++)
            {
                if (NoSlashString[i] == '#')
                    Grid[(i / 3), (i % 3)] = true;
                else
                    Grid[(i / 3), (i % 3)] = false;
            }
        }
        public PictureSegment3x3(string s)
        {
            string NoSlashString = s.Replace("/", "");
            for (int i = 0; i < 9; i++)
            {
                if (NoSlashString[i] == '#')
                    Grid[(i / 3), (i % 3)] = true;
                else
                    Grid[(i / 3), (i % 3)] = false;
            }
        }
        public bool isMatch(string s)
        {
            bool[,] MatchGrid = new bool[3,3];
            int MatchNumber;
            string NoSlashString = s.Replace("/", "");
            MatchNumber = 0;
            for (int i = 0; i < 9; i++)
            {
                if (NoSlashString[i] == '#')
                    Grid[(i / 3), (i % 3)] = true;
                else
                    Grid[(i / 3), (i % 3)] = false;
            }
            for (int x = 0; x <= 2; x++)
                for (int y = 0; y <= 2; y++)
                    if (Grid[x, y] == MatchGrid[y, x])
                        MatchNumber++;
            if (MatchNumber == 9)
                return true;
            MatchNumber = 0;
            for (int x = 0; x <= 2; x++)
                for (int y = 0; y <= 2; y++)
                    if (Grid[x, y] == MatchGrid[x, y])
                        MatchNumber++;
            if (MatchNumber == 9)
                return true;
            MatchNumber = 0;
            for (int x = 0; x <= 2; x++)
                for (int y = 0; y <= 2; y++)
                    if (Grid[x, y] == MatchGrid[(y-2)*-1, (x-2)*-1])
                        MatchNumber++;
            if (MatchNumber == 9)
                return true;
            MatchNumber = 0;
            for (int x = 0; x <= 2; x++)
                for (int y = 0; y <= 2; y++)
                    if (Grid[x, y] == MatchGrid[(y-2)*-1, (x-2)*-1])
                        MatchNumber++;
            if (MatchNumber == 9)
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
    }
}