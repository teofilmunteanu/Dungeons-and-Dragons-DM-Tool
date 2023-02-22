using Deez_Notes_Dm.Json_DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Deez_Notes_Dm.API_Managers
{
    public static class MonsterAPI
    {
        private readonly static string Open5eAPI_MonsterSearchPath = "https://api.open5e.com/monsters/?format=json&search=";
        private readonly static string Open5eAPI_MonsterByNamePath = "https://api.open5e.com/monsters/?name=";
        private readonly static string Open5eAPI_SpellBySlugPath = "https://api.open5e.com/spells/";

        public static async Task<string> searchMonsterAsync(string monsterName)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(Open5eAPI_MonsterSearchPath + monsterName);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;
        }

        public static async Task<string> fetchMonsterAsync(string monsterName)
        {
            if (monsterName == null)
            {
                monsterName = string.Empty;
            }

            if (monsterName.Contains(" "))
            {
                monsterName = Regex.Replace(monsterName, " ", "+");
            }

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(Open5eAPI_MonsterByNamePath + monsterName);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;
        }

        public static async Task<List<MonsterDTO>> GetMonstersAsync(string monsterName)
        {
            string json = await searchMonsterAsync(monsterName);

            var dynamicObject = JsonConvert.DeserializeObject<dynamic>(json)!;

            //API only has 50 per page!!!
            List<MonsterDTO> Monsters = dynamicObject.results.ToObject<List<MonsterDTO>>();

            return Monsters;
        }

        public static async Task<MonsterDTO> GetSingleMonsterAsync(string monsterName)
        {
            string json = await fetchMonsterAsync(monsterName);

            var dynamicObject = JsonConvert.DeserializeObject<dynamic>(json)!;

            MonsterDTO Monster = dynamicObject.results[0].ToObject<MonsterDTO>();

            return Monster;
        }


        public static async Task<string> fetchSpellAsync(string spellAPI_Path)
        {
            HttpClient client = new HttpClient();
            string spellPath = spellAPI_Path + "?format=json";
            HttpResponseMessage response = await client.GetAsync(spellPath);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;
        }

        public static async Task<MonsterDTO.SpellDTO> GetSpellAsync(string spellAPI_Path)
        {
            try
            {
                string json = await fetchSpellAsync(spellAPI_Path);

                var dynamicObject = JsonConvert.DeserializeObject<dynamic>(json)!;

                MonsterDTO.SpellDTO Spell = dynamicObject.ToObject<MonsterDTO.SpellDTO>();

                return Spell;
            }
            catch
            {
                throw new Exception("Spell at path " + spellAPI_Path + " not found!");
            }
        }
    }
}
