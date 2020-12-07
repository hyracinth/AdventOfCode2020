using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Solutions.Day03
{
    public class Day03
    {
        public string SolveP1()
        {
            string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string[] inputsRaw = File.ReadAllLines(directoryName + "/Inputs/input_Day03.txt");

            int width = inputsRaw[0].Length;

            int currX = 0;
            int currY = 0;

            int countOpen = 0;
            int countTree = 0;

            while (currY < inputsRaw.Length - 1)
            {
                currX += 3;
                currY++;

                if(currX > width - 1)
                {
                    currX = currX % width;
                }

                switch(inputsRaw[currY][currX])
                {
                    case '.':
                        countOpen++;
                        break;
                    case '#':
                        countTree++;
                        break;
                }
            }

            return null;
        }

        public string SolveP2()
        {

            return null;
        }
    }
}
