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
    public class Day06 : IDay
    {
        public string SolveP1()
        {
            string[] inputsRaw = AoCUtils.readInputFile("06", true);

            HashSet<char> currGrpAnswers = new HashSet<char>();
            int runningSum = 0;

            foreach(string currLine in inputsRaw)
            {
                if(currLine == "")
                {
                    runningSum += currGrpAnswers.Count();
                    currGrpAnswers.Clear();
                    continue;
                }

                foreach(char currAns in currLine)
                {
                    currGrpAnswers.Add(currAns);
                }
            }

            return runningSum.ToString();
        }

        public string SolveP2()
        {
            string[] inputsRaw = AoCUtils.readInputFile("06", true);

            int runningSum = 0;
            int groupMemCount = 0;
            Dictionary<char, int> groupAnswers = new Dictionary<char, int>();

            foreach (string currLine in inputsRaw)
            {
                if (currLine == "")
                {
                    int groupSum = 0;
                    foreach(KeyValuePair<char, int> kvp in groupAnswers)
                    {
                        if(kvp.Value == groupMemCount)
                        {
                            groupSum++;
                        }
                    }
                    runningSum += groupSum;

                    groupMemCount = 0;
                    groupAnswers.Clear();
                    continue;
                }

                groupMemCount++;
                foreach (char currAns in currLine)
                {
                    if(groupAnswers.ContainsKey(currAns))
                    {
                        groupAnswers[currAns]++;
                    }
                    else
                    {
                        groupAnswers.Add(currAns, 1);
                    }
                }
            }

            return runningSum.ToString();
        }

        public string SolveP3()
        {
            return "Not yet available";
        }
    }
}
