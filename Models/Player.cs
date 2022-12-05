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
        public String Name { get; set; }
        public String Race { get; set; }

        public int XP { get; set; }
        static int[] XPbyLevel { get; set; } = { -1, 0, 300, 900, 2700, 6500, 14000, 23000, 34000, 48000, 64000, 85000, 100000, 120000, 140000, 165000, 195000, 225000, 265000, 305000, 355000 };
        public int totalLevel { get; set; }
        public Dictionary<string, int> levelByClass { get; set; } = new Dictionary<string, int>();


        public int AC { get; set; }
        public int maxHP { get; set; }
        public int HP { get; set; }
        public int HitDice { get; set; }

        public int succededDeathSaves { get; set; }
        public int failedDeathSaves { get; set; }

        //private Dictionary<String, int> _Stats;

        public Dictionary<String, int> Stats { get; set; }
        //{
        //    get { return _Stats; }
        //    set { _Stats = value; }
        //}
        public Dictionary<String, int> StatsMod { get; set; }
        



        //public int passiveInsight { get; set; }
        //public int passiveInvestigation { get; set; }
        //public int passivePerception { get; set; }

        //public int[] proficiencyByLevel { get; set; } = { -1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6 };
        //public bool proficiencyInsight { get; set; }
        //public bool proficiencyInvestigation { get; set; }
        //public bool proficiencyPerception { get; set; }


        //public int initiative { get; set; }


        int getModifier(String statBlock)
        {
            return (int)Math.Floor(((Stats[statBlock] - 10)) / 2.0);
        }

        public Player()
        {

        }

        public Player(String name, String race, int HP, int AC, Dictionary<string, int> stats)
        {
            this.Name = name;
            this.Race = race;

            this.XP = 0;
            this.totalLevel = 1;

            this.AC = AC;
            this.maxHP = this.HP = HP;
            this.HitDice = 1;

            this.Stats = stats;

            StatsMod = new Dictionary<string, int>()
            {
                {"STR", getModifier("STR")},
                {"DEX", getModifier("DEX")},
                {"CON", getModifier("CON")},
                {"INT", getModifier("INT")},
                {"WIS", getModifier("WIS")},
                {"CHA", getModifier("CHA")}
            };
        }

        //public Player(String name, String race, String _class, int HP, int AC, Dictionary<string, int> stats,
        //    bool proficiencyInsight, bool proficiencyInvestigation, bool proficiencyPerception)
        //{
        //    this.Name = name;
        //    this.Race = race;

        //    this.XP = 0;
        //    this.totalLevel = 1;
        //    this.levelByClass.Add(_class, 1);

        //    this.AC = AC;
        //    this.maxHP = this.HP = HP;
        //    this.HitDice = 1;

        //    this.stats = stats;
        //    this.proficiencyInsight = proficiencyInsight;
        //    this.proficiencyInvestigation = proficiencyInvestigation;
        //    this.proficiencyPerception = proficiencyPerception;

        //    Console.WriteLine(getModifier("WIS"));
        //    this.passiveInsight = 10 + getModifier("WIS") + (proficiencyInsight ? proficiencyByLevel[1] : 0);
        //    this.passiveInvestigation = 10 + getModifier("INT") + (proficiencyInsight ? proficiencyByLevel[1] : 0);
        //    this.passivePerception = 10 + getModifier("WIS") + (proficiencyPerception ? proficiencyByLevel[1] : 0);
        //}
    }
}
