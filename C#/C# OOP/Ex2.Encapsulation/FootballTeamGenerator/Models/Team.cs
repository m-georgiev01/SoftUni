using System.Xml.Linq;

namespace FootballTeamGenerator.Models
{
    public class Team
    {
        private string teamName;
        private readonly List<Player> players;

        public Team(string teamName)
        {
            TeamName = teamName;
            players = new();
        }

        public string TeamName
        {
            get => teamName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                teamName = value;
            }
        }

        public double Rating
        {
            get
            {
                if (players.Any())
                {
                    return players.Average(p => p.Stats);
                }

                return 0;
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player player = players.FirstOrDefault(p => p.Name == playerName);

            if (player == null)
            {
                throw new ArgumentException($"Player {playerName} is not in {TeamName} team.");
            }

            players.Remove(player);
        }
    }
}
