using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Solutions
{
    public class Day13 : IDay
    {
        public string SolveP1()
        {
            string[] inputsRaw = AoCUtils.readInputFile(this.GetType().Name.Substring(3));

            int earliestDeparture = Int32.Parse(inputsRaw[0]);
            int[] availableBusIds = inputsRaw[1].Split(',').ToList().Where(x => x != "x").Select(x => Int32.Parse(x)).ToArray();
            int earliestBusId = 0;
            int currDeparture = earliestDeparture - 1;
            while(earliestBusId == 0)
            {
                currDeparture++;
                foreach (int currBusId in availableBusIds)
                {
                    if(currDeparture % currBusId == 0)
                    {
                        earliestBusId = currBusId;
                        break;
                    }
                }
            }

            int result = (currDeparture - earliestDeparture) * earliestBusId;
            return result.ToString();
        }

        // Chinese Remainder Theorem https://www.youtube.com/watch?v=zIFehsBHB8o
        // 7,13,x,x,59,x,31,19 > 1068788
        // 17,x,13,19 > 3417
        // 67,7,59,61 > 754018
        // 67,x,7,59,61 > 779210
        public string SolveP2()
        {
            string[] inputsRaw = AoCUtils.readInputFile(this.GetType().Name.Substring(3));

            string[] busesRaw = inputsRaw[1].Split(',');
            // List of <modulos, remainders>
            List<Tuple<long, long>> availableBusIds = new List<Tuple<long, long>>();
            for (long ii = 0; ii < busesRaw.Length; ii++) 
            {
                if(busesRaw[ii] != "x")
                {
                    availableBusIds.Add(new Tuple<long, long>(long.Parse(busesRaw[ii]), long.Parse(busesRaw[ii]) - ii));
                }
            }

            long N = 1;
            long runningSum = 0;

            // Calculate N (product of all modulos)
            for (int ii = 0; ii < availableBusIds.Count(); ii++)
            {
                N *= availableBusIds[ii].Item1;
            }

            // bi = modulo
            // Ni = N / bi
            // xi = inverse mod of (Ni, remainder)
            for(int ii = 0; ii < availableBusIds.Count(); ii++)
            {
                long bi = availableBusIds[ii].Item2;
                long Ni = N / availableBusIds[ii].Item1;
                long xi = this.modInverse(Ni, availableBusIds[ii].Item1);

                runningSum += (bi * Ni * xi);
            }

            // Get smaller positive number
            long result = runningSum % N;
            return result.ToString();
        }

        public string SolveP3()
        {
            return "Not yet available";
        }

        private long modInverse(long a, long m)
        {
            a %= m;
            for (long x = 1; x < m; x++)
            {
                if ((a * x) % m == 1)
                {
                    return x;
                }
            }
            return 1;
        }

        // Impossible solution, would take hours
        public string SolveP2_Old()
        {
            string[] inputsRaw = AoCUtils.readInputFile(this.GetType().Name.Substring(3));

            inputsRaw = new string[]
            {
                "939", "7,13,x,x,59,x,31,19"
            };

            string[] busesRaw = inputsRaw[1].Split(',');

            List<Tuple<long, long>> availableBusIds = new List<Tuple<long, long>>();
            for (long ii = 0; ii < busesRaw.Length; ii++)
            {
                if (busesRaw[ii] != "x")
                {
                    availableBusIds.Add(new Tuple<long, long>(long.Parse(busesRaw[ii]), long.Parse(busesRaw[ii]) - ii));
                }
            }

            Boolean solved = false;
            long currentTime = -1;

            while (!solved)
            {
                currentTime++;
                solved = true;
                for (int ii = 0; ii < availableBusIds.Count(); ii++)
                {
                    if ((currentTime + availableBusIds[ii].Item2) % availableBusIds[ii].Item1 != 0)
                    {
                        solved = false;
                        break;
                    }
                }
            }

            return currentTime.ToString();
        }
    }
}
