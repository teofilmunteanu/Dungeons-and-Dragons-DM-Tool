using System.Collections.Generic;
using System.Linq;

namespace Deez_Notes_Dm.Models
{
    public class MonstersManager
    {
        //use for locally saved monsters
        public List<Monster> Monsters { get; set; }

        public MonstersManager()
        {
            Monsters = new List<Monster>();
        }

        public List<Monster> GetMonsters()
        {
            return Monsters;
        }

        public Monster GetMonsterById(int id)
        {
            return Monsters.Where(c => c.ID == id).First();
        }

        public void AddMonster(Monster monster)
        {
            Monsters.Add(monster);
        }
    }
}
