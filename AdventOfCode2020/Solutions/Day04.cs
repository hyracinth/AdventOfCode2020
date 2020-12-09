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
    public class Day04 : IDay
    {
        public string SolveP1()
        {
            string[] inputsRaw = AoCUtils.readInputFile(this.GetType().Name.Substring(3), true);
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
            string[] inputsRaw = AoCUtils.readInputFile(this.GetType().Name.Substring(3), true);
            int count = 0;

            Boolean hasByr = false;
            Boolean hasIyr = false;
            Boolean hasEyr = false;
            Boolean hasHgt = false;
            Boolean hasHcl = false;
            Boolean hasEcl = false;
            Boolean hasPid = false;

            Regex regexHairColor = new Regex("^[a-f0-9]*$");
            List<string> eyeColors = new List<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
            Regex regexPassportId = new Regex("^[0-9]*$");

            foreach (string currLine in inputsRaw)
            {
                if (currLine == "")
                {
                    if (hasByr && hasIyr && hasEyr && hasHgt && hasHcl && hasEcl && hasPid)
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
                foreach (string currComponent in lineComponents)
                {
                    string[] currPair = currComponent.Split(':');
                    switch (currPair[0])
                    {
                        case "byr":
                            int byear = Int32.Parse(currPair[1]);
                            if (byear >= 1920 && byear <= 2002)
                            {
                                hasByr = true;
                            }
                            break;
                        case "iyr":
                            int iyear = Int32.Parse(currPair[1]);
                            if (iyear >= 2010 && iyear <= 2020)
                            {
                                hasIyr = true;
                            }
                            break;
                        case "eyr":
                            int eyear = Int32.Parse(currPair[1]);
                            if (eyear >= 2020 && eyear <= 2030)
                            {
                                hasEyr = true;
                            }
                            break;
                        case "hgt":
                            if (currPair[1].EndsWith("cm") || currPair[1].EndsWith("in"))
                            {
                                int height = Int32.Parse(currPair[1].Substring(0, currPair[1].Length - 2));
                                if ((currPair[1].EndsWith("cm") && height >= 150 && height <= 193) ||
                                    (currPair[1].EndsWith("in") && height >= 59 && height <= 76))
                                {
                                    hasHgt = true;
                                }
                            }
                            break;
                        case "hcl":
                            if(currPair[1].Length == 7 && currPair[1].StartsWith("#") && regexHairColor.IsMatch(currPair[1].Substring(1, currPair[1].Length - 1)))
                            {
                                hasHcl = true;
                            }
                            break;
                        case "ecl":
                            if (eyeColors.Contains(currPair[1]))
                            {
                                hasEcl = true;
                            }
                            break;
                        case "pid":
                            if (currPair[1].Length == 9 && regexPassportId.IsMatch(currPair[1]))
                            {
                                hasPid = true;
                            }
                            break;
                    }
                }
            }

            return count.ToString();
        }

        public string SolveP3()
        {
            return "Not yet available";
        }
    }
}
