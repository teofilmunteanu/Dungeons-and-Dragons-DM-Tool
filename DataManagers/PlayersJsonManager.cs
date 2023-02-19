using Deez_Notes_Dm.Json_DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Deez_Notes_Dm.DataManagers
{
    //ONLY operations on the json!!!
    public static class PlayersJsonManager
    {
        //Directory.GetCurrentDirectory() + "/Resources/Players/Players.json";
        private static string appDirPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/DeezNotesDm";
        private static string playerSavesPath = appDirPath + "/Players/Players.json";

        public static List<PlayerDTO>? GetPlayersFromJson()
        {
            if (!Directory.Exists(appDirPath))
            {
                Directory.CreateDirectory(appDirPath + "/Players");
            }

            List<PlayerDTO> Players = new List<PlayerDTO>();

            if (File.Exists(playerSavesPath))
            {
                string json = File.ReadAllText(playerSavesPath);

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

            File.WriteAllText(playerSavesPath, newJson);
        }
    }
}
