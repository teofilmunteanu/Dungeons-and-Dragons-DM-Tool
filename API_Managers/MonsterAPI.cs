using Deez_Notes_Dm.Json_DTOs;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Deez_Notes_Dm.API_Managers
{
    public class MonsterAPI
    {
        public static async Task<string> fetchMonsterAsync(string monsterName)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://api.open5e.com/monsters/?format=json&search=" + monsterName);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;
        }

        public static async Task<List<MonsterDTO>> GetMonsterAsync(string monsterName)
        {
            string json = await fetchMonsterAsync(monsterName);

            var dynamicObject = JsonConvert.DeserializeObject<dynamic>(json)!;

            List<MonsterDTO> Monsters = dynamicObject.results.ToObject<List<MonsterDTO>>();

            return Monsters;
        }
    }
}
