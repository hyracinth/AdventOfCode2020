using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    public static class Utils
    {
        public static string[] readInputFile(int day)
        {
            string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return File.ReadAllLines(directoryName + $"/Inputs/input_Day{day.ToString("D2")}.txt");
        }
    }
}
