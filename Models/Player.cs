using System;
using System.Collections.Generic;

namespace Deez_Notes_Dm.Models
{
    public class Players
    {
        public List<Player> players { get; set; }
    }
    public class Player
    {
        static int playerCount;
        public int ID { get; set; }
        public String Name { get; set; }
        public String Race { get; set; }

        static int[] XPbyLevel { get; set; } = { -1, 0, 300, 900, 2700, 6500, 14000, 23000, 34000, 48000, 64000, 85000, 100000, 120000, 140000, 165000, 195000, 225000, 265000, 305000, 355000 };
        public int XP { get; set; }
        public int totalLevel { get; set; }
        public Dictionary<string, int> levelByClass { get; set; } = new Dictionary<string, int>();


        public int AC { get; set; }
        public int maxHP { get; set; }
        public int HP { get; set; }
        public int HitDice { get; set; }

        public int succededDeathSaves { get; set; }
        public int failedDeathSaves { get; set; }

        //private Dictionary<String, int> _Stats;

        //public Dictionary<String, int> Stats { get; set; }
        //{
        //    get { return _Stats; }
        //    set { _Stats = value; }
        //}
        //public Dictionary<String, int> StatsMod { get; set; }

        public class Status
        {
            public int STR { get; set; }
            public int DEX { get; set; }
            public int CON { get; set; }
            public int INT { get; set; }
            public int WIS { get; set; }
            public int CHA { get; set; }
        }
        public Status Stats { get; set; }

        public class StatsModifiers
        {
            public int STR { get; set; }
            public int DEX { get; set; }
            public int CON { get; set; }
            public int INT { get; set; }
            public int WIS { get; set; }
            public int CHA { get; set; }
        }
        public StatsModifiers StatsMod { get; set; }

        public int passiveInsight { get; set; }
        public int passiveInvestigation { get; set; }
        public int passivePerception { get; set; }

        static int[] proficiencyByLevel { get; set; } = { -1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6 };
        //public bool proficiencyInsight { get; set; }
        //public bool proficiencyInvestigation { get; set; }
        //public bool proficiencyPerception { get; set; }


        int getModifier(int statusValue)
        {
            //return (int)Math.Floor(((Stats[statBlock] - 10)) / 2.0);
            return (int)Math.Floor(((statusValue - 10)) / 2.0);
        }

        public Player()
        {
            playerCount++;
        }
        ~Player()
        {
            playerCount--;
        }

        public Player(String name, String race, String _class, int HP, int AC, Status stats)
        {
            playerCount++;

            this.ID = playerCount;

            this.Name = name;
            this.Race = race;
            this.levelByClass.Add(_class, 1);

            this.XP = 0;
            this.totalLevel = 1;

            this.AC = AC;
            this.maxHP = this.HP = HP;
            this.HitDice = 1;

            this.Stats = stats;

            this.StatsMod = new StatsModifiers();
            StatsMod.STR = getModifier(Stats.STR);
            StatsMod.DEX = getModifier(Stats.DEX);
            StatsMod.CON = getModifier(Stats.CON);
            StatsMod.INT = getModifier(Stats.INT);
            StatsMod.WIS = getModifier(Stats.WIS);
            StatsMod.CHA = getModifier(Stats.CHA);
        }

        public Player(String name, String race, String _class, int HP, int AC, Status stats,
            bool proficiencyInsight, bool proficiencyInvestigation, bool proficiencyPerception)
        {
            playerCount++;

            this.ID = playerCount;

            this.Name = name;
            this.Race = race;
            this.levelByClass.Add(_class, 1);

            this.XP = 0;
            this.totalLevel = 1;

            this.AC = AC;
            this.maxHP = this.HP = HP;
            this.HitDice = 1;

            this.Stats = stats;

            this.StatsMod = new StatsModifiers();
            StatsMod.STR = getModifier(Stats.STR);
            StatsMod.DEX = getModifier(Stats.DEX);
            StatsMod.CON = getModifier(Stats.CON);
            StatsMod.INT = getModifier(Stats.INT);
            StatsMod.WIS = getModifier(Stats.WIS);
            StatsMod.CHA = getModifier(Stats.CHA);

            this.passiveInsight = 10 + StatsMod.WIS + (proficiencyInsight ? proficiencyByLevel[1] : 0);
            this.passiveInvestigation = 10 + StatsMod.INT + (proficiencyInvestigation ? proficiencyByLevel[1] : 0);
            this.passivePerception = 10 + StatsMod.WIS + (proficiencyPerception ? proficiencyByLevel[1] : 0);
        }
    }
}
