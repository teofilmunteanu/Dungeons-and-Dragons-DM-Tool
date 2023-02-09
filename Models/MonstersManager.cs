using System.Collections.Generic;
using System.Linq;

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
    }
}
