using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Solutions
{
    public class Day04 : IDay
    {
        public string SolveP1()
        {
            string[] inputsRaw = AoCUtils.readInputFile(4.ToString("D2"));

            int count = 0;

            Boolean hasByr = false;
            Boolean hasIyr = false;
            Boolean hasEyr = false;
            Boolean hasHgt = false;
            Boolean hasHcl = false;
            Boolean hasEcl = false;
            Boolean hasPid = false;

            foreach(string currLine in inputsRaw)
            {
                if(currLine == "")
                {
                    if(hasByr && hasIyr && hasEyr && hasHgt && hasHcl && hasEcl && hasPid)
                    {
                        count++;
                    }

                    hasByr = false;
                    hasIyr = false;
                    hasEyr = false;
                    hasHgt = false;
                    hasHcl = false;
                    hasEcl = false;
                    hasPid = false;

                    continue;
                }

                string[] lineComponents = currLine.Split(' ');
                foreach(string currComponent in lineComponents)
                {
                    string[] currPair = currComponent.Split(':');
                    switch (currPair[0])
                    {
                        case "byr":
                            hasByr = true;
                            break;
                        case "iyr":
                            hasIyr = true;
                            break;
                        case "eyr":
                            hasEyr = true;
                            break;
                        case "hgt":
                            hasHgt = true;
                            break;
                        case "hcl":
                            hasHcl = true;
                            break;
                        case "ecl":
                            hasEcl = true;
                            break;
                        case "pid":
                            hasPid = true;
                            break;
                    }
                }
            }

            return count.ToString();
        }

        public string SolveP2()
        {
            // List<string> inputsRaw = AoCUtils.readInputFile(1).ToList();

            return "Not yet implemented";
        }

        public string SolveP3()
        {
            return "Not yet implemented";
        }
    }
}
