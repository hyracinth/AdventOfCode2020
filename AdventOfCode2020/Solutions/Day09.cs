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
    public class Day09 : IDay
    {
        public string SolveP1()
        {
            long[] inputsRaw = AoCUtils.readInputFile(this.GetType().Name.Substring(3)).ToList().Select(x => long.Parse(x)).ToArray();
            int preambleCount = 25;
            long invalidNum = long.MinValue;

            for(int ii = preambleCount - 1; ii < inputsRaw.Length - 1; ii++)
            {
                Boolean validNext = false;
                for(int jj = 0; jj < preambleCount; jj++)
                {
                    if(inputsRaw[ii - jj] > inputsRaw[ii + 1])
                    {
                        continue;
                    }

                    for(int kk = 1; kk < preambleCount; kk++)
                    {
                        if (jj == kk || inputsRaw[ii - kk] > inputsRaw[ii + 1])
                        {
                            continue;
                        }

                        if(inputsRaw[ii - jj] + inputsRaw[ii - kk] == inputsRaw[ii + 1])
                        {
                            validNext = true;
                            break;
                        }
                    }

                    if(validNext)
                    {
                        break;
                    }
                }
                
                if(!validNext)
                {
                    invalidNum = inputsRaw[ii + 1];
                    break;
                }
            }

            return invalidNum.ToString();
        }

        public string SolveP2()
        {
            long[] inputsRaw = AoCUtils.readInputFile(this.GetType().Name.Substring(3)).ToList().Select(x => long.Parse(x)).ToArray();
            int invalidId = 539;
            long invalidNum = inputsRaw[invalidId];

            Boolean foundWeakness = false;
            long runningSum = 0;
            long runningCount = 0;
            int lastId = 0;
            List<long> weaknessList = new List<long>();

            for (int ii = 0; ii < inputsRaw.Length; ii++)
            {
                if(foundWeakness)
                {
                    break;
                }
                runningSum = 0;
                runningCount = 0;
                for(int jj = ii; jj < inputsRaw.Length; jj++)
                {
                    if (runningSum > invalidNum)
                    {
                        break;
                    }
                    runningSum += inputsRaw[jj];
                    runningCount++;

                    if (runningSum == invalidNum)
                    {
                        lastId = jj;
                        foundWeakness = true;
                        break;
                    }
                }
            }

            for(int ii = 0; ii < runningCount; ii++)
            {
                weaknessList.Add(inputsRaw[lastId - ii]);
            }

            long weakness = weaknessList.Min() + weaknessList.Max();

            return weakness.ToString();
        }

        public string SolveP3()
        {
            return "Not yet available";
        }
    }
}
