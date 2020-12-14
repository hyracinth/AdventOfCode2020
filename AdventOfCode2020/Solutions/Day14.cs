using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Solutions
{
    public class Day14 : IDay
    {
        public string SolveP1()
        {
            string[] inputsRaw = AoCUtils.readInputFile(this.GetType().Name.Substring(3));

            Dictionary<int, string> memoryContents = new Dictionary<int, string>();
            string currMask = "";
            foreach (string currLine in inputsRaw)
            {
                string[] components = currLine.Split(new string[] {" = "}, StringSplitOptions.None);
                string instr = components[0];
                long memValue;

                // If mask, set current mask
                // If mem, get memory address and value
                //  Get value in binary string and use mask
                //    If mask is X, take current value, else take mask value
                // Add result to dictionary<memory address, value>
                if(instr == "mask")
                {
                    currMask = components[1];
                }
                else if(instr.StartsWith("mem"))
                {
                    int brackInd = instr.IndexOf('[');
                    int memLoc = Int32.Parse(instr.Substring(brackInd+1, instr.Length - brackInd - 2));
                    memValue = long.Parse(components[1]);

                    string[] result = new string[currMask.Length];
                    string binVal = Convert.ToString(memValue, 2);
                    binVal = binVal.PadLeft(currMask.Length, '0');

                    for (int ii = 0; ii < binVal.Length; ii++)
                    {
                        if (currMask[ii] == 'X')
                        {
                            result[ii] = binVal[ii].ToString();
                        }
                        else
                        {
                            result[ii] = currMask[ii].ToString();
                        }
                    }

                    StringBuilder sb = new StringBuilder();
                    foreach (string currVal in result)
                    {
                        sb.Append(currVal);
                    }

                    if (!memoryContents.ContainsKey(memLoc))
                    {
                        memoryContents.Add(memLoc, sb.ToString());
                    } 
                    else
                    {
                        memoryContents[memLoc] = sb.ToString();
                    }
                }
            }

            long runningSum = 0; 
            foreach(KeyValuePair<int, string> kvp in memoryContents)
            {
                runningSum += Convert.ToInt64(kvp.Value, 2);
            }

            return runningSum.ToString();
        }

        public string SolveP2()

        {
            string[] inputsRaw = AoCUtils.readInputFile(this.GetType().Name.Substring(3));

            Regex regex = new Regex("X");
            Dictionary<long, long> memoryContents = new Dictionary<long, long>();
            string currMask = "";
            foreach (string currLine in inputsRaw)
            {
                string[] components = currLine.Split(new string[] { " = " }, StringSplitOptions.None);
                string instr = components[0];
                long memValue;

                // If mask, set current mask
                // If mem, get memory address in binary
                //  Iterate through mask
                //    If 0 then take address value
                //    If 1 then set 1
                //    If X set "float"
                if (instr == "mask")
                {
                    currMask = components[1];
                }
                else if (instr.StartsWith("mem"))
                {
                    int brackInd = instr.IndexOf('[');
                    int memLoc = Int32.Parse(instr.Substring(brackInd + 1, instr.Length - brackInd - 2));
                    memValue = long.Parse(components[1]);

                    string[] result = new string[currMask.Length];
                    string address = Convert.ToString(memLoc, 2);
                    address = address.PadLeft(currMask.Length, '0');

                    for (int ii = 0; ii < address.Length; ii++)
                    {
                        switch(currMask[ii])
                        {
                            case '0':
                                result[ii] = address[ii].ToString();
                                break;
                            case '1':
                                result[ii] = "1";
                                break;
                            case 'X':
                                result[ii] = "X";
                                break;
                        }
                    }

                    StringBuilder sb = new StringBuilder();
                    foreach (string currVal in result)
                    {
                        sb.Append(currVal);
                    }

                    // Keep a list of "complete" addresses (no X)
                    // Keep a queue of "incomplete" addresses (has X)
                    List<string> listAddresses = new List<string>();
                    Queue<string> queue = new Queue<string>();
                    queue.Enqueue(sb.ToString());
                    
                    // Iterate through 0 and 1 and replace first instance of X
                    //  If memory address still has X, then add to queue, else add to list
                    while(queue.Count > 0)
                    {
                        string currFloat = queue.Dequeue();
                        int ind = currFloat.IndexOf('X');
                        foreach(string binNum in new[] { "0", "1" })
                        {
                            string tempAddress = regex.Replace(currFloat, binNum, 1);
                            if(tempAddress.IndexOf('X') == -1)
                            {
                                listAddresses.Add(tempAddress);
                            }
                            else
                            {
                                queue.Enqueue(tempAddress);
                            }
                        }
                    }

                    // Add / Update each memory address with the value
                    foreach(string memAddress in listAddresses)
                    {
                        long memAddr = Convert.ToInt64(memAddress, 2);
                        if(memoryContents.ContainsKey(memAddr))
                        {
                            memoryContents[memAddr] = memValue;
                        }
                        else
                        {
                            memoryContents.Add(memAddr, memValue);
                        }
                    }
                }
            }

            long runningSum = 0;
            foreach (KeyValuePair<long, long> kvp in memoryContents)
            {
                runningSum += kvp.Value;
            }
            return runningSum.ToString();
        }

        public string SolveP3()
        {
            return "Not yet available";
        }
    }
}
