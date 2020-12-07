﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            string classTemplate = "AdventOfCode2020.Solutions.Day#, AdventOfCode2020";

            int maxDay = 3;
            for(int ii = 1; ii <= maxDay; ii++)
            {
                string currDay = ii.ToString("D2");

                Console.WriteLine("Day " + currDay);
                string currDayClass = classTemplate.Replace("#", currDay);

                var instObj = Activator.CreateInstance(Type.GetType(currDayClass)) as IDay;
                Console.WriteLine(instObj.SolveP1());
                Console.WriteLine(instObj.SolveP2());
                Console.WriteLine();
            }
        }
    }

}
