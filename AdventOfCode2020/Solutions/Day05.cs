using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2020.Solutions
{
    public class Day05 : IDay
    {
        public string SolveP1()
        {
            string[] inputsRaw = AoCUtils.readInputFile(this.GetType().Name.Substring(3));

            int maxId = 0;
            int maxRow = 127;
            int maxCol = 7;

            foreach (string currLine in inputsRaw)
            {
                double rowStart = 0;
                double rowEnd = maxRow;
                for(int ii = 0; ii < 7; ii++)
                {
                    if(currLine[ii] == 'F')
                    {
                        rowEnd = rowEnd - Math.Ceiling((rowEnd - rowStart) / 2);
                    }
                    else
                    {
                        rowStart = rowStart + Math.Ceiling((rowEnd - rowStart) / 2);
                    }
                }

                double colStart = 0;
                double colEnd = maxCol;
                for(int ii = 7; ii < currLine.Length; ii++)
                {
                    if (currLine[ii] == 'L')
                    {
                        colEnd = colEnd - Math.Ceiling((colEnd - colStart) / 2);
                    }
                    else
                    {
                        colStart = colStart + Math.Ceiling((colEnd - colStart) / 2);
                    }
                }

                int currId = (int)(rowStart * 8 + colStart);
                if(currId > maxId)
                {
                    maxId = currId;
                }
            }

            return maxId.ToString();
        }

        public string SolveP2()
        {
            string[] inputsRaw = AoCUtils.readInputFile(this.GetType().Name.Substring(3));

            List<int> seatIds = new List<int>();

            int maxRow = 127;
            int maxCol = 7;

            foreach (string currLine in inputsRaw)
            {
                double rowStart = 0;
                double rowEnd = maxRow;
                for (int ii = 0; ii < 7; ii++)
                {
                    if (currLine[ii] == 'F')
                    {
                        rowEnd = rowEnd - Math.Ceiling((rowEnd - rowStart) / 2);
                    }
                    else
                    {
                        rowStart = rowStart + Math.Ceiling((rowEnd - rowStart) / 2);
                    }
                }

                double colStart = 0;
                double colEnd = maxCol;
                for (int ii = 7; ii < currLine.Length; ii++)
                {
                    if (currLine[ii] == 'L')
                    {
                        colEnd = colEnd - Math.Ceiling((colEnd - colStart) / 2);
                    }
                    else
                    {
                        colStart = colStart + Math.Ceiling((colEnd - colStart) / 2);
                    }
                }

                seatIds.Add((int)(rowStart * 8 + colStart));
            }

            int theSeat = 0;
            seatIds.Sort();
            for(int ii = 0; ii < seatIds.Count() - 1; ii++)
            {
                if(seatIds[ii + 1] - seatIds[ii] != 1)
                {
                    theSeat = seatIds[ii] + 1;
                }
            }

            return theSeat.ToString();
        }

        public string SolveP3()
        {
            return "Not yet available";
        }
    }
}
