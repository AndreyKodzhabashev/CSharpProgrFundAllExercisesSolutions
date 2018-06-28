using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamPrepIV_Pr03_Football_Standings
{
    class ExamPrepIV_Pr03_Football_Standings
    {
        // 100/100
        static void Main()
        {
            Dictionary<string, long> dictScoreBoard = new Dictionary<string, long>();

            Dictionary<string, long> dictGoolsPerTeam = new Dictionary<string, long>();

            string key = Console.ReadLine().ToUpper();


            while (true)
            {
                string inputLine = Console.ReadLine().ToUpper();
                if (inputLine.Equals("FINAL"))
                {
                    break;
                }
                //take the result
                string[] toTakescore = inputLine.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                string score = toTakescore[toTakescore.Length - 1];

                //take first Team name

                int indexOfTeam = inputLine.IndexOf(key);
                inputLine = string.Join("", inputLine.Skip(indexOfTeam + key.Length));

                int indexOfTeam1 = inputLine.IndexOf(key);

                string firstTeam = string.Join("", inputLine.Take(indexOfTeam1).Reverse()).Trim();

                inputLine = string.Join("", inputLine.Skip(firstTeam.Length + key.Length));

                // take second team
                int indexOfTeam2 = inputLine.IndexOf(key);
                inputLine = string.Join("", inputLine.Skip(indexOfTeam2 + key.Length));

                int indexOfTeam3 = inputLine.IndexOf(key);

                string secondTeam = string.Join("", inputLine.Take(indexOfTeam3).Reverse());

                //lets deal with the score
                long[] teamScore = score.
                    Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();

                long firstTeamScore = teamScore[0];
                long secondTeamScore = teamScore[1];

                long pointsToAddFirstTeam = 0;
                long pointsToAddSecondTeam = 0;
                //lets define who takes how many points
                if (firstTeamScore > secondTeamScore)
                {
                    pointsToAddFirstTeam = 3;
                }
                else if (secondTeamScore > firstTeamScore)
                {
                    pointsToAddSecondTeam = 3;
                }
                else
                {
                    pointsToAddFirstTeam = 1;
                    pointsToAddSecondTeam = 1;
                }

                //add points of firstTeam
                if (dictScoreBoard.ContainsKey(firstTeam) == false)
                {
                    dictScoreBoard[firstTeam] = 0;
                }
                dictScoreBoard[firstTeam] += pointsToAddFirstTeam;
                //add gools of firstTeam
                if (dictGoolsPerTeam.ContainsKey(firstTeam) == false)
                {
                    dictGoolsPerTeam[firstTeam] = 0;
                }
                dictGoolsPerTeam[firstTeam] += firstTeamScore;

                //add gools of secondTeam
                if (dictGoolsPerTeam.ContainsKey(secondTeam) == false)
                {
                    dictGoolsPerTeam[secondTeam] = 0;
                }
                dictGoolsPerTeam[secondTeam] += secondTeamScore;
                //add points of secondTeam
                if (dictScoreBoard.ContainsKey(secondTeam) == false)
                {
                    dictScoreBoard[secondTeam] = 0;
                }
                dictScoreBoard[secondTeam] += pointsToAddSecondTeam;
            }

            Console.WriteLine("League standings:");
            int place = 1;
            foreach (var team in dictScoreBoard.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
            {
                Console.WriteLine($"{place++}. {team.Key.ToUpper()} {team.Value}");
            }

            Console.WriteLine("Top 3 scored goals:");
            int counter = 0;
            foreach (var team in dictGoolsPerTeam.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
            {
                Console.WriteLine($"- {team.Key.ToUpper()} -> {team.Value}");
                counter++;
                if (counter == 3)
                {
                    break;
                }
            }
        }
    }
}