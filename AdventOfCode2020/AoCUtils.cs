using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    public static class AoCUtils
    {
        public static string[] readInputFile(string day, Boolean addTrailingLine = false)
        {
            string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string[] inputsRaw = File.ReadAllLines(directoryName + $"/Inputs/input_Day{day}.txt");
            if (addTrailingLine)
            {
                List<string> inputsProcessed = inputsRaw.ToList();
                inputsProcessed.Add("");
                inputsRaw = inputsProcessed.ToArray();
            }
            return inputsRaw;
        }
    }
}
