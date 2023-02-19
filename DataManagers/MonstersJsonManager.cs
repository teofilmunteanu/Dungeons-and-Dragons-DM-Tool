using Deez_Notes_Dm.Json_DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Deez_Notes_Dm.DataManagers
{
    public static class MonstersJsonManager
    {
        private static string monsterSavesDirPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/DeezNotesDm/Monsters";
        private static string monsterSavesFilePath = monsterSavesDirPath + "/Monsters.json";

        public static List<MonsterDTO>? GetMonstersFromJson()
        {
            if (!Directory.Exists(monsterSavesDirPath))
            {
                Directory.CreateDirectory(monsterSavesDirPath);
            }


            List<MonsterDTO> Monsters = new List<MonsterDTO>();

            if (File.Exists(monsterSavesFilePath))
            {
                string json = File.ReadAllText(monsterSavesFilePath);

                Monsters = JsonConvert.DeserializeObject<List<MonsterDTO>>(json);
            }
            else
            {
                File.Create(monsterSavesFilePath);
            }

            return Monsters;
        }

        public static List<MonsterDTO>? GetMonstersFromJson(string name)
        {
            List<MonsterDTO> MonstersFromJson = GetMonstersFromJson();
            List<MonsterDTO> MonstersWithName = new List<MonsterDTO>();

            if (MonstersFromJson != null)
            {
                foreach (MonsterDTO monster in MonstersFromJson)
                {
                    if (monster.name.Contains(name))
                    {
                        MonstersWithName.Add(monster);
                    }
                }
            }

            return MonstersWithName;
        }

        public static MonsterDTO? GetSingleMonsterFromJson(string name)
        {
            List<MonsterDTO> MonstersFromJson = GetMonstersFromJson();

            if (MonstersFromJson != null)
            {
                return MonstersFromJson.Where(m => m.name == name).FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        public static void SaveMonsters(List<MonsterDTO> Monsters)
        {
            string newJson = JsonConvert.SerializeObject(Monsters);

            File.WriteAllText(monsterSavesFilePath, newJson);
        }
    }
}
