using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Solutions
{
    public class Day11 : IDay
    {
        // List of all "adjacent" positions
        readonly List<Tuple<int, int>> adjList = new List<Tuple<int, int>>()
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

        public string SolveP1()
        {
            string[] inputsRaw = AoCUtils.readInputFile(this.GetType().Name.Substring(3));

            // Convert to char matrix for ease of modification
            char[][] inputsProcess = new char[inputsRaw.Length][];
            for(int ii = 0; ii < inputsRaw.Length; ii++)
            {
                inputsProcess[ii] = inputsRaw[ii].ToCharArray();
            }
            int maxY = inputsRaw.Length;
            int maxX = inputsRaw[0].Length;

            // Initialize new state
            char[][] newState = new char[inputsProcess.Length][];
            for (int ii = 0; ii < inputsProcess.Length; ii++)
            {
                newState[ii] = (char[])inputsProcess[ii].Clone();
            }

            Boolean stablized = false;
            while (!stablized)
            {
                for (int yy = 0; yy < maxY; yy++)
                {
                    for (int xx = 0; xx < maxX; xx++)
                    {
                        // If floor, skip
                        if (inputsProcess[yy][xx] == '.')
                        {
                            continue;
                        }

                        // Iterate through list of available adjacents
                        // If out of bounds, floor, or empty seat, count as empty seat
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

                        // If current seat is empty and there are eight open seats, seat is occupied
                        // Else if seat is occupied and there are four or less open seats, now empty
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

                // Check to see if new state is same as previous state
                stablized = this.compareMatrix(newState, inputsProcess);

                // Clone and replace old state
                for (int ii = 0; ii < inputsProcess.Length; ii++)
                {
                    inputsProcess[ii] = (char[])newState[ii].Clone();
                }
            }

            return this.countSeats(inputsProcess, '#').ToString();
        }

        public string SolveP2()
        {
            string[] inputsRaw = AoCUtils.readInputFile(this.GetType().Name.Substring(3));

            // Convert to char matrix for ease of modification
            char[][] inputsProcess = new char[inputsRaw.Length][];
            for (int ii = 0; ii < inputsRaw.Length; ii++)
            {
                inputsProcess[ii] = inputsRaw[ii].ToCharArray();
            }
            int maxY = inputsRaw.Length;
            int maxX = inputsRaw[0].Length;

            // Initialize new state
            char[][] newState = new char[inputsProcess.Length][];
            for (int ii = 0; ii < inputsProcess.Length; ii++)
            {
                newState[ii] = (char[])inputsProcess[ii].Clone();
            }

            Boolean stablized = false;
            while (!stablized)
            {
                for (int yy = 0; yy < maxY; yy++)
                {
                    for (int xx = 0; xx < maxX; xx++)
                    {
                        // If floor, skip
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

                            // Iterate through list of available adjacents
                            // If out of bounds, floor, or empty seat, count as empty seat
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

                        // If current seat is empty and there are eight open seats, seat is occupied
                        // Else if seat is occupied and there are three or less open seats, now empty
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

                // Check to see if new state is same as previous state
                stablized = this.compareMatrix(newState, inputsProcess);

                // Clone and replace old state
                for (int ii = 0; ii < inputsProcess.Length; ii++)
                {
                    inputsProcess[ii] = (char[])newState[ii].Clone();
                }
            }

            return this.countSeats(inputsProcess, '#').ToString();
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

        private void printMatrix(char[][] input)
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
            Console.WriteLine(sb.ToString());
        }

        private Boolean compareMatrix(char[][] matA, char[][] matB)
        {
            Boolean isEqual = true;
            for (int ii = 0; ii < matA.Length; ii++)
            {
                for (int jj = 0; jj < matA[0].Length; jj++)
                {
                    if (matA[ii][jj] != matB[ii][jj])
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (!isEqual)
                {
                    break;
                }
            }
            return isEqual;
        }

        private int countSeats(char[][] matIn, char state)
        {
            int count = 0;
            for (int ii = 0; ii < matIn.Length; ii++)
            {
                for (int jj = 0; jj < matIn[0].Length; jj++)
                {
                    if (matIn[ii][jj] == state)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
