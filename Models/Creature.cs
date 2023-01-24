using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;

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
        public List<string> SpeedsList { get; set; }

        public Stats BaseStats { get; set; }

        public Stats StatsMod { get; set; }

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

            SpeedsList = new List<string>();
            if (speeds is not null)
            {
                foreach (PropertyInfo prop in speeds.GetType().GetProperties())
                {
                    int? speedVal = (int?)prop.GetValue(speeds);

                    if (speedVal != 0)
                    {
                        SpeedsList.Add(speeds.ToSpeedText(prop.Name));
                    }
                }
            }
        }

        protected static int getModifier(int statusValue)
        {
            return (int)Math.Floor(((statusValue - 10)) / 2.0);
        }

        public void dealDamage(int dmg)
        {
            if (dmg - HP >= MaxHP)
            {
                MessageBox.Show(this.Name + " died");
                this.HP = 0;
            }
            else
            {
                this.HP -= dmg;

                if (this.HP <= 0)
                {
                    MessageBox.Show(this.Name + " is unconscious");
                    this.HP = 0;
                }
            }
        }

        public void heal(int hpAdder)
        {
            this.HP += hpAdder;

            if (this.HP > MaxHP)
            {
                this.HP = MaxHP;
            }
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
            public int walk { get; set; }
            public int climb { get; set; }
            public int swim { get; set; }
            public int burrow { get; set; }
            public int fly { get; set; }
            public int hover { get; set; }

            public string ToSpeedText(string speedType)
            {
                PropertyInfo? speed = this.GetType().GetProperty(speedType);
                if (speed is not null)
                {
                    return $"{speedType} {speed.GetValue(this)} ft";
                }
                else
                    throw new Exception("Invalid Speed Type");
            }
        }
    }
}
