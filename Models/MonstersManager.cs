using Deez_Notes_Dm.Json_DTOs;
using Deez_Notes_Dm.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deez_Notes_Dm.Models
{
    public class MonstersManager
    {
        public List<Monster> SavedMonsters { get; set; }

        public MonstersManager()
        {
            SavedMonsters = new List<Monster>();
        }

        public List<Monster> GetSavedMonsters()
        {
            return SavedMonsters;
        }

        public Monster GetSavedMonsterById(int id)
        {
            return SavedMonsters.Where(c => c.ID == id).First();
        }

        public void AddMonster(Monster monster)
        {
            SavedMonsters.Add(monster);
        }

        public async Task<List<MonsterDTO>> GetMonstersDataAsync(string monsterName)
        {
            return await MonsterServices.GetMonstersData(monsterName);
        }
    }
}
