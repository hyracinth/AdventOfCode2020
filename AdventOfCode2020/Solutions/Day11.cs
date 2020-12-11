using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2020.Solutions
{
    public class Day11 : IDay
    {
        public string SolveP1()
        {
            string[] inputsRaw = AoCUtils.readInputFile(this.GetType().Name.Substring(3));

            char[][] inputsProcess = new char[inputsRaw.Length][];
            for(int ii = 0; ii < inputsRaw.Length; ii++)
            {
                inputsProcess[ii] = inputsRaw[ii].ToCharArray();
            }

            int maxY = inputsRaw.Length;
            int maxX = inputsRaw[0].Length;

            List<Tuple<int, int>> adjList = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(-1, -1),
                new Tuple<int, int>(0, -1),
                new Tuple<int, int>(1, -1),
                new Tuple<int, int>(-1, 0),
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(-1, 1),
                new Tuple<int, int>(0, 1),
                new Tuple<int, int>(1, 1),
            };

            Boolean stablized = false;

            // Initialize new state
            char[][] newState = new char[inputsProcess.Length][];
            for (int ii = 0; ii < inputsProcess.Length; ii++)
            {
                newState[ii] = (char[])inputsProcess[ii].Clone();
            }

            while (!stablized)
            {
                for (int yy = 0; yy < maxY; yy++)
                {
                    for (int xx = 0; xx < maxX; xx++)
                    {
                        if (inputsProcess[yy][xx] == '.')
                        {
                            continue;
                        }

                        int openSeatCount = 0;
                        foreach (Tuple<int, int> currAdj in adjList)
                        {
                            int newX = xx + currAdj.Item1;
                            int newY = yy + currAdj.Item2;

                            if (newX < 0 || newY < 0 || newX > maxX - 1 || newY > maxY - 1 ||
                                inputsProcess[newY][newX] == '.' || inputsProcess[newY][newX] == 'L')
                            {
                                openSeatCount++;
                            }
                        }
                        if (inputsProcess[yy][xx] == 'L' && openSeatCount == 8)
                        {
                            newState[yy][xx] = '#';
                        }
                        else if (inputsProcess[yy][xx] == '#' && openSeatCount <= 4)
                        {
                            newState[yy][xx] = 'L';
                        }

                    }
                }

                stablized = true;
                for (int ii = 0; ii < inputsProcess.Length; ii++)
                {
                    for (int jj = 0; jj < inputsProcess[0].Length; jj++)
                    {
                        if (inputsProcess[ii][jj] != newState[ii][jj])
                        {
                            stablized = false;
                            break;
                        }
                    }
                    if (!stablized)
                    {
                        break;
                    }
                }

                for (int ii = 0; ii < inputsProcess.Length; ii++)
                {
                    inputsProcess[ii] = (char[])newState[ii].Clone();
                }
            }

            int occupiedSeats = 0;
            for (int ii = 0; ii < inputsProcess.Length; ii++)
            {
                for (int jj = 0; jj < inputsProcess[0].Length; jj++)
                {
                    if (inputsProcess[ii][jj] == '#')
                    {
                        occupiedSeats++;
                    }
                }
            }

            return occupiedSeats.ToString();
        }

        public string SolveP2()
        {
            string[] inputsRaw = AoCUtils.readInputFile(this.GetType().Name.Substring(3));

            char[][] inputsProcess = new char[inputsRaw.Length][];
            for (int ii = 0; ii < inputsRaw.Length; ii++)
            {
                inputsProcess[ii] = inputsRaw[ii].ToCharArray();
            }

            int maxY = inputsRaw.Length;
            int maxX = inputsRaw[0].Length;

            List<Tuple<int, int>> adjList = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(-1, -1),
                new Tuple<int, int>(0, -1),
                new Tuple<int, int>(1, -1),
                new Tuple<int, int>(-1, 0),
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(-1, 1),
                new Tuple<int, int>(0, 1),
                new Tuple<int, int>(1, 1),
            };

            Boolean stablized = false;

            // Initialize new state
            char[][] newState = new char[inputsProcess.Length][];
            for (int ii = 0; ii < inputsProcess.Length; ii++)
            {
                newState[ii] = (char[])inputsProcess[ii].Clone();
            }

            while (!stablized)
            {
                for (int yy = 0; yy < maxY; yy++)
                {
                    for (int xx = 0; xx < maxX; xx++)
                    {
                        if (inputsProcess[yy][xx] == '.')
                        {
                            continue;
                        }

                        int openSeatCount = 0;
                        foreach (Tuple<int, int> currAdj in adjList)
                        {
                            int newX = xx;
                            int newY = yy;
                            int currCount = 1;

                            Boolean openSeat = true;
                            while (newX >= 0 && newY >= 0 && newX < maxX && newY < maxY)
                            {
                                newX = xx + currCount * currAdj.Item1;
                                newY = yy + currCount * currAdj.Item2;
                                currCount++;

                                if (newX < 0 || newY < 0 || newX > maxX - 1 || newY > maxY - 1 ||
                                    inputsProcess[newY][newX] == '.')
                                {
                                    continue;
                                }
                                else if (inputsProcess[newY][newX] == 'L')
                                {
                                    break;
                                }
                                else if (inputsProcess[newY][newX] == '#')
                                {
                                    openSeat = false;
                                    break;
                                }
                            }

                            if (openSeat)
                            {
                                openSeatCount++;
                            }
                        }
                        if (inputsProcess[yy][xx] == 'L' && openSeatCount == 8)
                        {
                            newState[yy][xx] = '#';
                        }
                        else if (inputsProcess[yy][xx] == '#' && openSeatCount <= 3)
                        {
                            newState[yy][xx] = 'L';
                        }
                    }
                }

                stablized = true;
                for (int ii = 0; ii < inputsProcess.Length; ii++)
                {
                    for (int jj = 0; jj < inputsProcess[0].Length; jj++)
                    {
                        if (inputsProcess[ii][jj] != newState[ii][jj])
                        {
                            stablized = false;
                            break;
                        }
                    }
                    if (!stablized)
                    {
                        break;
                    }
                }

                for (int ii = 0; ii < inputsProcess.Length; ii++)
                {
                    inputsProcess[ii] = (char[])newState[ii].Clone();
                }
            }

            int occupiedSeats = 0;
            for (int ii = 0; ii < inputsProcess.Length; ii++)
            {
                for (int jj = 0; jj < inputsProcess[0].Length; jj++)
                {
                    if (inputsProcess[ii][jj] == '#')
                    {
                        occupiedSeats++;
                    }
                }
            }

            return occupiedSeats.ToString();

            return null;
        }

        public string SolveP3()
        {
            return "Not yet available";
        }

        private string[] testInput1()
        {
            return new string[]
            {
                "L.LL.LL.LL",
                "LLLLLLL.LL",
                "L.L.L..L..",
                "LLLL.LL.LL",
                "L.LL.LL.LL",
                "L.LLLLL.LL",
                "..L.L.....",
                "LLLLLLLLLL",
                "L.LLLLLL.L",
                "L.LLLLL.LL"
            };
        }

        private string printMatrix(char[][] input)
        {
            StringBuilder sb = new StringBuilder();
            for(int yy = 0; yy < input.Length; yy++)
            {
                for(int xx = 0; xx < input[0].Length; xx++)
                {
                    sb.Append(input[yy][xx]);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
