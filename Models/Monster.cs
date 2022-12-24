﻿using System.Collections.Generic;
using System.Reflection;

namespace Deez_Notes_Dm.Models
{
    public class Monsters
    {
        public List<Monster> monsters { get; set; }
    }

    public class Monster : Creature
    {
        public static int MonsterCount { get; set; }

        //public string Size { get; set; }
        //public string Alignment { get; set; }

        //public string HP_Dice { get; set; }


        //public class SavingThrows
        //{
        //    public int STR { get; set; }
        //    public int DEX { get; set; }
        //    public int CON { get; set; }
        //    public int INT { get; set; }
        //    public int WIS { get; set; }
        //    public int CHA { get; set; }
        //}
        //public SavingThrows savingThrows { get; set; }

        //public string skills { get; set; }
        //public string senses { get; set; }
        //public string languages { get; set; }
        //public double ChallangeRank { get; set; }
        //public int XP_Drop { get; set; }

        //public string[] traits { get; set; }
        //public string[] actions { get; set; }
        //public string[] legendaryActions { get; set; }

        public Monster()
        {

        }

        public Monster(string name, string type, int maxHP, int AC, Status stats, Speed speed)
        {
            MonsterCount++;
            this.ID = MonsterCount - 1;

            this.Name = name + MonsterCount;
            this.Race = type;

            this.MaxHP = maxHP;
            this.HP = maxHP;
            this.AC = AC;

            this.Stats = stats;

            StatsMod = new Status
            {
                STR = getModifier(Stats.STR),
                DEX = getModifier(Stats.DEX),
                CON = getModifier(Stats.CON),
                INT = getModifier(Stats.INT),
                WIS = getModifier(Stats.WIS),
                CHA = getModifier(Stats.CHA)
            };

            Speeds = speed;

            SpeedsText = new List<string>();
            foreach (PropertyInfo prop in Speeds.GetType().GetProperties())
            {
                int speedVal = (int)prop.GetValue(Speeds);
                if (speedVal != 0)
                {
                    SpeedsText.Add(Speed.toSpeedText(prop.Name, speedVal));
                }
            }
        }

        ~Monster()
        {
            MonsterCount--;
        }

        //public Monster(String name, String type, int HP, int AC, Status stats)
        //{
        //    monsterCount++;

        //    this.ID = monsterCount - 1;

        //    this.Name = name;
        //    this.Type = type;

        //    this.XP_Drop = 0;

        //    this.AC = AC;
        //    this.maxHP = this.HP = HP;

        //    this.Stats = stats;

        //    this.StatsMod = new StatsModifiers();
        //    StatsMod.STR = getModifier(Stats.STR);
        //    StatsMod.DEX = getModifier(Stats.DEX);
        //    StatsMod.CON = getModifier(Stats.CON);
        //    StatsMod.INT = getModifier(Stats.INT);
        //    StatsMod.WIS = getModifier(Stats.WIS);
        //    StatsMod.CHA = getModifier(Stats.CHA);
        //}
    }
}