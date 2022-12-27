using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Deez_Notes_Dm.Models
{
    public class PlayersManager
    {
        private readonly List<Player>? players;

        public PlayersManager()
        {
            string playerSavesPath = Directory.GetCurrentDirectory() + "/Resources/Players/Players.json";

            if (File.Exists(playerSavesPath))
            {
                string json = System.IO.File.ReadAllText(@"Resources/Players/Players.json");

                players = JsonConvert.DeserializeObject<List<Player>>(json);
            }
            else
            {
                players = new List<Player>();
                File.Create(playerSavesPath);
            }
        }
        public List<Player> GetPlayers()
        {
            return players;
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }
    }
}
