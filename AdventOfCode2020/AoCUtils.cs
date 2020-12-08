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
        public static string[] readInputFile(string day)
        {
            string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return File.ReadAllLines(directoryName + $"/Inputs/input_Day{day}.txt");
        }
    }
}
