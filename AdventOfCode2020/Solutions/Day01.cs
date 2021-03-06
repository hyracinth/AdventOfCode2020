﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Solutions
{
    public class Day01 : IDay
    {
        public string SolveP1()
        {
            int target = 2020;

            List<string> inputsRaw = AoCUtils.readInputFile(this.GetType().Name.Substring(3)).ToList();
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

            List<string> inputsRaw = AoCUtils.readInputFile(this.GetType().Name.Substring(3)).ToList();
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

        public string SolveP3()
        {
            int target = 3232322;

            List<string> inputsRaw = AoCUtils.readInputFile("01_3").ToList();
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
                            long temp1 = inputs[ii];
                            long temp2 = inputs[jj];
                            long temp3 = inputs[kk];
                            long prodResult = temp1 * temp2 * temp3;
                            return prodResult.ToString();
                        }
                    }
                }
            }

            return null;
        }
    }
}
