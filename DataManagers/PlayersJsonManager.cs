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
        private static string playerSavesDirPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/DeezNotesDm/Players";
        private static string playerSavesFilePath = playerSavesDirPath + "/Players.json";

        public static List<PlayerDTO>? GetPlayersFromJson()
        {
            if (!Directory.Exists(playerSavesDirPath))
            {
                Directory.CreateDirectory(playerSavesDirPath);
            }

            List<PlayerDTO> Players = new List<PlayerDTO>();

            if (File.Exists(playerSavesFilePath))
            {
                string json = File.ReadAllText(playerSavesFilePath);

                Players = JsonConvert.DeserializeObject<List<PlayerDTO>>(json);
            }
            else
            {
                File.Create(playerSavesFilePath);
            }

            return Players;
        }

        public static void SavePlayers(List<PlayerDTO> Players)
        {
            string newJson = JsonConvert.SerializeObject(Players);

            File.WriteAllText(playerSavesFilePath, newJson);
        }
    }
}
