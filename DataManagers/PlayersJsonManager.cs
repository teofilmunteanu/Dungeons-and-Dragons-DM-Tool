using Deez_Notes_Dm.Json_DTOs;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Deez_Notes_Dm.DataManagers
{
    //ONLY operations on the json!!!
    public static class PlayersJsonManager
    {
        private static string playerSavesPath = Directory.GetCurrentDirectory() + "/Resources/Players/Players.json";

        //private PlayersJsonManager()
        //{

        //}

        //private static PlayersJsonManager? instance = null;
        //public static PlayersJsonManager Instance
        //{
        //    get
        //    {
        //        if (instance == null)
        //        {
        //            instance = new PlayersJsonManager();
        //        }

        //        return instance;
        //    }
        //}

        public static List<PlayerDTO> GetPlayersFromJson()
        {
            List<PlayerDTO> Players = new List<PlayerDTO>();

            if (File.Exists(playerSavesPath))
            {
                string json = File.ReadAllText(@"Resources/Players/Players.json");

                Players = JsonConvert.DeserializeObject<List<PlayerDTO>>(json);
            }
            else
            {
                File.Create(playerSavesPath);
            }

            return Players;
        }

        public static void SavePlayers(List<PlayerDTO> Players)
        {
            string newJson = JsonConvert.SerializeObject(Players);

            File.WriteAllText(@"Resources/Players/Players.json", newJson);
        }
    }
}
