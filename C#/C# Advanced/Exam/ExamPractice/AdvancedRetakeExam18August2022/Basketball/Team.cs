using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Basketball
{
    public class Team
    {
        private List<Player> _players;

        public Team(string name, int openPositions, char group)
        {
            _players = new List<Player>();
            Name = name;
            OpenPositions = openPositions;
            Group = group;
        }

        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }
        public int Count => _players.Count;

        public string AddPlayer(Player player)
        {
            if (OpenPositions - 1 < 0)
            {
                return "There are no more open positions.";
            }

            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
            {
                return "Invalid player's information.";
            }

            if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }

            OpenPositions--;
            _players.Add(player);
            return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";
        }

        public bool RemovePlayer(string name)
        {
            var player = _players.FirstOrDefault(p => p.Name == name);
            if (player == null)
            {
                return false;
            }

            OpenPositions++;
            return _players.Remove(player);
        }

        public int RemovePlayerByPosition(string position)
        {
            int result = _players.RemoveAll(p => p.Position == position);
            OpenPositions += result;

            return result;
        }

        public Player RetirePlayer(string name)
        {
            var player = _players.FirstOrDefault(p => p.Name == name);

            if (player == null)
            {
                return null;
            }

            player.Retired = true;
            return player;
        }

        public List<Player> AwardPlayers(int games) => _players.Where(p => p.Games >= games).ToList();

        public string Report()
        {
            var filteredTeam = _players.Where(p => p.Retired == false);
            var sb = new StringBuilder();
            sb.AppendLine($"Active players competing for Team {Name} from Group {Group}:");
            sb.AppendLine(string.Join(Environment.NewLine, filteredTeam));

            return sb.ToString().TrimEnd();
        }
    }
}
