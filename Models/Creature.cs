using Deez_Notes_Dm.Services;
using System;

namespace Deez_Notes_Dm.Models
{
    public class Creature
    {
        public int ID { get; }

        public string Name { get; set; }
        public string Race { get; set; }

        public int MaxHP { get; set; }
        public int HP { get; set; }
        public int AC { get; set; }

        public Speed Speeds { get; set; }

        public Stats BaseStats { get; set; }
        public Stats StatsMod { get; set; }

        //TO USE FOR SORTING COMBATANTS
        public double Initiative { get; set; }


        public Creature()
        {

        }
        public Creature(int id, string name, string race, int hp, int maxHP, int ac, Speed speeds, Stats baseStats)
        {
            ID = id;
            Name = name;
            Race = race;
            HP = hp;
            MaxHP = maxHP;
            AC = ac;
            Speeds = speeds;

            BaseStats = baseStats;
            StatsMod = new Stats
            {
                STR = getModifier(baseStats.STR),
                DEX = getModifier(baseStats.DEX),
                CON = getModifier(baseStats.CON),
                INT = getModifier(baseStats.INT),
                WIS = getModifier(baseStats.WIS),
                CHA = getModifier(baseStats.CHA)
            };
        }

        protected static int getModifier(int statusValue)
        {
            return (int)Math.Floor(((statusValue - 10)) / 2.0);
        }

        public bool isMonster()
        {
            return ID >= PlayerServices.GetPlayersData().Count;
        }

        public class Stats
        {
            public int STR { get; set; }
            public int DEX { get; set; }
            public int CON { get; set; }
            public int INT { get; set; }
            public int WIS { get; set; }
            public int CHA { get; set; }
        }

        public class Speed
        {
            public int? walk { get; set; }
            public int? climb { get; set; }
            public int? swim { get; set; }
            public int? burrow { get; set; }
            public int? fly { get; set; }
            public bool? hover { get; set; }
        }
    }
}
