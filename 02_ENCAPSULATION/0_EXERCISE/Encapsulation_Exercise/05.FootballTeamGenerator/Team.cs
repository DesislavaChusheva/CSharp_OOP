using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }
        public void RemovePlayer(string playerName)
        {
            Player player = players.Where(p => p.Name == playerName).FirstOrDefault();

            if (player == null)
            {
                Console.WriteLine($"Player {playerName} is not in {Name} team.");
                return;
            }
            players.Remove(player);
        }
        public double GetRating()
        {
            double rating = 0;
            if (players.Count > 0)
            {
                foreach (Player player in players)
                {
                    rating += player.SkillLevel();
                }
                rating = rating / players.Count;
            }
            return Math.Round(rating);
        }
    }
}
