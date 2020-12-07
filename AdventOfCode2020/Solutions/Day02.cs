using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Solutions
{
    public class Day02 : IDay
    {
        public string SolveP1()
        {
            int count = 0;

            List<string> inputsRaw = Utils.readInputFile(2).ToList();
            foreach (string currPair in inputsRaw)
            {
                string[] components = currPair.Split(' ');

                string[] passLengths = components[0].Split('-');
                int min = Int32.Parse(passLengths[0]);
                int max = Int32.Parse(passLengths[1]);

                char reqChar = components[1].ToCharArray().First();

                List<char> password = components[2].ToCharArray().ToList();
                int charCount = password.Where(x => x == reqChar).Count();

                if (charCount <= max && charCount >= min)
                {
                    count++;
                }
            }

            return count.ToString();
        }

        public string SolveP2()
        {
            int count = 0;

            List<string> inputsRaw = Utils.readInputFile(2).ToList();
            foreach (string currPair in inputsRaw)
            {
                string[] components = currPair.Split(' ');

                string[] passLengths = components[0].Split('-');
                int min = Int32.Parse(passLengths[0]);
                int max = Int32.Parse(passLengths[1]);

                char reqChar = components[1].ToCharArray().First();

                char[] password = components[2].ToCharArray();
                List<char> charsAtInd = new List<char>() { password[min - 1], password[max - 1] };
                int charCount = charsAtInd.Where(x => x == reqChar).Count();

                if (charCount == 1)
                {
                    count++;
                }
            }

            return count.ToString();
        }
    }
}
