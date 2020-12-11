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
    public class Day10 : IDay
    {
        public string SolveP1()
        {
            List<int> inputsRaw = AoCUtils.readInputFile(this.GetType().Name.Substring(3)).Select(x => Int32.Parse(x)).ToList();
            inputsRaw.Sort();

            int joltDiff1 = 0;
            int joltDiff3 = 0;
            int currentJolt = 0;

            foreach (int iterJolt in inputsRaw)
            {
                int currDiff = iterJolt - currentJolt;
                if (currDiff <= 3)
                {
                    switch(currDiff)
                    {
                        case 1:
                            joltDiff1++;
                            break;
                        case 3:
                            joltDiff3++;
                            break;                       
                    }
                    currentJolt = iterJolt;
                }
            }

            // Plus one to account for device adapter
            int result = joltDiff1 * (joltDiff3 + 1);
            return result.ToString();
        }

        public string SolveP2()
        {
            List<int> inputsRaw = AoCUtils.readInputFile(this.GetType().Name.Substring(3)).Select(x => Int32.Parse(x)).ToList();
            inputsRaw.Add(0);
            inputsRaw.Add(inputsRaw.Max() + 3);
            inputsRaw.Sort();

            Dictionary<int, List<int>> adapterDependencies = new Dictionary<int, List<int>>();
            for(int ii = 0; ii < inputsRaw.Count(); ii++)
            {
                int currMax = inputsRaw[ii] + 3;
                List<int> validNums = new List<int>();
                int jj = ii + 1;
                while(jj < inputsRaw.Count() && inputsRaw[jj] <= currMax)
                {
                    validNums.Add(inputsRaw[jj]);
                    jj++;
                }
                adapterDependencies.Add(inputsRaw[ii], validNums);
            }

            Dictionary<int, long> permutations = new Dictionary<int, long>();
            permutations.Add(inputsRaw.Max(), 1);
            for (int ii = inputsRaw.Count() - 2; ii >= 0; ii--)
            {
                long currCount = 0;
                foreach(int depend in adapterDependencies[inputsRaw[ii]])
                {
                    currCount += permutations[depend];
                }
                permutations.Add(inputsRaw[ii], currCount);
            }

            return permutations[0].ToString(); ;
        }

        public string SolveP3()
        {
            return "Not yet available";
        }

        public string SolveP2_Old()
        {
            List<int> inputsRaw = AoCUtils.readInputFile(this.GetType().Name.Substring(3)).Select(x => Int32.Parse(x)).ToList();
            inputsRaw.Add(0);
            inputsRaw.Add(inputsRaw.Max() + 3);
            inputsRaw.Sort();

            Dictionary<int, List<int>> adapterDependencies = new Dictionary<int, List<int>>();
            for (int ii = 0; ii < inputsRaw.Count(); ii++)
            {
                int currMax = inputsRaw[ii] + 3;
                List<int> validNums = new List<int>();
                int jj = ii + 1;
                while (jj < inputsRaw.Count() && inputsRaw[jj] <= currMax)
                {
                    validNums.Add(inputsRaw[jj]);
                    jj++;
                }
                adapterDependencies.Add(inputsRaw[ii], validNums);
            }

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);
            int count = 1;

            while (queue.Count > 0)
            {
                int currAdapter = queue.Dequeue();
                if (adapterDependencies[currAdapter].Count() > 1)
                {
                    count += adapterDependencies[currAdapter].Count() - 1;
                }
                foreach (int currDepends in adapterDependencies[currAdapter])
                {
                    queue.Enqueue(currDepends);
                }
            }

            return count.ToString();
        }
    }
}
