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
        //for calculating id and for (TO DO) properties, so the search by name is only executed here
        private List<Monster> MonstersInCombat { get; set; }
        private readonly PlayersManager _playersManager;

        public MonstersManager(PlayersManager playersManager)
        {
            SavedMonsters = new List<Monster>();
            MonstersInCombat = new List<Monster>();

            _playersManager = playersManager;
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

        public async Task<Monster> GetMonsterForCombatAsync(string monsterName)
        {
            //ensures monster ids are higher than player ids, in case a player joins the combat later
            int id = _playersManager.GetPlayers().Count + MonstersInCombat.Count;

            MonsterDTO monsterDTO = await GetSingleMonsterDataAsync(monsterName);

            Monster monster = MonsterServices.ToMonster(id, monsterDTO);

            return monster;
        }

        public void AddMonsterToCombat(Monster monster)
        {
            MonstersInCombat.Add(monster);
        }
    }
}
