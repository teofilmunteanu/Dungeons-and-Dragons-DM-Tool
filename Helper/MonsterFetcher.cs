using Deez_Notes_Dm.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Deez_Notes_Dm.Helper
{
    public class MonsterFetcher
    {
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
            int maxHP = dynamicObject.hit_points;

            Monster monster = new Monster(name, maxHP);

            return monster;
        }
    }
}
