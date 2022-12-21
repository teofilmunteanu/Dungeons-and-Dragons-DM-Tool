using System;
using System.Collections.Generic;
using System.Windows;

namespace Deez_Notes_Dm.Models
{
    public class Creature
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public string Race { get; set; }

        public int AC { get; set; }
        public int MaxHP { get; set; }
        public int HP { get; set; }

        public class Speed
        {
            public int walk { get; set; }
            public int climb { get; set; }
            public int swim { get; set; }
            public int burrow { get; set; }
            public int fly { get; set; }
            public int hover { get; set; }
        };
        public Speed Speeds { get; set; }
        public List<string> SpeedsText { get; set; }

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

        public double initiative { get; set; }

        protected int getModifier(int statusValue)
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

                if (this.HP < 0)
                {
                    MessageBox.Show(this.Name + " is unconscious");
                    this.HP = 0;
                }
            }


        }
    }
}
