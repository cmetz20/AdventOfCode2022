using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day3 : IAOCSolution
    {
        /// ASSUMING VALID INPUTS

        private char getSharedCharFromList(List<string> stringList)
        {
            foreach (char c in stringList[0])
            {
                bool contains = true;
                foreach (string s in stringList)
                {
                    if (!s.Contains(c))
                    {
                        contains = false;
                        break;
                    }
                }
                if (contains == true)
                {
                    return c;
                }
            }
            return '0';
        }

        private char getSharedChar(string first, string second)
        {
            foreach (char c in first)
            {
                if (second.Contains(c))
                {
                    return c;
                }
            }
            return '0';
        }

        private int getCharPriority(char a)
        {
            if (a >= 'a' && a <= 'z')
            {
                return a - 96;
            }
            if (a >= 'A' && a <= 'Z')
            {
                return a - 38;
            }
            return 0;
        }

        public void PrintResult(string filePath)
        {
            int totalPriority1 = 0;
            int totalPriority2 = 0;
            int lineCounter = 0;
            List<string> stringList = new List<string>();

            foreach (string line in System.IO.File.ReadLines(filePath))
            {
                string first = line.Substring(0, line.Length / 2);
                string second = line.Substring(line.Length / 2);
                totalPriority1 += getCharPriority(getSharedChar(first, second));

                lineCounter++;
                stringList.Add(line);
                if (lineCounter % 3 == 0)
                {
                    // Third line, check for group.
                    totalPriority2 += getCharPriority(getSharedCharFromList(stringList));
                    stringList.Clear();
                }
            }

            Console.WriteLine("Day3 - 1st Solution: Total score = " + totalPriority1);
            Console.WriteLine("Day3 - 2nd Solution: Total score = " + totalPriority2);
        }


    }
}
