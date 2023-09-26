using Hockey.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace HockeyData
{
    internal class HockeyTeam
    {
        
        /// <summary>
        /// Hockey team rules
        /// </summary>
        private const int MaxGoalies = 3;
        private const int MinGoalies = 2;
        private const int MaxPlayers = 23;
        private const int MinPlayers = 20;


        /// <summary>
        /// Name of City
        /// </summary>
        public string City { get; private set; }

        /// <summary>
        /// Name of Team
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Players list
        /// </summary>
        public List<HockeyPlayer> Players { get; private set; } = new List<HockeyPlayer>();

        /// <summary>
        /// Count of total players
        /// </summary>
        public int TotalPlayers 
        { 
            get 
            {
                return Players.Count;
            }
        }

        /// <summary>
        /// Valid Roster property - Validates if roster is valid
        /// </summary>
        public bool IsValidRoster 
        { 
            get
            {
                int goalieCount = 0;
                
                for (int i = 0; i < Players.Count; i++)
                {
                    if (Players[i].Position == Position.Goalie)
                    {
                        goalieCount++;
                    }

                }

                if (Players.Count < MinPlayers || Players.Count > MaxPlayers || goalieCount < MinGoalies || goalieCount > MaxGoalies) 
                {
                    throw new ArgumentException("Roster is not valid");                
                }

                return true;
            }
        
        }

        /// <summary>
        /// Greedy constructor
        /// </summary>
        public HockeyTeam(string city, string name)
        {
            if (Utilities.IsNullEmptyOrWhiteSpace(city)) 
            {
                throw new ArgumentException("City cannot be null, empty, or whitespace");
            }
            if (Utilities.IsNullEmptyOrWhiteSpace(name))
            {
                throw new ArgumentException("Team name cannot be null, empty, or whitespace");
            }

            City = city.Trim();
            Name = name.Trim();
        }

        
        /// <summary>
        /// Adds Hockey player to the hockeyteam (Players list)
        /// </summary>
        public void AddHockeyPlayer(HockeyPlayer player)
        {
            if (player == null) 
            { 
                throw new ArgumentException("Player cannot be null!");
            
            }

            Players.Add(player);
        }

        /// <summary>
        /// Removes a hockeyplayer from the hockeyteam (Players list)
        /// </summary>
        public void RemoveHockeyPlayer(HockeyPlayer player) 
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null!");

            }

            if (!Players.Contains(player))
            {
                throw new ArgumentException("Player is not on the team");

            }

            Players.Remove(player);
        }


    }
}
