using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day4 : IAOCSolution
    {
        /// ASSUMING VALID INPUTS

        /// End vals are inclusive
        private bool AssignmentsContainCompleteOverlap(int elf1Start, int elf1End, int elf2Start, int elf2End)
        {
            if(elf1Start <= elf2Start && elf1End >= elf2End)
            {
                return true;
            }
            if(elf2Start <= elf1Start && elf2End >= elf1End)
            {
                return true;
            }

            return false;
        }

        private bool AssignmentsContainPartialOverlap(int elf1Start, int elf1End, int elf2Start, int elf2End)
        {
            if ((elf2Start >= elf1Start && elf2Start <= elf1End) ||
                (elf2End >= elf1Start && elf2End <= elf1End))
            {
                return true;
            }
            if ((elf1Start >= elf2Start && elf1Start <= elf2End) ||
                (elf1End >= elf2Start && elf1End <= elf2End))
            {
                return true;
            }

            return false;
        }

        public void PrintResult(string filePath)
        {
            int completeOverlaps = 0;
            int partialOverlaps = 0;

            char[] delimeters = { '-', ',' };
            foreach (string line in System.IO.File.ReadLines(filePath))
            {
                string[] tokens = line.Split(delimeters);
                if (AssignmentsContainCompleteOverlap(Int32.Parse(tokens[0]), Int32.Parse(tokens[1]), Int32.Parse(tokens[2]), Int32.Parse(tokens[3])))
                {
                    completeOverlaps++;
                }

                if (AssignmentsContainPartialOverlap(Int32.Parse(tokens[0]), Int32.Parse(tokens[1]), Int32.Parse(tokens[2]), Int32.Parse(tokens[3])))
                {
                    partialOverlaps++;
                }
            }

            Console.WriteLine("Day4 - 1st Solution: Total score = " + completeOverlaps);
            Console.WriteLine("Day4 - 2nd Solution: Total score = " + partialOverlaps);
        }

        
    }
}
