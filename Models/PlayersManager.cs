using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace Deez_Notes_Dm.Models
{
    public class PlayersManager
    {
        private readonly List<Player>? players;

        //TO SEPARATE SERIALIZATION(maybe separate objects): Manager + Services(for creations etc.)
        public PlayersManager()
        {
            string playerSavesPath = Directory.GetCurrentDirectory() + "/Resources/Players/Players.json";

            if (File.Exists(playerSavesPath))
            {
                string json = System.IO.File.ReadAllText(@"Resources/Players/Players.json");

                players = new List<Player>();
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
            try
            {
                players.Add(player);

                String newJson = JsonConvert.SerializeObject(players);

                System.IO.File.WriteAllText(@"Resources/Players/Players.json", newJson);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
