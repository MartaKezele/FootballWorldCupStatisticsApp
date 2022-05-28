using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataLayer.Enums.PlayerPosition;

namespace DataLayer.Models
{
    public class Player
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("captain")]
        public bool Captain { get; set; }

        [JsonProperty("shirt_number")]
        public long ShirtNumber { get; set; }

        [JsonProperty("position")]
        public Position Position { get; set; }

        public override string ToString()
            => $"{Name}{Constants.SettingsConstants.PLAYER_DETAILS_SEPARATOR}" +
               $"{(Captain ? "captain" : "not captain")}{Constants.SettingsConstants.PLAYER_DETAILS_SEPARATOR}" +
               $"{ShirtNumber}{Constants.SettingsConstants.PLAYER_DETAILS_SEPARATOR}" +
               $"{Position}";

        public override bool Equals(object obj)
            => obj is Player other &&
            other != null &&
            Name == other.Name &&
            Captain == other.Captain &&
            ShirtNumber == other.ShirtNumber &&
            Position == other.Position;

        public static bool operator ==(Player a, Player b) => a.Equals(b);

        public static bool operator !=(Player a, Player b) => !(a == b);

        public override int GetHashCode()
            => (Name, Captain, ShirtNumber, Position).GetHashCode();

        public static Player GetPlayerFromString(string player)
        {
            string[] details = player.Split(Constants.SettingsConstants.PLAYER_DETAILS_SEPARATOR);
            return new Player
            {
                Name = details[0],
                Captain = details[1].ToLower() == "captain",
                ShirtNumber = int.Parse(details[2]),
                Position = GetPositionFromString(details[3])
            };
        }
    }

}
