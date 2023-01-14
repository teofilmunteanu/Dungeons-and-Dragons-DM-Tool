using Deez_Notes_Dm.Json_DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Deez_Notes_Dm.JsonManagers
{
    //ONLY operations on the json!!!
    public class PlayersJsonManager
    {
        private string playerSavesPath = Directory.GetCurrentDirectory() + "/Resources/Players/Players.json";
        public List<PlayerDTO> Players { get; set; }

        private PlayersJsonManager()
        {

        }

        private static PlayersJsonManager? instance = null;
        public static PlayersJsonManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlayersJsonManager
                    {
                        Players = new List<PlayerDTO>()
                    };
                }

                return instance;
            }
        }


        public List<PlayerDTO> GetPlayers()
        {
            if (File.Exists(playerSavesPath))
            {
                string json = System.IO.File.ReadAllText(@"Resources/Players/Players.json");

                Players = JsonConvert.DeserializeObject<List<PlayerDTO>>(json);

                if (Players == null)
                {
                    Players = new List<PlayerDTO>();
                }
            }
            else
            {
                File.Create(playerSavesPath);
                Players = new List<PlayerDTO>();
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
