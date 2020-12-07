using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Solutions.Day01
{
    public class Day01
    {
        public string SolveP1()
        {
            int target = 2020;

            string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            List<string> inputsRaw = File.ReadAllLines(directoryName + "/Inputs/input_Day01.txt").ToList();
            List<int> inputs = inputsRaw.Select(x => Int32.Parse(x)).Where(x => x < target).ToList();

            for(int ii = 0; ii < inputs.Count; ii++)
            {
                for(int jj = 0; jj < inputs.Count; jj++)
                {
                    if(ii == jj)
                    {
                        continue;
                    }

                    if(inputs[ii] + inputs[jj] == target)
                    {
                        return (inputs[ii] * inputs[jj]).ToString();
                    }
                }
            }

            return null;
        }

        public string SolveP2()
        {
            int target = 2020;

            string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            List<string> inputsRaw = File.ReadAllLines(directoryName + "/Inputs/input_Day01.txt").ToList();
            List<int> inputs = inputsRaw.Select(x => Int32.Parse(x)).Where(x => x < target).ToList();

            for (int ii = 0; ii < inputs.Count; ii++)
            {
                for (int jj = 0; jj < inputs.Count; jj++)
                {
                    for (int kk = 0; kk < inputs.Count; kk++)
                    {
                        if (ii == jj || ii == kk || jj == kk)
                        {
                            continue;
                        }

                        if (inputs[ii] + inputs[jj] + inputs[kk] == target)
                        {
                            return (inputs[ii] * inputs[jj] * inputs[kk]).ToString();
                        }
                    }
                }
            }

            return null;
        }
    }
}
