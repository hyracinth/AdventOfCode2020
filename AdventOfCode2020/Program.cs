using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            int maxDay = 11;
            for(int ii = 1; ii <= maxDay; ii++)
            {
                string currDay = ii.ToString("D2");
                string currDayClass = classTemplate.Replace("#", currDay);

                Stopwatch sw = new Stopwatch();
                IDay instantiatedDay = Activator.CreateInstance(Type.GetType(currDayClass)) as IDay;

                sw.Start();
                string p1 = instantiatedDay.SolveP1();
                long p1Time = sw.ElapsedMilliseconds;
                sw.Stop();

                sw.Reset();
                sw.Start();
                string p2 = instantiatedDay.SolveP2();
                long p2Time = sw.ElapsedMilliseconds;
                sw.Stop();

                sw.Reset();
                sw.Start();
                string p3 = instantiatedDay.SolveP3();
                long p3Time = sw.ElapsedMilliseconds;
                sw.Stop();

                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Day {currDay}");
                sb.AppendLine($"Part 1: {p1Time:D4}ms {p1}");
                sb.AppendLine($"Part 2: {p2Time:D4}ms {p2}");
                sb.AppendLine($"Part 3: {p3Time:D4}ms {p3}");

                Console.WriteLine(sb.ToString());
            }
        }
    }
}
