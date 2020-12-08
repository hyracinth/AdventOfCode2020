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
    public class Day07 : IDay
    {
        public string SolveP1()
        {
            int count = 0;
            string lookForBag = "shiny gold bag";
            Dictionary<string, List<Tuple<string, int>>> bagsOfMadness = createBagOfMadness();

            foreach (KeyValuePair<string, List<Tuple<string, int>>> kvp in bagsOfMadness)
            {
                Queue<string> queue = new Queue<string>();
                foreach(Tuple<string, int> contents in kvp.Value)
                {
                    queue.Enqueue(contents.Item1);
                }

                while(queue.Count != 0)
                {
                    if(queue.Contains(lookForBag))
                    {
                        count++;
                        queue.Clear();
                        continue;
                    }
                    string currBag = queue.Dequeue();
                    foreach (Tuple<string, int> contents in bagsOfMadness[currBag])
                    {
                        queue.Enqueue(contents.Item1);
                    }
                }
            }
            return count.ToString();
        }

        public string SolveP2()
        {
            int count = 0;
            string lookForBag = "shiny gold bag";
            Dictionary<string, List<Tuple<string, int>>> bagsOfMadness = createBagOfMadness();

            Queue<string> queue = new Queue<string>();
            foreach (Tuple<string, int> contents in bagsOfMadness[lookForBag])
            {
                for (int ii = 0; ii < contents.Item2; ii++)
                {
                    count++;
                    queue.Enqueue(contents.Item1);
                }
            }

            while(queue.Count != 0)
            {
                string currBag = queue.Dequeue();
                foreach (Tuple<string, int> contents in bagsOfMadness[currBag])
                {
                    for (int ii = 0; ii < contents.Item2; ii++)
                    {
                        count++;
                        queue.Enqueue(contents.Item1);
                    }
                }
            }

            return count.ToString();
        }

        public string SolveP3()
        {
            return "Not yet available";
        }

        public Dictionary<string, List<Tuple<string, int>>> createBagOfMadness()
        {
            string[] inputsRaw = AoCUtils.readInputFile("07");
            Dictionary<string, List<Tuple<string, int>>> bagsOfMadness = new Dictionary<string, List<Tuple<string, int>>>();

            foreach (string currLine in inputsRaw)
            {
                string[] components = currLine.Replace(".", "").Split(new string[] { "contain" }, StringSplitOptions.None);
                string mainBag = components[0].Trim();
                if (mainBag.EndsWith("s"))
                {
                    mainBag = mainBag.Substring(0, mainBag.Length - 1);
                }
                if (!bagsOfMadness.ContainsKey(mainBag))
                {
                    List<Tuple<string, int>> contents = new List<Tuple<string, int>>();
                    string[] contentsRaw = components[1].Split(',');

                    if (components[1].Trim() == "no other bags")
                    {
                        bagsOfMadness.Add(mainBag, new List<Tuple<string, int>>());
                    }
                    else
                    {
                        foreach (string currContent in contentsRaw)
                        {
                            int numInd = currContent.Trim().IndexOf(' ');
                            int numBag = Int32.Parse(currContent.Trim().Substring(0, numInd));
                            string bag = currContent.Trim().Substring(numInd + 1);
                            if (bag.EndsWith("s"))
                            {
                                bag = bag.Substring(0, bag.Length - 1);
                            }
                            contents.Add(new Tuple<string, int>(bag, numBag));
                        }
                        bagsOfMadness.Add(mainBag, contents);
                    }
                }
            }
            return bagsOfMadness;
        }
    }
}
