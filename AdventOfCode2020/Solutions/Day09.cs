using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Solutions
{
    public class Day09 : IDay
    {
        public string SolveP1()
        {
            long[] inputsRaw = AoCUtils.readInputFile(this.GetType().Name.Substring(3)).ToList().Select(x => long.Parse(x)).ToArray();
            int preambleCount = 25;
            long invalidNum = long.MinValue;

            // Iterate through array starting from the 25th (preamble) element
            //  On each element, iterate the preceeding 25 elements while checking to see if any two elements sum up to next number
            for(int ii = preambleCount - 1; ii < inputsRaw.Length - 1; ii++)
            {
                Boolean validNext = false;
                for(int jj = 0; jj < preambleCount; jj++)
                {
                    // If a previous number is larger than target number, skip (no negatives so impossible to sum)
                    if(inputsRaw[ii - jj] > inputsRaw[ii + 1])
                    {
                        continue;
                    }

                    for(int kk = 1; kk < preambleCount; kk++)
                    {
                        // If indices are the same or a previous number is larger than target number, skip (no negatives so impossible to sum)
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
            
            // Invalid number from previous part
            long invalidNum = inputsRaw[539];

            Boolean foundWeakness = false;
            long runningSum = 0;
            long runningCount = 0;
            int lastId = 0;
            List<long> weaknessList = new List<long>();

            // Iterate through list while looking for consecutive numbers that will sum to the target (invalidNum)
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

            // Add to list to get min/max
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
