using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.TeamworkProjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfTeams = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();

            for (int i = 0; i < numOfTeams; i++)
            {
                string[] createTeam = Console.ReadLine().Split('-');
                string creator = createTeam[0];
                string teamName = createTeam[1];

                if (ValidateCreationOfTeam(teams, teamName, creator))
                {
                    var team = new Team(teamName, creator);
                    teams.Add(team);
                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "end of assignment")
            {
                string[] addMembers = command.Split("->");
                string user = addMembers[0];
                string teamName = addMembers[1];

                if (ValidateAddingMembersToTeam(teams, teamName, user))
                {
                    var team = teams.FirstOrDefault(x => x.Name == teamName);
                    team.members.Add(user);
                }
            }

            foreach (var t in teams.Where(x => x.members.Count > 0).OrderByDescending(s => s.members.Count).ThenBy(m => m.Name))
            {
                Console.WriteLine(t.Name);
                Console.WriteLine($"- {t.Creator}");
                foreach (var member in t.members.OrderBy(n => n))
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine("Teams to disband:");
            foreach (var t in teams.Where(x => x.members.Count == 0).OrderBy(x => x.Name))
            {
                Console.WriteLine(t.Name);
            }
        }

        private static bool ValidateAddingMembersToTeam(List<Team> teams, string teamName, string user)
        {
            bool isValid = true;

            var t = teams.FirstOrDefault(x => x.Name == teamName);
            if (t == null)
            {
                Console.WriteLine($"Team {teamName} does not exist!");
                isValid = false;
            }

            t = teams.FirstOrDefault(x => x.members.FirstOrDefault(m => m == user) == user);
            if (t != null)
            {
                Console.WriteLine($"Member {user} cannot join team {teamName}!");
                isValid = false;
            }

            t = teams.FirstOrDefault(x => x.Creator == user);
            if (t != null)
            {
                Console.WriteLine($"Member {user} cannot join team {teamName}!");
                isValid = false;
            }

            return isValid;
        }

        private static bool ValidateCreationOfTeam(List<Team> teams, string teamName, string creator)
        {
            bool isValid = true;

            var t = teams.FirstOrDefault(x => x.Name == teamName);
            if (t != null)
            {
                Console.WriteLine($"Team {teamName} was already created!");
                isValid = false;
            }

            t = teams.FirstOrDefault(x => x.Creator == creator);
            if (t != null)
            {
                Console.WriteLine($"{creator} cannot create another team!");
                isValid = false;
            }

            return isValid;
        }
    }

    class Team
    {
        public string Name { get; set; }
        public string Creator { get; set; }

        public List<string> members;

        public Team(string name, string creator)
        {
            Name = name;
            Creator = creator;
            members = new List<string>();
        }
    }
}