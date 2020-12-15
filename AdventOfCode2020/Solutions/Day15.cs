using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Solutions
{
    public class Day15 : IDay
    {
        public string SolveP1()
        {
            return this.day15("19,20,14,0,9,1", 2020).ToString();
        }

        public string SolveP2()
        {
            return this.day15("19,20,14,0,9,1", 30000000).ToString();
        }

        public string SolveP3()
        {
            return "Not yet available";
        }

        public long day15(string input, long target)
        {
            List<int> inputsRaw = input.Split(',').ToList().Select(x => Int32.Parse(x)).ToList();
            //List<int> inputsRaw = "2,1,3".Split(',').ToList().Select(x => Int32.Parse(x)).ToList();

            int currTurn = 0;
            Dictionary<long, Queue<long>> listAges = new Dictionary<long, Queue<long>>();
            for (int ii = 0; ii < inputsRaw.Count(); ii++)
            {
                Queue<long> currQueue = new Queue<long>();
                currQueue.Enqueue(++currTurn);
                listAges.Add(inputsRaw[ii], currQueue);
            }

            long prevNum = inputsRaw.Last();

            while (currTurn < target)
            {
                currTurn++;
                long currentNum = 0; // if (listAges.ContainsKey(prevNum) && listAges[prevNum].Count() == 1)
                if (listAges.ContainsKey(prevNum) && listAges[prevNum].Count() > 1)
                {
                    currentNum = listAges[prevNum].Last() - listAges[prevNum].First();
                }

                if (listAges.ContainsKey(currentNum))
                {
                    listAges[currentNum].Enqueue(currTurn);
                    if (listAges[currentNum].Count > 2)
                    {
                        listAges[currentNum].Dequeue();
                    }
                }
                else if (!listAges.ContainsKey(currentNum))
                {
                    Queue<long> currQueue = new Queue<long>();
                    currQueue.Enqueue(currTurn);
                    listAges.Add(currentNum, currQueue);
                }
                prevNum = currentNum;

            }
            return prevNum;
        }
    }
}
