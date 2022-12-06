namespace AdventOfCode2022
{
    internal class Day1 : IAOCSolution
    {
        /// ASSUMING VALID INPUTS
        public void PrintResult(string filePath)
        {
            int currentCalorieCount = 0;
            List<int> calorieList = new List<int>();

            foreach (string line in System.IO.File.ReadLines(filePath))
            {
                if (line.Length == 0)
                {
                    calorieList.Add(currentCalorieCount);
                    currentCalorieCount = 0;
                }
                else
                {
                    currentCalorieCount += int.Parse(line);
                }
            }

            calorieList.Sort();
            calorieList.Reverse();

            Console.WriteLine("Day1 - 1st Solution: Highest calorie elf = " + calorieList[0]);
            Console.WriteLine("Day1 - 2nd Solution: Top 3 calorie elf totals summed = " + (calorieList[0] + calorieList[1] + calorieList[2]));
        }
    }
}
