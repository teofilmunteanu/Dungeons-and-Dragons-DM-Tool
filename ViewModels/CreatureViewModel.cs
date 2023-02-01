using System.Collections.Generic;
using static Deez_Notes_Dm.Models.Creature;

namespace Deez_Notes_Dm.ViewModels
{
    public class CreatureViewModel : ViewModelBase
    {
        public int ID { get; }

        public string Name { get; set; }
        public string Race { get; set; }

        public int MaxHP { get; set; }
        public int HP { get; set; }
        public int AC { get; set; }

        public List<string> SpeedsList { get; set; }

        public Stats BaseStats { get; set; }

        public Stats StatsMod { get; set; }

        public double Initiative { get; set; }

        public CreatureViewModel(int id, string name, string race, int hp, int maxHP, int ac,
            List<string> speedsList, Stats baseStats, Stats statsMod)
        {
            ID = id;
            Name = name;
            Race = race;
            HP = hp;
            MaxHP = maxHP;
            AC = ac;
            SpeedsList = speedsList;
            BaseStats = baseStats;
            StatsMod = statsMod;
        }
    }
}
