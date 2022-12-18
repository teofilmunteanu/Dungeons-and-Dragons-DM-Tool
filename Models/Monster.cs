using System;
using System.Collections.Generic;

namespace Deez_Notes_Dm.Models
{
    public class Monsters
    {
        public List<Monster> monsters { get; set; }
    }

    public class Monster : Combatant
    {
        //static int monsterCount;

        //public int ID { get; set; }
        public string Name { get; set; }
        //public string Type { get; set; }
        //public string Size { get; set; }
        //public string Alignment { get; set; }

        //public int AC { get; set; }
        public int maxHP { get; set; }
        //public int HP { get; set; }
        //public string HP_Dice { get; set; }

        //public class Speed
        //{
        //    public int walk { get; set; }
        //    public int climb { get; set; }
        //    public int fly { get; set; }
        //    public int swim { get; set; }
        //};
        //Speed speed { get; set; }


        //public class Status
        //{
        //    public int STR { get; set; }
        //    public int DEX { get; set; }
        //    public int CON { get; set; }
        //    public int INT { get; set; }
        //    public int WIS { get; set; }
        //    public int CHA { get; set; }
        //}
        //public Status Stats { get; set; }

        //public class StatsModifiers
        //{
        //    public int STR { get; set; }
        //    public int DEX { get; set; }
        //    public int CON { get; set; }
        //    public int INT { get; set; }
        //    public int WIS { get; set; }
        //    public int CHA { get; set; }
        //}
        //public StatsModifiers StatsMod { get; set; }

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


        int getModifier(int statusValue)
        {
            return (int)Math.Floor(((statusValue - 10)) / 2.0);
        }

        public Monster()
        {

        }

        public Monster(string name, int maxHP)
        {
            //monsterCount++;

            //this.ID = monsterCount - 1;
            this.Name = name;
            this.maxHP = maxHP;
        }

        //~Monster()
        //{
        //    monsterCount--;
        //}

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
