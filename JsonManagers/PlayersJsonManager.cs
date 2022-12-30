using Deez_Notes_Dm.Json_DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Deez_Notes_Dm.JsonManagers
{
    public class PlayersJsonManager
    {
        private string playerSavesPath = Directory.GetCurrentDirectory() + "/Resources/Players/Players.json";
        public List<PlayerDTO> Players { get; set; }

        private PlayersJsonManager() { }
        private static PlayersJsonManager instance = null;
        public static PlayersJsonManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlayersJsonManager();
                    instance.Players = new List<PlayerDTO>();
                }

                return instance;
            }
        }


        public List<PlayerDTO> GetPlayers()
        {
            Players = new List<PlayerDTO>();

            if (File.Exists(playerSavesPath))
            {
                string json = System.IO.File.ReadAllText(@"Resources/Players/Players.json");

                Players = JsonConvert.DeserializeObject<List<PlayerDTO>>(json);
            }
            else
            {
                File.Create(playerSavesPath);
            }

            return Players;
        }


        public void SavePlayers()
        {
            String newJson = JsonConvert.SerializeObject(Players);

            System.IO.File.WriteAllText(@"Resources/Players/Players.json", newJson);
        }
    }
}
