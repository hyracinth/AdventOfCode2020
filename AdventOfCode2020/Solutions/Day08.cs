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
    public class Day08 : IDay
    {
        public string SolveP1()
        {
            string[] inputsRaw = AoCUtils.readInputFile("08");
            int[] instStatus = new int[inputsRaw.Length];
            int currLine = 0;
            int accumulator = 0;

            while (instStatus[currLine] == 0)
            {
                instStatus[currLine] = 1;
                if(inputsRaw[currLine].StartsWith("nop"))
                {
                    currLine++;
                    continue;
                }

                string[] components = inputsRaw[currLine].Split(' ');
                int multiplier = 1;
                if(components[1][0] == '-')
                {
                    multiplier = -1;
                }

                int num = Int32.Parse(components[1].Substring(1)) * multiplier;

                switch(components[0])
                {
                    case "acc":
                        accumulator += num;
                        currLine++;
                        break;
                    case "jmp":
                        currLine += num;
                        break;
                }
            }

            return accumulator.ToString();
        }

        public string SolveP2()
        {
            Boolean foundSolution = false;
            string[] inputsRaw = AoCUtils.readInputFile("08");
            int accumulator = 0;

            for (int ii = 0; ii < inputsRaw.Length; ii++)
            {
                if(foundSolution)
                {
                    break;
                }

                string[] inputsMod = (string[]) inputsRaw.Clone();
                if(inputsMod[ii].Contains("nop"))
                {
                    inputsMod[ii] = inputsMod[ii].Replace("nop", "jmp");
                }
                else if(inputsMod[ii].Contains("jmp"))
                {
                    inputsMod[ii] = inputsMod[ii].Replace("jmp", "nop");
                }
                else
                {
                    continue;
                }

                int threshold = 5;

                int[] instStatus = new int[inputsMod.Length];
                int currLine = 0;
                int count = 0;
                accumulator = 0;
                while (instStatus[currLine] < threshold)
                {
                    if(currLine == inputsMod.Length - 1)
                    {
                        foundSolution = true;
                        break;
                    }

                    instStatus[currLine]++;
                    if (inputsMod[currLine].StartsWith("nop"))
                    {
                        currLine++;
                        continue;
                    }

                    string[] components = inputsMod[currLine].Split(' ');
                    int multiplier = 1;
                    if (components[1][0] == '-')
                    {
                        multiplier = -1;
                    }

                    int num = Int32.Parse(components[1].Substring(1)) * multiplier;

                    switch (components[0])
                    {
                        case "acc":
                            accumulator += num;
                            currLine++;
                            break;
                        case "jmp":
                            currLine += num;
                            break;
                    }
                }
            }

            return accumulator.ToString();
        }

        public string SolveP3()
        {
            return "Not yet available";
        }
    }
}
