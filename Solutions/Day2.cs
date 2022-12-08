namespace AdventOfCode2022
{
    internal class Day2 : IAOCSolution
    {
        /// ASSUMING VALID INPUTS
        
        /// Value of single rock paper scissors game
        /// A == Opponent Rock, B == Opponent Paper, C == Opponent Scissors
        /// X == Self Rock, Y == Self Paper, Z == Self Scissors
        /// Rock == 1 bonus pt, Paper == 2 bonus pt, Scissors == 3 bonus pt
        public int GetGameResult(string gameString)
        {
            int myVal;
            int opponentVal;

            // Turn moves into bonus point vals
            if(gameString.Contains('A'))
            {
                opponentVal = 1; // Opponent Rock
            }
            else if(gameString.Contains('B'))
            {
                opponentVal = 2; // Opponent Paper
            }
            else
            {
                opponentVal = 3; // Opponent Scissors
            }

            // Turn moves into bonus point vals
            if (gameString.Contains('X'))
            {
                myVal = 1; // Self Rock
            }
            else if (gameString.Contains('Y'))
            {
                myVal = 2; // Self Paper
            }
            else
            {
                myVal = 3; // Self Scissors
            }

            // Determine outcome
            if(myVal == opponentVal)
            {
                return myVal + 3; // Tie
            }

            if(myVal - opponentVal == 1 || myVal - opponentVal == -2) // Paper vs Rock OR Scissors vs Paper OR Rock vs Scissors
            {
                return myVal + 6;
            }

            return myVal; // Must have lost
        }

        /// Value of single rock paper scissors game
        /// A == Opponent Rock, B == Opponent Paper, C == Opponent Scissors
        /// X == Must Lose, Y == Must Draw, Z == Must Win
        /// Rock == 1 bonus pt, Paper == 2 bonus pt, Scissors == 3 bonus pt
        public int GetGameResultCheating(string gameString)
        {
            int myVal = 0;
            int opponentVal = 0;

            // Turn moves into bonus point vals
            if (gameString.Contains('A'))
            {
                opponentVal = 1; // Opponent Rock
            }
            else if (gameString.Contains('B'))
            {
                opponentVal = 2; // Opponent Paper
            }
            else
            {
                opponentVal = 3; // Opponent Scissors
            }

            // Deciper what outcome we want and what move to play
            if (gameString.Contains('X'))
            {
                // Must lose
                myVal = (opponentVal > 1) ? (opponentVal - 1) : 3;
            }
            else if (gameString.Contains('Y'))
            {
                // Must tie
                myVal = opponentVal;
            }
            else
            {
                // Must win
                myVal = (opponentVal < 3) ? (opponentVal + 1) : 1;
            }

            // Determine outcome
            if (myVal == opponentVal)
            {
                return myVal + 3; // Tie
            }

            if (myVal - opponentVal == 1 || myVal - opponentVal == -2) // Paper vs Rock OR Scissors vs Paper OR Rock vs Scissors
            {
                return myVal + 6;
            }

            return myVal; // Must have lost
        }

        public void PrintResult(string filePath)
        {
            int totalScore1 = 0;
            int totalScore2 = 0;

            foreach (string line in System.IO.File.ReadLines(filePath))
            {
                totalScore1 += GetGameResult(line);
                totalScore2 += GetGameResultCheating(line);
            }

            Console.WriteLine("Day2 - 1st Solution: Total score = " + totalScore1);
            Console.WriteLine("Day2 - 2nd Solution: Total score = " + totalScore2);
        }
    }
}
