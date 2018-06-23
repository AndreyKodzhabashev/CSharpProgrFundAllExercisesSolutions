using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex08_Pr09_TeamwortProjects
{
    class Ex08_Pr09_TeamwortProjects
    {
        // 62/100
        static void Main()
        {
            int teamsCount = int.Parse(Console.ReadLine());

            List<Team> listTeams = new List<Team>();

            for (int i = 0; i < teamsCount; i++)
            {
                string[] input = Console.ReadLine()
                    .Split('-');

                string nameCreat = input[0].Trim();
                string nameTeam = input[1].Trim();

                int existensOfCreator = listTeams.FindIndex(x => x.Creator == nameCreat);
                if (existensOfCreator != -1)
                {
                    Console.WriteLine($"{nameCreat} cannot create another team!");
                    continue;
                }

                int existensOfTeam = listTeams.FindIndex(x => x.Name == nameTeam);
                if (existensOfTeam != -1)
                {
                    Console.WriteLine($"Team {nameTeam} was already created!");
                    continue;
                }

                listTeams.Add(new Team(nameTeam, nameCreat));
                Console.WriteLine($"Team {nameTeam} has been created by {nameCreat}!");

            }

            while (true)
            {
                string secondCommandLine = Console.ReadLine();
                if (secondCommandLine == "end of assignment")
                {
                    break;
                }

                string[] members = secondCommandLine
                    .Split("->", StringSplitOptions.RemoveEmptyEntries);

                string memberName = members[0].Trim();
                string teamToJoin = members[1].Trim();

                int teamExist = listTeams.FindIndex(x => x.Name == teamToJoin);

                if (teamExist == -1)
                {
                    Console.WriteLine($"Team {teamToJoin} does not exist!");
                    continue;
                }

                if (listTeams.Exists(x => x.Creator == memberName) || listTeams.Exists(x => x.Members.Contains(memberName)))
                {
                    Console.WriteLine($"Member {memberName} cannot join team {teamToJoin}!");
                    continue;
                }


                listTeams[teamExist].Members.Add(memberName);

            }

            var noMembers = listTeams.Where(x => x.Members.Count == 0).OrderBy(y => y.Name).ToList();

            var sorted = listTeams.Where(x => x.Members.Count > 0).OrderByDescending(y => y.Members.Count).ThenBy(z => z.Name).ToList();

            foreach (var team in sorted)
            {
                Console.WriteLine(team.Name);
                Console.WriteLine($"- {team.Creator}");

                foreach (var member in team.Members)
                {
                    Console.WriteLine($"-- {member}");
                }

            }
            Console.WriteLine("Teams to disband:");
            foreach (var team in noMembers.OrderBy(x =>x.Name))
            {
                Console.WriteLine(team.Name);
            }

        }
    }
    class Team
    {
        public Team(string name, string creator)
        {
            this.Name = name;
            this.Creator = creator;
            this.Members = new List<string>();
        }

        public string Name { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }
    }
}