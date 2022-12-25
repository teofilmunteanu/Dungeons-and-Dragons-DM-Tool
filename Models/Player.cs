﻿using System.Collections.Generic;
using System.Linq;

namespace Deez_Notes_Dm.Models
{
    public class Players
    {
        public List<Player> players { get; set; }
    }

    public class Player : Creature
    {
        public static int PlayerCount { get; set; }


        static readonly int[] XPbyLevel = { -1, 0, 300, 900, 2700, 6500, 14000, 23000, 34000, 48000, 64000, 85000, 100000, 120000, 140000, 165000, 195000, 225000, 265000, 305000, 355000 };
        public int XP { get; set; }
        public int totalLevel { get; set; }
        public SortedDictionary<string, int> levelByClass { get; set; } = new SortedDictionary<string, int>();


        public int HitDice { get; set; }
        public (int successes, int fails) DeathSaves { get; set; }


        public int PassiveInsight { get; set; }
        public int PassivePerception { get; set; }
        public int PassiveInvestigation { get; set; }

        private static readonly int[] proficiencyByLevel = { -1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6 };

        private bool proficiencyInsight;
        private bool proficiencyInvestigation;
        private bool proficiencyPerception;

        public Player()
        {
            PlayerCount++;
        }
        ~Player()
        {
            PlayerCount--;
        }

        public Player(string name, string race, string _class, int HP, int AC, Speed speed, Stats stats,
            bool proficiencyInsight, bool proficiencyInvestigation, bool proficiencyPerception)
        {
            PlayerCount++;

            this.ID = PlayerCount - 1;

            this.Name = name;
            this.Race = race;
            this.levelByClass.Add(_class, 1);

            this.XP = 0;
            this.totalLevel = 1;

            this.AC = AC;
            this.MaxHP = this.HP = HP;
            this.HitDice = 1;

            SpeedsText = new List<string>();
            this.SpeedsText.Add(Speed.toSpeedText("walk", speed.walk));
            if (speed.fly != 0)
            {
                this.SpeedsText.Add(Speed.toSpeedText("fly", speed.fly));
            }

            this.BaseStats = stats;

            this.StatsMod = new Stats
            {
                STR = getModifier(BaseStats.STR),
                DEX = getModifier(BaseStats.DEX),
                CON = getModifier(BaseStats.CON),
                INT = getModifier(BaseStats.INT),
                WIS = getModifier(BaseStats.WIS),
                CHA = getModifier(BaseStats.CHA)
            };

            this.proficiencyInsight = proficiencyInsight;
            this.proficiencyPerception = proficiencyPerception;
            this.proficiencyInvestigation = proficiencyInvestigation;

            this.PassiveInsight = 10 + StatsMod.WIS + (proficiencyInsight ? proficiencyByLevel[1] : 0);
            this.PassiveInvestigation = 10 + StatsMod.INT + (proficiencyInvestigation ? proficiencyByLevel[1] : 0);
            this.PassivePerception = 10 + StatsMod.WIS + (proficiencyPerception ? proficiencyByLevel[1] : 0);
        }

        public void addXP(int XP)
        {
            if (XP > 0)
            {
                this.XP += XP;

                while (totalLevel < 20 && this.XP > XPbyLevel[this.totalLevel + 1])
                {
                    levelUp();
                }
            }

        }

        public void levelUp()
        {
            this.totalLevel++;
            this.HitDice++;

            if (levelByClass.Count == 1)
            {
                levelByClass[levelByClass.First().Key]++;
            }

            //if(nr of classes > 1) choose class (retun message?), separate method for classLevelUp

            this.PassiveInsight = 10 + StatsMod.WIS + (proficiencyInsight ? proficiencyByLevel[totalLevel] : 0);
            this.PassiveInvestigation = 10 + StatsMod.INT + (proficiencyInvestigation ? proficiencyByLevel[totalLevel] : 0);
            this.PassivePerception = 10 + StatsMod.WIS + (proficiencyPerception ? proficiencyByLevel[totalLevel] : 0);
        }
    }
}
