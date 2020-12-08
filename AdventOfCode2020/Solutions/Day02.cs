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

            List<string> inputsRaw = AoCUtils.readInputFile("02").ToList();
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

            List<string> inputsRaw = AoCUtils.readInputFile("02").ToList();
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

        public string SolveP3()
        {
            List<char> resultChar = new List<char>();

            List<string> inputsRaw = AoCUtils.readInputFile("02_3").ToList();
            foreach (string currPair in inputsRaw)
            {
                string[] components = currPair.Split(' ');

                string[] passLengths = components[0].Split('-');
                int startInd = Int32.Parse(passLengths[0]) - 1;
                int endInd = Int32.Parse(passLengths[1]) - 1;

                char reqChar = components[1].ToCharArray().First();

                string passwordFrag = components[2].Substring(startInd, endInd - startInd + 1);

                Boolean isPalindrone = true;
                for(int ii = 0; ii < passwordFrag.Length / 2; ii++)
                {
                    if(passwordFrag[ii] != passwordFrag[passwordFrag.Length - 1 - ii])
                    {
                        isPalindrone = false;
                    }
                }

                // A = 65 : Z = 90
                // a = 97 : z = 122
                if(isPalindrone)
                {
                    char rot13Char;
                    int tempCode = (int)reqChar + 13;
                    if(reqChar <= 122 && reqChar >= 97 && tempCode > 122)
                    {
                        int offset = tempCode - 122;
                        rot13Char = (char)(97 + offset - 1);
                    }
                    else if(reqChar <= 90 && reqChar >= 65 && tempCode > 90)
                    {
                        int offset = tempCode - 90;
                        rot13Char = (char)(65 + offset - 1);
                    }
                    else
                    {
                        rot13Char = (char)tempCode;
                    }

                    resultChar.Add(rot13Char);
                }

            }

            return new string(resultChar.ToArray());
        }
    }
}
