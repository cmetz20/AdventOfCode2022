using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day5 : IAOCSolution
    {
        /// ASSUMING VALID INPUTS

        void processContainerInputs(List<Stack<char>> containerStacks, List<string> containersInput)
        {
            // Read last line to get # of stacks
            string[] stackNumbers = containersInput[containersInput.Count - 1].Split("   ");
            int numStacks = Int32.Parse(stackNumbers[stackNumbers.Length - 1]);
            for (int i = 0; i < numStacks; i++)
            {
                containerStacks.Add(new Stack<char>());
            }

            int inputIndex;
            int stackIndex;
            int containerCounter;
            // Read in what containers are on each stack from bottom up
            for (int i = containersInput.Count - 2; i >= 0; i--)
            {
                containerCounter = 0;
                stackIndex = 0;
                inputIndex = 1;
                while (containerCounter < numStacks)
                {
                    if (containersInput[i][inputIndex] != ' ')
                    {
                        containerStacks[stackIndex].Push(containersInput[i][inputIndex]);
                    }
                    stackIndex++;
                    inputIndex += 4;
                    containerCounter++;
                }
            }
        }

        private void processInstruction(List<Stack<char>> containerStacks, int numToMove, int from, int to)
        {
            char val;
            for (int i = 0; i < numToMove; i++)
            {
                val = containerStacks[from - 1].Pop();
                containerStacks[to - 1].Push(val);
            }
        }

        private void processInstructionMultiGrab(List<Stack<char>> containerStacks, int numToMove, int from, int to)
        {
            char val;
            Stack<char> tempStack = new Stack<char> ();
            for (int i = 0; i < numToMove; i++)
            {
                val = containerStacks[from - 1].Pop();
                tempStack.Push(val);
            }
            while(tempStack.Count > 0)
            {
                containerStacks[to - 1].Push(tempStack.Pop());
            }
        }

        public void PrintResult(string filePath)
        {
            bool isReadingInstructions1 = false;
            bool isReadingInstructions2 = false;

            List<string> containersInput1 = new List<string>();
            List<Stack<char>> containerStacks1 = new List<Stack<char>>();
            List<string> containersInput2 = new List<string>();
            List<Stack<char>> containerStacks2 = new List<Stack<char>>();

            foreach (string line in System.IO.File.ReadLines(filePath))
            {
                if (line.Length == 0)
                {
                    // Original setup read in, now read in instructions
                    isReadingInstructions1 = true;
                    processContainerInputs(containerStacks1, containersInput1);
                    continue;
                }

                if (!isReadingInstructions1)
                {
                    // Reading in initial structure & setup
                    // Store the lines until we know how many rows we have
                    containersInput1.Add(line);
                }
                else
                {
                    // container stacks are set up. Now reading in instructions
                    var matches = Regex.Matches(line, @"\d+");
                    if (matches.Count == 3)
                    {
                        int numToMove = Int32.Parse(matches[0].Value);
                        int from = Int32.Parse(matches[1].Value);
                        int to = Int32.Parse(matches[2].Value);
                        processInstruction(containerStacks1, numToMove, from, to);
                    }
                }
            }

            foreach (string line in System.IO.File.ReadLines(filePath))
            {
                if (line.Length == 0)
                {
                    // Original setup read in, now read in instructions
                    isReadingInstructions2 = true;
                    processContainerInputs(containerStacks2, containersInput2);
                    continue;
                }

                if (!isReadingInstructions2)
                {
                    // Reading in initial structure & setup
                    // Store the lines until we know how many rows we have
                    containersInput2.Add(line);
                }
                else
                {
                    // container stacks are set up. Now reading in instructions
                    var matches = Regex.Matches(line, @"\d+");
                    if (matches.Count == 3)
                    {
                        int numToMove = Int32.Parse(matches[0].Value);
                        int from = Int32.Parse(matches[1].Value);
                        int to = Int32.Parse(matches[2].Value);
                        processInstructionMultiGrab(containerStacks2, numToMove, from, to);
                    }
                }
            }

            // Now create the string that shows the top of each container stack
            string result1 = "";
            foreach (Stack<char> stack in containerStacks1)
            {
                result1 += stack.Peek().ToString();
            }

            string result2 = "";
            foreach (Stack<char> stack in containerStacks2)
            {
                result2 += stack.Peek().ToString();
            }


            Console.WriteLine("Day5 - 1st Solution: Top containers = " + result1);
            Console.WriteLine("Day5 - 2nd Solution: Top containers = " + result2);

        }
    }
}
