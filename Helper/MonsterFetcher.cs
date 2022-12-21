﻿using Deez_Notes_Dm.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Deez_Notes_Dm.Helper
{
    public class MonsterFetcher
    {
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!! TO FINISH !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        //public static string[] FindMonsterJson(string monsterName)
        //{
        //    string monsterDataDir = Directory.GetCurrentDirectory() + "/Resources/MonstersData/";
        //    DirectoryInfo targetDirectory = new DirectoryInfo(@monsterDataDir);

        //    monsterName = monsterName.ToLower().Replace(" ", "_");

        //    FileInfo[] files = targetDirectory.GetFiles("*" + monsterName + "*.json");

        //    string[] jsonMatches = new string[files.Length];
        //    //foreach (FileInfo foundFile in files)
        //    for (int i = 0; i < files.Length; i++)
        //    {
        //        jsonMatches[i] = files[i].FullName;
        //        //MessageBox.Show(fullName);
        //    }

        //    return jsonMatches;
        //}


        //Temporary
        public static async Task<string> fetchMonsterAsync(string monsterName)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://api.open5e.com/monsters/" + monsterName + "/?format=json");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;
        }


        public static async Task<Monster> GetMonsterAsync(string monsterName)
        {
            string json = await fetchMonsterAsync(monsterName);
            var dynamicObject = JsonConvert.DeserializeObject<dynamic>(json)!;

            string name = dynamicObject.name;
            string type = dynamicObject.type;
            type = char.ToUpper(type[0]) + type.Substring(1);
            int maxHP = dynamicObject.hit_points;
            int AC = dynamicObject.armor_class;

            Creature.Speed speed = new Creature.Speed();
            speed.walk = dynamicObject.speed.walk != null ? dynamicObject.speed.walk : 0;
            speed.climb = dynamicObject.speed.climb != null ? dynamicObject.speed.climb : 0;
            speed.swim = dynamicObject.speed.swim != null ? dynamicObject.speed.climb : 0;
            speed.burrow = dynamicObject.speed.burrow != null ? dynamicObject.speed.climb : 0;
            speed.fly = dynamicObject.speed.fly != null ? dynamicObject.speed.climb : 0;
            speed.hover = dynamicObject.speed.hover != null ? dynamicObject.speed.climb : 0;

            Creature.Status stats = new Creature.Status();

            stats.STR = (int)dynamicObject.strength;
            stats.DEX = (int)dynamicObject.dexterity;
            stats.CON = (int)dynamicObject.constitution;
            stats.INT = (int)dynamicObject.intelligence;
            stats.WIS = (int)dynamicObject.wisdom;
            stats.CHA = (int)dynamicObject.charisma;


            Monster monster = new Monster(name, type, maxHP, AC, stats, speed);

            return monster;
        }
    }
}
