using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Solutions
{
    public class Day03 : IDay
    {
        public string SolveP1()
        {
            return getTrees(3, 1).ToString();
        }

        public string SolveP2()
        {
            long prod1 = getTrees(1, 1);
            long prod2 = getTrees(3, 1);
            long prod3 = getTrees(5, 1);
            long prod4 = getTrees(7, 1);
            long prod5 = getTrees(1, 2);

            long prodTotal = prod1 * prod2 * prod3 * prod4 * prod5;
            return prodTotal.ToString();
        }

        public int getTrees(int xStep, int yStep)
        {
            string[] inputsRaw = AoCUtils.readInputFile("03");
            int width = inputsRaw[0].Length;

            int currX = 0;
            int currY = 0;

            int countTree = 0;

            while (currY < inputsRaw.Length - 1)
            {
                currX += xStep;
                currY += yStep;

                if (currX > width - 1)
                {
                    currX = currX % width;
                }

                if (inputsRaw[currY][currX] == '#')
                {
                    countTree++;
                }
            }

            return countTree;
        }

        public string SolveP3()
        {
            return "Not yet implemented";
        }
    }
}
