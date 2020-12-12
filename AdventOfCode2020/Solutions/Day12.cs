using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Solutions
{
    public class Day12 : IDay
    {
        // Directions in clockwise order and another in counterclockwise
        List<char> directions = new List<char>() { 'N', 'E', 'S', 'W' };
        List<char> revDirections = new List<char>() { 'W', 'S', 'E', 'N' };

        // Dictionary with directions and corresponding vectors
        Dictionary<char, Tuple<int, int>> dirVectors = new Dictionary<char, Tuple<int, int>>()
            {
                {'N', new Tuple<int, int>(0, -1) },
                {'E', new Tuple<int, int>(1, 0) },
                {'S', new Tuple<int, int>(0, 1) },
                {'W', new Tuple<int, int>(-1, 0) }
            };

        public string SolveP1()
        {
            string[] inputsRaw = AoCUtils.readInputFile(this.GetType().Name.Substring(3));

            char shipDir = 'E';
            int[] currCoords = new int[2] { 0, 0 };

            foreach(string currInstr in inputsRaw)
            {
                char instr = currInstr[0];
                int value = Int32.Parse(currInstr.Substring(1));

                int turns, ind;
                switch (instr)
                {
                    case 'N':
                    case 'E':
                    case 'S':
                    case 'W':
                        currCoords[0] += value * dirVectors[instr].Item1;
                        currCoords[1] += value * dirVectors[instr].Item2;
                        break;
                    case 'F':
                        currCoords[0] += value * dirVectors[shipDir].Item1;
                        currCoords[1] += value * dirVectors[shipDir].Item2;
                        break;
                    case 'R':
                        turns = value / 90;
                        ind = directions.IndexOf(shipDir);
                        ind += turns;
                        ind %= 4;
                        shipDir = directions[ind];
                        break;
                    case 'L':
                        turns = value / 90;
                        ind = revDirections.IndexOf(shipDir);
                        ind += turns;
                        ind %= 4;
                        shipDir = revDirections[ind];
                        break;
                }
            }

            int result = Math.Abs(currCoords[0]) + Math.Abs(currCoords[1]);
            return result.ToString();
        }

        // NOT WORKING AT THE MOMENT
        public string SolveP2()
        {
            string[] inputsRaw = AoCUtils.readInputFile(this.GetType().Name.Substring(3));
            //inputsRaw = new string[]
            //{
            //    "F10",
            //    "N3",
            //    "F7",
            //    "R450",
            //    "L360",
            //    "F11"
            //};

            int turns;
            long[] shipCoords = new long[2] { 0, 0 };
            long[] wayptCoords = new long[2] { -10, -1 };

            foreach (string currInstr in inputsRaw)
            {
                char instr = currInstr[0];
                int value = Int32.Parse(currInstr.Substring(1));

                long tempCoord, currX, currY;
                switch (instr)
                {
                    case 'N':
                    case 'E':
                    case 'S':
                    case 'W':
                        wayptCoords[0] += value * dirVectors[instr].Item1;
                        wayptCoords[1] += value * dirVectors[instr].Item2;
                        break;
                    case 'F':
                        currX = wayptCoords[0] - shipCoords[0];
                        currY = wayptCoords[1] - shipCoords[1];
                        shipCoords[0] += value * currX;
                        shipCoords[1] += value * currY;
                        wayptCoords[0] = shipCoords[0] + currX;
                        wayptCoords[1] = shipCoords[1] + currY;

                        //currX = wayptCoords[0] - currCoords[0];
                        //currY = wayptCoords[1] - currCoords[1];
                        //for (int ii = 0; ii < value; ii++) 
                        //{
                        //    currCoords[0] += currX;
                        //    currCoords[1] += currY;
                        //    wayptCoords[0] += currX;
                        //    wayptCoords[1] += currY;
                        //}
                        break;
                    case 'R':
                        turns = (value / 90) % 4;
                        wayptCoords[0] -= shipCoords[0];
                        wayptCoords[1] -= shipCoords[1];
                        for(int ii = 0; ii < turns; ii++)
                        {
                            tempCoord = wayptCoords[0];
                            wayptCoords[0] = wayptCoords[1];
                            wayptCoords[1] = tempCoord * -1;
                        }
                        wayptCoords[0] += shipCoords[0];
                        wayptCoords[1] += shipCoords[1];
                        break;
                    case 'L':
                        turns = (value / 90) % 4;
                        wayptCoords[0] -= shipCoords[0];
                        wayptCoords[1] -= shipCoords[1];
                        for (int ii = 0; ii < turns; ii++)
                        {
                            tempCoord = wayptCoords[0];
                            wayptCoords[0] = wayptCoords[1] * -1;
                            wayptCoords[1] = tempCoord;
                        }
                        wayptCoords[0] += shipCoords[0];
                        wayptCoords[1] += shipCoords[1];
                        break;
                }
                Console.WriteLine(currInstr);
                Console.WriteLine("WYPT " + wayptCoords[0] + "\t" + wayptCoords[1]);
                Console.WriteLine("SHIP " + shipCoords[0] + "\t" + shipCoords[1]);
            }

            long result = Math.Abs(shipCoords[0]) + Math.Abs(shipCoords[1]);
            return result.ToString();
        }

        public string SolveP3()
        {
            return "Not yet available";
        }
    }
}
