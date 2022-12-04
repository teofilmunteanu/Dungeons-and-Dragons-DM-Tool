using System;
using System.Collections.Generic;

namespace Deez_Notes_Dm.Models
{
    internal class Player
    {
        String name;
        String race;

        int XP;
        int[] XPbyLevel = { -1, 0, 300, 900, 2700, 6500, 14000, 23000, 34000, 48000, 64000, 85000, 100000, 120000, 140000, 165000, 195000, 225000, 265000, 305000, 355000 };
        int totalLevel;
        Dictionary<string, int> levelByClass = new Dictionary<string, int>();


        int AC;
        int maxHP;
        int HP;
        int HitDice;

        int succededDeathSaves;
        int failedDeathSaves;


        Dictionary<string, int> stats = new Dictionary<string, int> {
            {"STR", 0},
            {"DEX", 0},
            {"CON", 0},
            {"INT", 0},
            {"WIS", 0},
            {"CHA", 0}
        };

        int passiveInsight;
        int passiveInvestigation;
        int passivePerception;

        int[] proficiencyByLevel = { -1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6 };
        bool proficiencyInsight;
        bool proficiencyInvestigation;
        bool proficiencyPerception;


        int getModifier(String statBlock)
        {
            return (int)Math.Floor(((stats[statBlock] - 10)) / 2.0);
        }


        Player(String name, String race, String _class, int HP, int AC, Dictionary<string, int> stats,
            bool proficiencyInsight, bool proficiencyInvestigation, bool proficiencyPerception)
        {
            this.name = name;
            this.race = race;

            this.XP = 0;
            this.totalLevel = 1;
            this.levelByClass.Add(_class, 1);

            this.AC = AC;
            this.maxHP = this.HP = HP;
            this.HitDice = 1;

            this.stats = stats;
            this.proficiencyInsight = proficiencyInsight;
            this.proficiencyInvestigation = proficiencyInvestigation;
            this.proficiencyPerception = proficiencyPerception;

            Console.WriteLine(getModifier("WIS"));
            this.passiveInsight = 10 + getModifier("WIS") + (proficiencyInsight ? proficiencyByLevel[1] : 0);
            this.passiveInvestigation = 10 + getModifier("INT") + (proficiencyInsight ? proficiencyByLevel[1] : 0);
            this.passivePerception = 10 + getModifier("WIS") + (proficiencyPerception ? proficiencyByLevel[1] : 0);
        }
    }
}
