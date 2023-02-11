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

        public async Task<MonsterDTO> GetSingleMonsterDataAsync(string monsterName)
        {
            return await MonsterServices.GetSingleMonsterData(monsterName);
        }

        public async Task<List<Monster>> GetMonstersForCombatAsync(List<string> monstersNames)
        {
            int id = PlayerServices.GetPlayersData().Count;

            List<Monster> monsters = new List<Monster>();

            foreach (string monsterName in monstersNames)
            {
                MonsterDTO monsterDTO = await GetSingleMonsterDataAsync(monsterName);

                monsters.Add(MonsterServices.ToMonster(id, monsterDTO));

                id++;
            }

            return monsters;
        }
    }
}
