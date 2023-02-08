using Deez_Notes_Dm.API_Managers;
using Deez_Notes_Dm.Json_DTOs;
using Deez_Notes_Dm.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deez_Notes_Dm.Services
{
    public class MonsterServices
    {
        public CreatureManager _creatureManager;

        public MonsterServices(CreatureManager creatureManager)
        {
            _creatureManager = creatureManager;
        }

        private static Monster ToMonster(MonsterDTO monsterDTO)
        {
            //int ID = _creatureManager.GetCreatures().Count();
            return new Monster();
        }

        public async static Task<List<Monster>> FindMonster(string name)
        {
            List<MonsterDTO> monsterDTOs = await MonsterAPI.GetMonsterAsync(name);

            return (List<Monster>)monsterDTOs.Select(m => ToMonster(m));
        }
    }
}
