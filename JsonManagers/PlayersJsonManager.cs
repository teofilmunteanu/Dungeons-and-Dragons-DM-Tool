using Deez_Notes_Dm.Json_DTOs;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Deez_Notes_Dm.JsonManagers
{
    //to initialize in App.cs
    public class PlayersJsonManager
    {
        private PlayersJsonManager() { }
        private static PlayersJsonManager instance = null;
        public static PlayersJsonManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlayersJsonManager();
                }

                return instance;
            }
        }

        private string playerSavesPath = Directory.GetCurrentDirectory() + "/Resources/Players/Players.json";
        public List<PlayerDTO> Players { get; set; }

        //just initialization here - in constructor?
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
    }
}
